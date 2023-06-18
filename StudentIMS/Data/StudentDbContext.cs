using Microsoft.EntityFrameworkCore;
using StudentIMS.Models;

namespace StudentIMS.Data
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Dae",
                    StudentNumber = 123456,
                    Age = 20
                },

                new Student
                {
                    Id = 2,
                    Name = "Sam",
                    Surname = "Dalton",
                    StudentNumber = 258369,
                    Age = 21
                },

                new Student
                {
                    Id = 3,
                    Name = "Paul",
                    Surname = "Wise",
                    StudentNumber = 259354,
                    Age = 19
                },

                new Student
                {
                    Id = 4,
                    Name = "Stacy",
                    Surname = "Willer",
                    StudentNumber = 685478,
                    Age = 22
                }
                ); 
        }
    }
}
   