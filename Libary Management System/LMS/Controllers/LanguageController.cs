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
    public class LanguageController : Controller
    {
        
        LanguageManager _languageManager=new LanguageManager();
        //
        // GET: /DepartMent/
        public ActionResult Index(LanguageSearchCriteria model)
        {
            var Languages = _languageManager.GetAllLanguages();
            if (Languages == null)
            {
                Languages = new List<Language>();
            }
            model.Languages = Languages;
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new LanguageVm();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(LanguageVm model)
        {
            if (ModelState.IsValid)
            {

                var languages = Mapper.Map<Language>(model);
                bool isSave = _languageManager.Add(languages);
                if (isSave)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var languages = new Language();
            if (id > 0)
            {
                languages = _languageManager.GetById(id);
                var model = Mapper.Map<DepartMentVm>(languages);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(LanguageVm model)
        {
            if (ModelState.IsValid)
            {
                var languages = Mapper.Map<Language>(model);
                bool isUpdate = _languageManager.Update(languages);
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
            var languages = new Language();
            if (id > 0)
            {
                languages = _languageManager.GetById(id);
                var model = Mapper.Map<LanguageVm>(languages);
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                bool isDelete = _languageManager.Delete(id);
                if (isDelete)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
	}
}