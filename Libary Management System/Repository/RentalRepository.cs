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
   public class RentalRepository
    {
        DbContextLms db = new DbContextLms();

        public bool Add(Rental rental )
        {
            db.Rentals.Add(rental);
            bool isSave = db.SaveChanges() > 0;
            return isSave;
        }

        public bool Update(Rental rental)
        {
            db.Rentals.Attach(rental);
            db.Entry(rental).State = EntityState.Modified;
            bool isUpdate = db.SaveChanges() > 0;
            return isUpdate;
        }

        public bool Delete(int id)
        {
            var rentals = db.Rentals.FirstOrDefault(b => b.Id == id);
            if (rentals != null)
            {
                rentals.isDelete = true;
            }
            return Update(rentals);
        }

        public Rental GetById(int id)
        {
            var rentals = db.Rentals.FirstOrDefault(b => b.Id == id);
            return rentals;
        }
        public List<Rental> GetAllRental()
        {
            var rentals = db.Rentals.Where(d => d.isDelete == false).ToList();
            return rentals;
        }
        public List<Student> GetAllStudent()
        {
            var students = db.Students.Where(b => b.isDelete == false).ToList();
            return students;
        }
        public List<Book> GetAllBooks()
        {
            var books = db.Books.Where(d => d.isDelete == false).ToList();
            return books;
        }

        public List<Librarian> GetAllLibrarian()
        {
            var librarian = db.Librarians.Where(d => d.isDelete == false).ToList();
            return librarian;
        }
        //Search Option
        public List<Rental> GetRentalBySearch(RentalSearchCriteria model)
        {
            IEnumerable<Rental> rentals = db.Rentals.Where(b => b.isDelete == false).AsQueryable();
            //if ( BookId > 0)
            //{
            //    rentals = rentals.Where(b => b.BookId.ToString().ToLower().Contains(model.BookId.ToString().ToLower()));
            //}
            return rentals.ToList();
        }
    }
}
