using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ticketsBookingApis.Data;
using ticketsBookingApis.Models;

namespace ticketsBookingApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ticketController : ControllerBase
    {
        private readonly MovieDb _ticketContent;
        public ticketController(MovieDb movieDb)
        {
            _ticketContent = movieDb;
        }


        [HttpPost("ticketPost")]
        public IActionResult postTicketDetails([FromBody] ticketModel ticketM)
        {
            if (ticketM == null)
            {
                return BadRequest();
            }
            else 
            {
                _ticketContent.ticketModels.Add(ticketM);
                _ticketContent.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Ticket Created Successfully"
                }
                );
            }
        }

        [HttpGet("myTicket/userId")]
        public IActionResult GetMyTicket( int userId)
        {
            // ticketModel[] myTickets ;

            var tickets = _ticketContent.ticketModels.Where(a => a.userId == userId).ToList();

            return Ok(
                new
                {
                    StatusCode = 200,
                    Message = "Tickets Fetched Successfully",
                    data = tickets
                }
            );
            

        }


    }
}
