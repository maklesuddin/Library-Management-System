using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SearchCriteria
{
   public class LanguageSearchCriteria
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool isDelete { get; set; }

        private ICollection<Book> Books { get; set; }
        public List<Language> Languages { get; set; }
    }
}
