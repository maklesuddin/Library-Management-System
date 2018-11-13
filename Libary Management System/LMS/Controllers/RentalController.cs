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
    public class RentalController : Controller
    {
       RentalManager _rentalManager=new RentalManager();
        //
        // GET: /Book/
        public ActionResult Index(RentalSearchCriteria model)
        {
            var rentals = _rentalManager.GetAllRental();
            if (rentals == null)
            {
                rentals = new List<Rental>();
            }
            model.BookListItems = GetBookList();
            model.LibrarianListItems = GetLibrarianlist();
            model.StudentListItems = GetStudentlist();
            model.Rentals = rentals;
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new RentalVm();
            model.BookListItems = GetBookList();
            model.LibrarianListItems = GetLibrarianlist();
            model.StudentListItems = GetStudentlist();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RentalVm model)
        {
            if (ModelState.IsValid)
            {

                var rentals = Mapper.Map<Rental>(model);
                model.BookListItems = GetBookList();
                model.LibrarianListItems = GetLibrarianlist();
                model.StudentListItems = GetStudentlist();
                bool isSave = _rentalManager.Add(rentals);
                if (isSave)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var rentals = new Rental();
            if (id > 0)
            {
                rentals = _rentalManager.GetById(id);
                var model = Mapper.Map<RentalVm>(rentals);

                model.BookListItems = GetBookList();
                model.LibrarianListItems = GetLibrarianlist();
                model.StudentListItems = GetStudentlist();
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(RentalVm model)
        {
            if (ModelState.IsValid)
            {
                var rentals = Mapper.Map<Rental>(model);
                bool isUpdate = _rentalManager.Update(rentals);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
                model.BookListItems = GetBookList();
                model.LibrarianListItems = GetLibrarianlist();
                model.StudentListItems = GetStudentlist();
            }
            return View();
        }

        //Deatils
        public ActionResult Details(int id)
        {
            var rentals = new Rental();
            if (id > 0)
            {
                rentals = _rentalManager.GetById(id);
                var model = Mapper.Map<RentalVm>(rentals);
                model.BookListItems = GetBookList();
                model.LibrarianListItems = GetLibrarianlist();
                model.StudentListItems = GetStudentlist();
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                bool isDelete = _rentalManager.Delete(id);
                if (isDelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }



        //dropdown for Language
        private List<SelectListItem> GetBookList()
        {
            return _rentalManager.GetAllBooks()
               .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Title }).ToList();
        }

        //drop down for Department
        private List<SelectListItem> GetStudentlist()
        {
            return _rentalManager.GetAllStudent()
               .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text =c.FirstName+c.LastName }).ToList();
        }
        private List<SelectListItem> GetLibrarianlist()
        {
            return _rentalManager.GetAllLibrarian()
               .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.FirstName + c.LastName }).ToList();
        }
	}
}