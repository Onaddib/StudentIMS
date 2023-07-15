using DataAccess.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace StudentIMS.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DepartmentController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }


        public IActionResult DepartmentList()
        {
            List<Department> DepartmentList = _unitOfWork.DepartmentRepository.GetAll().ToList();
            return View(DepartmentList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department obj)
        {



            if (ModelState.IsValid)
            {
                _unitOfWork.DepartmentRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "New record added succesfully";
                return RedirectToAction("DepartmentList", "Department");
            }
            return View();

        }


        public IActionResult Edit(int id)
        {
            Department obj = _unitOfWork.DepartmentRepository.Get(o => o.Id == id);

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
        public IActionResult Edit(Department obj)
        {

            if (obj is not null)
            {
                _unitOfWork.DepartmentRepository.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Record Updated Successfully";
                return RedirectToAction("DepartmentList", "Department");
            }
            else
            {
                return NotFound();
            }


        }


        public IActionResult Delete(int id)
        {
            Department obj = _unitOfWork.DepartmentRepository.Get(o => o.Id == id);

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
        public IActionResult Delete(Department obj)
        {

            if (obj is not null)
            {
                _unitOfWork.DepartmentRepository.Delete(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Record Deleted Successfully";
                return RedirectToAction("DepartmentList", "Department");
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
