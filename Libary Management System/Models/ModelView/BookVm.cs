using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ModelView
{
   public class BookVm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }


        [MaxLength(255)]
        public string Cover { get; set; }

        [Required]
        [MaxLength(50)]
        public string Edition { get; set; }

        [Required]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Author(s)")]
        [DataType(DataType.MultilineText)]
        public string Author { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual Language Language { get; set; }

        public virtual Department Department { get; set; }

        public bool isDelete { get; set; }

        ICollection<Rental> Rentals { get; set; }

        public List<SelectListItem> LanguageListItem { get; set; }
        public List<SelectListItem> DepartmentListItem { get; set; }
    }
}
