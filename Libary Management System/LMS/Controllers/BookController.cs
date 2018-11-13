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
    public class BookController : Controller
    {
        BookManager _bookManager = new BookManager();
        //
        // GET: /Book/
        public ActionResult Index(BookSearchCriteria model)
        {
            var books = _bookManager.GetAllBook();
            if (books == null)
            {
                books = new List<Book>();
            }
            model.LanguageListItem = GetLanguagelist();
            model.DepartmentListItem = GetDepartmentlist();
            model.Books = books;
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new BookVm();
            model.LanguageListItem = GetLanguagelist();
            model.DepartmentListItem = GetDepartmentlist();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookVm model)
        {
            if (ModelState.IsValid)
            {

                var books = Mapper.Map<Book>(model);
                bool isSave = _bookManager.Add(books);
                if (isSave)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var book = new Book();
            if (id > 0)
            {
                book = _bookManager.GetById(id);
                var model = Mapper.Map<BookVm>(book);
                model.LanguageListItem = GetLanguagelist();
                model.DepartmentListItem = GetDepartmentlist();
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(BookVm model)
        {
            if (ModelState.IsValid)
            {
                var books = Mapper.Map<Book>(model);
                bool isUpdate = _bookManager.Update(books);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
                model.LanguageListItem = GetLanguagelist();
                model.DepartmentListItem = GetDepartmentlist();
            }
            return View();
        }

        //Deatils
        public ActionResult Details(int id)
        {
            var book = new Book();
            if (id > 0)
            {
                book = _bookManager.GetById(id);
                var model = Mapper.Map<BookVm>(book);
                model.LanguageListItem = GetLanguagelist();
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
                bool isDelete = _bookManager.Delete(id);
                if (isDelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }



        //dropdown for Language
        private List<SelectListItem> GetLanguagelist()
        {
            return _bookManager.GetAlLanguages()
               .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

        //drop down for Department
        private List<SelectListItem> GetDepartmentlist()
        {
            return _bookManager.GetAllDepartments()
               .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

	}
}