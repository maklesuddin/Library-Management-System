using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSDatabase;
using Models;
using Models.SearchCriteria;

namespace Repository
{
  public class DepartMentRepository
    {
        DbContextLms db = new DbContextLms();

        public bool Add(Department department)
        {
            db.Departments.Add(department);
            bool isSave = db.SaveChanges() > 0;
            return isSave;
        }

        public bool Update(Department department)
        {
            db.Departments.Attach(department);
            db.Entry(department).State = EntityState.Modified;
            bool isUpdate = db.SaveChanges() > 0;
            return isUpdate;
        }

        public bool Delete(int id)
        {
            var departments = db.Departments.FirstOrDefault(b => b.Id == id);
            if (departments != null)
            {
                departments.isDelete = true;
            }
            return Update(departments);
        }

        public Department GetById(int id)
        {
            var departments = db.Departments.FirstOrDefault(b => b.Id == id);
            return departments;
        }


        public List<Department> GetAllDepartments()
        {
            var departments = db.Departments.Where(d => d.isDelete == false).ToList();
            return departments;
        }

        //Search Option
        public List<Department> GetDepartmentBySearch(DepartmentSearchCriteria model)
        {
            IEnumerable<Department> departments = db.Departments.Where(d => d.isDelete == false).AsQueryable();
            if (!string.IsNullOrEmpty(model.Name))
            {
                departments = departments.Where(b => b.Name.ToString().ToLower().Contains(model.Name.ToString().ToLower()));
            }
            return departments.ToList();
        }

     
    }
}
