using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SearchCriteria
{
  public class BookSearchCriteria
    {
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Edition { get; set; }
        public int LanguageId { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public virtual Language Language { get; set; }
        public virtual Department Department { get; set; }

        public List<SelectListItem> LanguageListItem { get; set; }
        public List<SelectListItem> DepartmentListItem { get; set; }
        public List<Book> Books { get; set; } 
    }
}
