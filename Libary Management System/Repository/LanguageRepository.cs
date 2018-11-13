using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSDatabase;
using Models;
using Models.SearchCriteria;

namespace Repository
{
   public class LanguageRepository
    {
        DbContextLms db = new DbContextLms();

        public bool Add(Language language)
        {
            db.Languages.Add(language);
            bool isSave = db.SaveChanges() > 0;
            return isSave;
        }

        public bool Update(Language language)
        {
            db.Languages.Attach(language);
            db.Entry(language).State = EntityState.Modified;
            bool isUpdate = db.SaveChanges() > 0;
            return isUpdate;
        }

        public bool Delete(int id)
        {
            var languages = db.Languages.FirstOrDefault(b => b.Id == id);
            if (languages != null)
            {
                languages.isDelete = true;
            }
            return Update(languages);
        }

        public Language GetById(int id)
        {
            var language = db.Languages.FirstOrDefault(b => b.Id == id);
            return language;
        }

        public List<Language> GetAllLanguages()
        {
            var language = db.Languages.Where(d => d.isDelete == false).ToList();
            return language;
        }
        //Search Option
        public List<Language> GetLanguageBySearch(LanguageSearchCriteria model)
        {
            IEnumerable<Language> languages = db.Languages.Where(d => d.isDelete == false).AsQueryable();
            if (!string.IsNullOrEmpty(model.Name))
            {
                languages = languages.Where(b => b.Name.ToString().ToLower().Contains(model.Name.ToString().ToLower()));
            }
            return languages.ToList();
        }

    
    }
}
