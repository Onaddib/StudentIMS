using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.Models
{
    public class StudentViewModel
    {
        public Student Student { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set;}
    }
}
