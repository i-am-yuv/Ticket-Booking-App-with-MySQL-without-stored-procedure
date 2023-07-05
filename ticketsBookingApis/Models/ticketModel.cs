using System.ComponentModel.DataAnnotations;

namespace ticketsBookingApis.Models
{
    public class ticketModel
    {
        [Key]
        public int ticketId { get; set; }

        public int idMovies { get; set; }
        public String customerName { get; set; }

        public String title { get; set; }
        public String customerPhoneNumber { get; set; }

        public String dateOfTheShow { get; set; }

        public String timeSlot { get; set; }

        public int seats { get; set; }

        public int userId { get; set; }
    }
}
