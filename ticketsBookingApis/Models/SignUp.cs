using System.ComponentModel.DataAnnotations;

namespace ticketsBookingApis.Models
{
    public class SignUp
    {
        [Key]
        public int idsignUp { get; set; }

        public String email { get; set; }
        public String password { get; set; }
    }
}
