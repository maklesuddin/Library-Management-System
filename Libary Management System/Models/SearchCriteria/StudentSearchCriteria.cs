using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.SearchCriteria
{
  public class StudentSearchCriteria
    {
        public int Id { get; set; }
        public int StudentIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Department Department { get; set; }

        public bool isDelete { get; set; }
        ICollection<Rental> Rentals { get; set; }
        public List<SelectListItem> GenderListItem { get; set; }
        public List<SelectListItem> DepartmentListItem { get; set; }
        public List<Student> Students { get; set; } 
        
    }
}
