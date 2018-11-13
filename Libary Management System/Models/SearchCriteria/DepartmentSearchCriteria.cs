using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SearchCriteria
{
   public class DepartmentSearchCriteria
    {

        public string Name { get; set; }
        ICollection<Book> Books { get; set; }
        ICollection<Student> Students { get; set; }
        public List<Department> Departments { get; set; } 
    }
}
