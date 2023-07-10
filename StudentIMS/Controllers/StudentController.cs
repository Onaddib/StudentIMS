using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using DataAccess.Data;
using Models.Models;
using DataAccess.Data.Repository;


namespace StudentIMS.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _stdRepo;

        public StudentController(IStudentRepository stdRepo) {
            _stdRepo = stdRepo;
        }





        public IActionResult Index()
        {
            return View();
        }


        public IActionResult StudentList()
        {
            List<Student> studentList = _stdRepo.GetAll().ToList();
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
                _stdRepo.Add(obj);
                _stdRepo.Save();
                TempData["success"] = "New record added succesfully";
                return RedirectToAction("StudentList","Student");   
            }
            return View();  

        }


        public IActionResult Edit(int id)
        {
            Student obj = _stdRepo.Get(o => o.Id==id);

            if (obj is not null)
            {
                return View(obj);

            }else
            {
                return NotFound(); 
            }
        }


        [HttpPost]
        public IActionResult Edit(Student obj)
        {

            if(obj is not null)
            {
                _stdRepo.Update(obj);
                _stdRepo.Save();
                TempData["Success"] = "Record Updated Successfully";
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
                return NotFound();
            }
            
         
        }


        public IActionResult Delete(int id)
        {
            Student obj = _stdRepo.Get(o => o.Id == id);

            if (obj is not null)
            {
                return View(obj);

            }
            else
            {
                return NotFound();
            }
        }



        [HttpPost]
        public IActionResult Delete(Student obj)
        {

            if (obj is not null)
            {
                _stdRepo.Delete(obj);
                _stdRepo.Save();
                TempData["Success"] = "Record Deleted Successfully";
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
                return NotFound();
            }


        }






        public IActionResult Privacy()
        {
            return View();
        }




    }


}
