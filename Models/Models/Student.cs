using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Models
{
    public class Student
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Surname is required")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Student Number")]
        public int StudentNumber { get; set; }

        [Range(17,70, ErrorMessage ="Age must be between 17 and 70")]
        public int Age { get; set; }


        public int DepartmentId { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }


        [ValidateNever]
        [ForeignKey("DepartmentId")]

        public Department Department { get; set; } 

    }
}
