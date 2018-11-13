using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ModelView
{
   public class LibrarianVm
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public virtual Gender Gender { get; set; }

        public bool isDelete { get; set; }

        ICollection<Rental> Rentals { get; set; }
        public List<SelectListItem> GenderListItem { get; set; } 

    }
}
