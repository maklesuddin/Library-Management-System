using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SearchCriteria
{
   public class RentalSearchCriteria
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime ReturnDate { get; set; }
        public int LibrarianId { get; set; }
        public DateTime LastUpdate { get; set; }
        public virtual Book Book { get; set; }

        public virtual Student Student { get; set; }
        public virtual Librarian Librarian { get; set; }
        public List<SelectListItem> StudentListItems { get; set; }
        public List<SelectListItem> LibrarianListItems { get; set; }
        public List<SelectListItem> BookListItems { get; set; }
        public List<Rental> Rentals { get; set; } 
        public bool isDelete { get; set; }
    }
}
