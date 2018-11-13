using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.SearchCriteria;
using Repository;

namespace BLL
{
  public class LanguageManager
    {
      LanguageRepository _languageRepository=new LanguageRepository();
        public bool Add(Language language)
        {
            return _languageRepository.Add(language);
        }

        public bool Update(Language language)
        {
            return _languageRepository.Update(language);
        }

        public bool Delete(int id)
        {
            return _languageRepository.Delete(id);
        }

        public Language GetById(int id)
        {
            return _languageRepository.GetById(id);
        }


        public List<Language> GetAllLanguages()
        {
            return _languageRepository.GetAllLanguages();
        }


        public List<Language> GetLanguageBySearch(LanguageSearchCriteria model)
        {
            return _languageRepository.GetLanguageBySearch(model);
        }
    }
}
