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
   public class StudentRepository
    {

        DbContextLms db = new DbContextLms();

        public bool Add(Student student)
        {
            db.Students.Add(student);
            bool isSave = db.SaveChanges() > 0;
            return isSave;
        }

        public bool Update(Student student)
        {
            db.Students.Attach(student);
            db.Entry(student).State = EntityState.Modified;
            bool isUpdate = db.SaveChanges() > 0;
            return isUpdate;
        }

        public bool Delete(int id)
        {
            var students = db.Students.FirstOrDefault(b => b.Id == id);
            if (students != null)
            {
                students.isDelete = true;  
            }
            return Update(students);
        }

        public Student GetById(int id)
        {
            var students = db.Students.FirstOrDefault(b => b.Id == id);
            return students;
        }

        public List<Student> GetAllStudent()
        {
            var students = db.Students.Where(b => b.isDelete == false).ToList();
            return students;
        }

        public List<Department> GetAllDepartments()
        {
            var departments = db.Departments.Where(d => d.isDelete == false).ToList();
            return departments;
        }

        public List<Gender> GetAllGender()
        {
            var genders = db.Genders.Where(d => d.isDelete == false).ToList();
            return genders;
        }
        //Search Option
        public List<Student> GetBookBySearch(StudentSearchCriteria model)
        {
            IEnumerable<Student> students = db.Students.Where(b => b.isDelete == false).AsQueryable();
            if (!string.IsNullOrEmpty(model.FirstName))
            {
                students = students.Where(b => b.FirstName.ToString().ToLower().Contains(model.FirstName.ToString().ToLower()));
            }
            return students.ToList();
        }
    }
}
