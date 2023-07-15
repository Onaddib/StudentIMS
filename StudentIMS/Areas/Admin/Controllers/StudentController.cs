using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using DataAccess.Data;
using Models.Models;
using DataAccess.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentIMS.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class StudentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }





        public IActionResult Index()
        {
            return View();
        }


        public IActionResult StudentList()
        {
            List<Student> studentList = _unitOfWork.StudentRepository.GetAll().ToList();
            return View(studentList);
        }

        public IActionResult Create()
        {

            IEnumerable<SelectListItem> DepartmentList = _unitOfWork.DepartmentRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.Depart,
                Value = i.Id.ToString()
            });

            ViewData["DepartmentList"] = DepartmentList;
            //ViewBag.DepartmentList = DepartmentList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student obj)
        {
            if (obj.Name == obj.Surname)
            {
                ModelState.AddModelError("Name", "Name and surname can't be same");
            }


            if (ModelState.IsValid)
            {
                _unitOfWork.StudentRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "New record added succesfully";
                return RedirectToAction("StudentList", "Student");
            }
            else
            {
                IEnumerable<SelectListItem> DepartmentList = _unitOfWork.DepartmentRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Depart,
                    Value = i.Id.ToString()
                });

                ViewData["DepartmentList"] = DepartmentList;
                //ViewBag.DepartmentList = DepartmentList;

                return View();

            }
        }


        public IActionResult Edit(int id)
        {
            Student obj = _unitOfWork.StudentRepository.Get(o => o.Id == id);

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
        public IActionResult Edit(Student obj)
        {

            if (obj is not null)
            {
                _unitOfWork.StudentRepository.Update(obj);
                _unitOfWork.Save();
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
            Student obj = _unitOfWork.StudentRepository.Get(o => o.Id == id);

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
                _unitOfWork.StudentRepository.Delete(obj);
                _unitOfWork.Save();
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
