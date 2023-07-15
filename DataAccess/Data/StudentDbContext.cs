using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace DataAccess.Data
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Depart = "Business Administration"
                },
                new Department
                {
                    Id = 2,
                    Depart = "Computer Science"
                },
                new Department
                {
                    Id = 3,
                    Depart = "Management Information Systems"
                }
                );
            
        

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Dae",
                    StudentNumber = 123456,
                    Age = 20,
                    DepartmentId = 1


                },

                new Student
                {
                    Id = 2,
                    Name = "Sam",
                    Surname = "Dalton",
                    StudentNumber = 258369,
                    Age = 21,
                    DepartmentId = 1



                },

                new Student
                {
                    Id = 3,
                    Name = "Paul",
                    Surname = "Wise",
                    StudentNumber = 259354,
                    Age = 19,
                    DepartmentId = 1,



                },

                new Student
                {
                    Id = 4,
                    Name = "Stacy",
                    Surname = "Willer",
                    StudentNumber = 685478,
                    Age = 22,
                    DepartmentId = 1
    


                });

            
        }
    }
}
   