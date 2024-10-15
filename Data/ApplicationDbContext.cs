using Microsoft.EntityFrameworkCore;
using PdfTest.Models;

namespace PdfTest.Data
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding data
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Tony", Occupation = "Doctor"},
                new Person { Id = 2, Name = "Liza", Occupation = "Nurse"}
            );
        }
    }
}