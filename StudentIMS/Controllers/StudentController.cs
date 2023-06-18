using Microsoft.AspNetCore.Mvc;
using StudentIMS.Data;
using StudentIMS.Models;

namespace StudentIMS.Controllers
{
    public class StudentController : Controller
    {


        private readonly StudentDbContext _db;
        public StudentController(StudentDbContext db) {
            _db = db;
        }



        public IActionResult Index()
        {
            return View();
        }


        public IActionResult StudentList()
        {
            List<Student> studentList = _db.Students.ToList();
            return View(studentList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }




    }


}
