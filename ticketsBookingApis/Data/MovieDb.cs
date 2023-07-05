using Microsoft.EntityFrameworkCore;
using ticketsBookingApis.Models;

namespace ticketsBookingApis.Data
{
    public class MovieDb : DbContext
    {
        public MovieDb( DbContextOptions<MovieDb> options ):base(options)
        {
            
        }

        public DbSet<MovieModel> movieModels { get; set; }

        public DbSet<ticketModel> ticketModels { get; set; }

        public DbSet<SignUp> signUpModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieModel>().ToTable("movies");
            modelBuilder.Entity<ticketModel>().ToTable("ticket");
            modelBuilder.Entity<SignUp>().ToTable("signup");
        }
    }
}
