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
    public class DepartMentController : Controller
    {
        DepartMentManager _departMentManager = new DepartMentManager();
        //
        // GET: /DepartMent/
        public ActionResult Index(DepartmentSearchCriteria model)
        {
            var departments = _departMentManager.GetAllDepartments();
            if (departments == null)
            {
                departments = new List<Department>();
            } 
            model.Departments = departments;
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new DepartMentVm();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DepartMentVm model)
        {
            if (ModelState.IsValid)
            {

                var department = Mapper.Map<Department>(model);
                bool isSave = _departMentManager.Add(department);
                if (isSave)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var departments =new Department();
            if (id > 0)
            {
                departments = _departMentManager.GetById(id);
                var model = Mapper.Map<DepartMentVm>(departments);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(DepartMentVm model)
        {
            if (ModelState.IsValid)
            {
                var departments = Mapper.Map<Department>(model);
                bool isUpdate = _departMentManager.Update(departments);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        //Deatils
        public ActionResult Details(int id)
        {
            var departMents = new Department();
            if (id > 0)
            {
                departMents = _departMentManager.GetById(id);
                var model = Mapper.Map<DepartMentVm>(departMents);
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                bool isDelete = _departMentManager.Delete(id);
                if (isDelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
	}
}