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
   public class BookManager
    {
        BookRepository _bookRepository=new BookRepository();
        public bool Add(Book book)
        {
            return _bookRepository.Add(book);
        }

        public bool Update(Book book)
        {
            return _bookRepository.Update(book);
        }

        public bool Delete(int id)
        {
            return _bookRepository.Delete(id);
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public List<Book> GetAllBook()
        {
            return _bookRepository.GetAllBook();
        }

       public List<Department> GetAllDepartments()
       {
           return _bookRepository.GetAllDepartments();
       }

       public List<Language> GetAlLanguages()
       {
           return _bookRepository.GetAlLanguages();
       } 
        public List<Book> GetBookBySearch(BookSearchCriteria model)
        {
            return _bookRepository.GetBookBySearch(model);
        }
    }
}
