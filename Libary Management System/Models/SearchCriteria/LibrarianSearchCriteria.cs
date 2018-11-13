using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SearchCriteria
{
   public class LibrarianSearchCriteria
    {

      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual Gender Gender { get; set; }
        ICollection<Rental> Rentals { get; set; }
        public List<Librarian> Librarians { get; set; }
        public List<SelectListItem> GenderListItem { get; set; } 

    }
}
