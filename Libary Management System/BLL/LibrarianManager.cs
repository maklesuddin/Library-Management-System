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
   public class LibrarianManager
    {
       LibrarianRepository _librarianRepository=new LibrarianRepository();
        public bool Add(Librarian librarian)
        {
            return _librarianRepository.Add(librarian);
        }

        public bool Update(Librarian librarian)
        {
            return _librarianRepository.Update(librarian);
        }

        public bool Delete(int id)
        {
            return _librarianRepository.Delete(id);
        }

        public Librarian GetById(int id)
        {
            return _librarianRepository.GetById(id);
        }

        public List<Librarian> GetAllLibrarian()
        {
            return _librarianRepository.GetAllLibrarian();
        }

        public List<Gender> GetAllGender()
        {
            return _librarianRepository.GetAllGender();
        }

        public List<Librarian> GetLibrarianBySearch(LibrarianSearchCriteria  model)
        {
            return _librarianRepository.GetLibrarianBySearch(model);
        }
    }
}
