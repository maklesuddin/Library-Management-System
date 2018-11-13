using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Department
    {
     
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department")]
        [MaxLength(100)]
        public string Name { get; set; }
        public bool isDelete { get; set; }

        ICollection<Book> Books { get; set; }
        ICollection<Student> Students { get; set; }
    }
}
