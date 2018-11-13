using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.ModelView;
using Models.SearchCriteria;

namespace LMS.Controllers
{
    public class StudentController : Controller
    {
        StudentManager _studentManager=new StudentManager();
        //
        // GET: /Book/
        public ActionResult Index(StudentSearchCriteria model)
        {
            var students = _studentManager.GetAllStudent();
            if (students == null)
            {
                students = new List<Student>();
            }
            model.GenderListItem = GetGenderList();
            model.DepartmentListItem = GetDepartmentlist();
            model.Students = students;
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new StudentVm();
            model.GenderListItem = GetGenderList();
            model.DepartmentListItem = GetDepartmentlist();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(StudentVm model)
        {
            if (ModelState.IsValid)
            {

                var students = Mapper.Map<Student>(model);
                bool isSave = _studentManager.Add(students);
                if (isSave)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var students = new Student();
            if (id > 0)
            {
                students = _studentManager.GetById(id);
                var model = Mapper.Map<StudentVm>(students);
                model.GenderListItem = GetGenderList();
                model.DepartmentListItem = GetDepartmentlist();
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(StudentVm model)
        {
            if (ModelState.IsValid)
            {
                var students = Mapper.Map<Student>(model);
                bool isUpdate = _studentManager.Update(students);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
                model.GenderListItem = GetGenderList();
                model.DepartmentListItem = GetDepartmentlist();
            }
            return View();
        }

        //Deatils
        public ActionResult Details(int id)
        {
            var student = new Student();
            if (id > 0)
            {
                student = _studentManager.GetById(id);
                var model = Mapper.Map<StudentVm>(student);
                model.GenderListItem = GetGenderList();
                model.DepartmentListItem = GetDepartmentlist();
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                bool isDelete = _studentManager.Delete(id);
                if (isDelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }



        //dropdown for Language
        private List<SelectListItem> GetGenderList()
        {
            return _studentManager.GetAllGender()
               .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

        //drop down for Department
        private List<SelectListItem> GetDepartmentlist()
        {
            return _studentManager.GetAllDepartments()
               .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

	}
}