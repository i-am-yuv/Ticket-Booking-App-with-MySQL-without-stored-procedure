using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticketsBookingApis.Data;
using ticketsBookingApis.Models;

namespace ticketsBookingApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class signUpController : ControllerBase
    {
        private readonly MovieDb _signUpContent;
        public signUpController(MovieDb movieDb)
        {
            _signUpContent = movieDb;
        }

        [HttpPost("signUpPost")]
        public IActionResult postUser([FromBody] SignUp signUp)
        {
            var userObj = _signUpContent.signUpModels.Where(
                    a => a.email == signUp.email ).FirstOrDefault();

            if( userObj != null) {
                return NotFound(
                        new
                        {
                            StatusCode = 404,
                            Message = "Already a User, Please Login"
                        });
            }        
            if (signUp == null)
            {
                return BadRequest();
            }
            else
            {
                
                _signUpContent.signUpModels.Add(signUp);
                _signUpContent.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "User Created Successfully"
                }
                );
            }
        }

        [HttpPost("loginPost")]
        public IActionResult loginCheck([FromBody] SignUp signUp)
        {
            if (signUp == null)
            {
                return BadRequest();
            }
            else
            {
                var userObj = _signUpContent.signUpModels.Where(
                    a => a.email == signUp.email && a.password == signUp.password ).FirstOrDefault();

                if (userObj != null)
                {
                    return Ok(
                        new
                        {
                            StatusCode = 200,
                            Message = "Logged In Successfully",
                            UserData = userObj.idsignUp 
                          });
                }
                else
                {
                    return NotFound(
                        new
                        {
                            StatusCode = 404,
                            Message = "User Not Found"
                        });
                }
            }
        }
    }
}
