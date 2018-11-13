using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ModelView
{
   public class RentalVm
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Rental Date")]
        public DateTime RentalDate { get; set; }

        [Required]
        [Display(Name = "Book")]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        [Display(Name = "Librarian")]
        public int LibrarianId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }
        public virtual Book Book { get; set; }
        public bool isDelete { get; set; }
        public virtual Student Student { get; set; }
        public virtual Librarian Librarian { get; set; }

        public List<SelectListItem> StudentListItems { get; set; }
        public List<SelectListItem> LibrarianListItems { get; set; }
        public List<SelectListItem> BookListItems { get; set; }
        
      
    }
}
