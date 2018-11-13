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
    public class LibrarianController : Controller
    {
        LibrarianManager _librarianManager=new LibrarianManager();
        //
        // GET: /Book/
        public ActionResult Index(LibrarianSearchCriteria model)
        {
            var librarians = _librarianManager.GetAllLibrarian();
            if (librarians == null)
            {
                librarians = new List<Librarian>();
            }
            model.GenderListItem = GetGenderList();
            model.Librarians =librarians;
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new LibrarianVm();
            model.GenderListItem = GetGenderList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(LibrarianVm model)
        {
            if (ModelState.IsValid)
            {
                var librarians = Mapper.Map<Librarian>(model);
                model.GenderListItem = GetGenderList();
                bool isSave = _librarianManager.Add(librarians);
                if (isSave)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var librarians = new Librarian();
            if (id > 0)
            {
                librarians = _librarianManager.GetById(id);
                var model = Mapper.Map<LibrarianVm>(librarians);
                model.GenderListItem = GetGenderList();
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(LibrarianVm model)
        {
            if (ModelState.IsValid)
            {
                var librarians = Mapper.Map<Librarian>(model);
                bool isUpdate = _librarianManager.Update(librarians);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
                model.GenderListItem = GetGenderList();
            }
            return View();
        }

        //Deatils
        public ActionResult Details(int id)
        {
            var librarian = new Librarian();
            if (id > 0)
            {
                librarian = _librarianManager.GetById(id);
                var model = Mapper.Map<LibrarianVm>(librarian);
                model.GenderListItem = GetGenderList();
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                bool isDelete = _librarianManager.Delete(id);
                if (isDelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }



        //dropdown for Gender
        private List<SelectListItem> GetGenderList()
        {
            return _librarianManager.GetAllGender()
               .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

      

	}
}