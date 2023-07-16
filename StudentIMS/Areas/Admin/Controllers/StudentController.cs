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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {

            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
            StudentViewModel _studentViewModel = new StudentViewModel();

            IEnumerable<SelectListItem> DepartmentList = _unitOfWork.DepartmentRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.Depart,
                Value = i.Id.ToString()
            });
            _studentViewModel.DepartmentList = DepartmentList;
            _studentViewModel.Student = new Student();
           // ViewData["DepartmentList"] = DepartmentList;
            //ViewBag.DepartmentList = DepartmentList;
            return View(_studentViewModel);
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel obj, IFormFile? file)
        {
            if (file is not null)
            {
                string wwwpathName = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPattern = Path.Combine(wwwpathName+@"\images\",fileName);
                using (FileStream fs = new FileStream(productPattern, FileMode.Create))
                {
                    file.CopyTo(fs);
                }

                obj.Student.ImageUrl = @"\images\"+fileName;
            }
            /*
             IEnumerable<SelectListItem> DepartmentList = _unitOfWork.DepartmentRepository.GetAll().Select(i => new SelectListItem
             {
                 Text = i.Depart,
                 Value = i.Id.ToString()
             });
             obj.DepartmentList = DepartmentList;
             */

            if (ModelState.IsValid)
            {
                _unitOfWork.StudentRepository.Add(obj.Student);
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

                obj.DepartmentList = DepartmentList;

                // ViewData["DepartmentList"] = DepartmentList;
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
