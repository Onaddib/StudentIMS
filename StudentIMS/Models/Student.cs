using System.ComponentModel.DataAnnotations;

namespace StudentIMS.Models
{
    public class Student
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int StudentNumber { get; set; }
        
        public int Age { get; set; }
    }
}
