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

        [HttpPost]
        public IActionResult Create(Student obj)
        {
            if(obj.Name == obj.Surname)
            {
                ModelState.AddModelError("Name", "Name and surname can't be same");
            }


            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "New record added succesfully";
                return RedirectToAction("StudentList","Student");   
            }
            return View();  

        }


        public IActionResult Edit(int Id)
        {
            Student obj = _db.Students.Find(Id);

            if (obj is not null)
            {
                return View(obj);

            }else
            {
                return NotFound(); 
            }
        }


        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }




    }


}
