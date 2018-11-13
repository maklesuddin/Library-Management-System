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
   public class LibrarianRepository
    {
        DbContextLms db = new DbContextLms();

        public bool Add(Librarian librarian)
        {
            db.Librarians.Add(librarian);
            bool isSave = db.SaveChanges() > 0;
            return isSave;
        }

        public bool Update(Librarian librarian)
        {
            db.Librarians.Attach(librarian);
            db.Entry(librarian).State = EntityState.Modified;
            bool isUpdate = db.SaveChanges() > 0;
            return isUpdate;
        }

        public bool Delete(int id)
        {
            var librarians = db.Librarians.FirstOrDefault(b => b.Id == id);
            if (librarians != null)
            {
                librarians.isDelete = true;
            }
            return Update(librarians);
        }

        public Librarian GetById(int id)
        {
            var librarians = db.Librarians.FirstOrDefault(b => b.Id == id);
            return librarians;
        }

        public List<Librarian> GetAllLibrarian()
        {
            var librarians = db.Librarians.Where(b => b.isDelete == false).ToList();
            return librarians;
        }

        public List<Gender> GetAllGender()
        {
            var genders = db.Genders.Where(d => d.isDelete == false).ToList();
            return genders;
        }

     
        //Search Option
        public List<Librarian> GetLibrarianBySearch(LibrarianSearchCriteria model)
        {
            IEnumerable<Librarian> librarians = db.Librarians.Where(b => b.isDelete == false).AsQueryable();
            if (!string.IsNullOrEmpty(model.FirstName))
            {
                librarians = librarians.Where(b => b.FirstName.ToString().ToLower().Contains(model.FirstName.ToString().ToLower()));
            }
            return librarians.ToList();
        }
    }
}
