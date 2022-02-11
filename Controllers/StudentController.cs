using Stud_curd3.Models;
using Stud_curd3.Repository;
using Stud_curd3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stud_curd3.Controllers
{
    public class StudentController : Controller
    {
        private instituteEntities db = new instituteEntities();
        private StudentRepository _studentRepository;
        public StudentController()
        {
            _studentRepository = new StudentRepository();
        }
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        // GET: Student
        public ActionResult GetStudentList()
        {
            var student = _studentRepository.GetStudentList();
            return View(student);
        }
        [HttpGet]
        public ActionResult Insert(int id = 0)
        {
            var student = _studentRepository.Insert(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Insert(StudentViewModel studentViewModel)
        {
            HandleException handleException = _studentRepository.Insert(studentViewModel);
            return Json(handleException);
        }
        public ActionResult Details(int id)
        {
            var student = _studentRepository.Details(id);
            return View(student);
        }
        public ActionResult Delete(int id)
        {
            var student = _studentRepository.Delete(id);
            return RedirectToAction("GetStudentList");
        }
    }
}