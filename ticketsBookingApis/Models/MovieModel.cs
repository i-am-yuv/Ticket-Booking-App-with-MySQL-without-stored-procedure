using System.ComponentModel.DataAnnotations;

namespace ticketsBookingApis.Models
{
    public class MovieModel
    {
        [Key]
        public int idMovies { get; set; }

        public String title { get; set; }
        public String desc { get; set; }
        public String src { get; set; }


    }
}
