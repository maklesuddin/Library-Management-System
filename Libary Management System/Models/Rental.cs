using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Rental
    { 
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Rental Date")]
        public DateTime RentalDate { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        public int LibrarianId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }
        public virtual Book Book { get; set; }

        public virtual Student Student { get; set; }
        public virtual Librarian Librarian { get; set; }

        public bool isDelete { get; set; }
    }
}
