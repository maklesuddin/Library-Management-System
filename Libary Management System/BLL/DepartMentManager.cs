using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.SearchCriteria;
using Repository;

namespace BLL
{
   public class DepartMentManager
    {
        DepartMentRepository _departMentRepository=new DepartMentRepository();
        public bool Add(Department department)
        {
            return _departMentRepository.Add(department);
        }

        public bool Update(Department department)
        {
            return _departMentRepository.Update(department);
        }

        public bool Delete(int id)
        {
            return _departMentRepository.Delete(id);
        }

        public Department GetById(int id)
        {
            return _departMentRepository.GetById(id);
        }


        public List<Department> GetAllDepartments()
        {
            return _departMentRepository.GetAllDepartments();
        }


        public List<Department> GetDepartmentBySearch(DepartmentSearchCriteria model)
        {
            return _departMentRepository.GetDepartmentBySearch(model);
        }

    }
}
