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
  public class StudentManager
    {
        StudentRepository _studentRepository=new StudentRepository();
        public bool Add(Student student)
        {
            return _studentRepository.Add(student);
        }

        public bool Update(Student student)
        {
            return _studentRepository.Update(student);
        }

        public bool Delete(int id)
        {
            return _studentRepository.Delete(id);
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public List<Student> GetAllStudent()
        {
            return _studentRepository.GetAllStudent();
        }

        public List<Department> GetAllDepartments()
        {
            return _studentRepository.GetAllDepartments();
        }

        public List<Gender> GetAllGender()
        {
            return _studentRepository.GetAllGender();
        }
        public List<Student> GetBookBySearch(StudentSearchCriteria model)
        {
            return _studentRepository.GetBookBySearch(model);
        }
    }
}
