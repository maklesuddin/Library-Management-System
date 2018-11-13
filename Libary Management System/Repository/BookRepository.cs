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
   public class BookRepository
    {
        DbContextLms db=new DbContextLms();

        public bool Add(Book book)
        {
            db.Books.Add(book);
            bool isSave = db.SaveChanges() > 0;
            return isSave;
        }

       public bool Update(Book book)
       {
           db.Books.Attach(book);
           db.Entry(book).State=EntityState.Modified;
           bool isUpdate = db.SaveChanges() > 0;
           return isUpdate;
       }

       public bool Delete(int id)
       {
           var books = db.Books.FirstOrDefault(b => b.Id == id);
           books.isDelete = true;
           return Update(books);
       }

       public Book GetById(int id)
       {
           var books = db.Books.FirstOrDefault(b => b.Id == id);
           return books;
       }

       public List<Book> GetAllBook()
       {
           var books = db.Books.Where(b => b.isDelete == false).ToList();
           return books;
       }

       public List<Department> GetAllDepartments()
       {
           var departments = db.Departments.Where(d => d.isDelete == false).ToList();
           return departments;
       }

       public List<Language> GetAlLanguages()
       {
           var languages = db.Languages.Where(l => l.isDelete == false).ToList();
           return languages;
       } 
       //Search Option
       public List<Book> GetBookBySearch(BookSearchCriteria model)
       {
           IEnumerable<Book> books = db.Books.Where(b => b.isDelete == false).AsQueryable();
           if (!string.IsNullOrEmpty(model.Title))
           {
               books = books.Where(b => b.Title.ToString().ToLower().Contains(model.Title.ToString().ToLower()));
           }
           return books.ToList();
       }
    }
}
