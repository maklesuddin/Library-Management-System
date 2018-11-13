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
   public class RentalManager
    {
       RentalRepository _rentalRepository=new RentalRepository();
        public bool Add(Rental rental)
        {
            return _rentalRepository.Add(rental);
        }

        public bool Update(Rental rental)
        {
            return _rentalRepository.Update(rental);
        }

        public bool Delete(int id)
        {
            return _rentalRepository.Delete(id);
        }

        public Rental GetById(int id)
        {
            return _rentalRepository.GetById(id);
        }

        public List<Rental> GetAllRental()
        {
            return _rentalRepository.GetAllRental();
        }

        public List<Book> GetAllBooks()
        {
            return _rentalRepository.GetAllBooks();
        }

        public List<Student> GetAllStudent()
        {
            return _rentalRepository.GetAllStudent();
        }
        public List<Librarian> GetAllLibrarian()
        {
            return _rentalRepository.GetAllLibrarian();
        }
        public List<Rental> GetRentalBySearch(RentalSearchCriteria model)
        {
            return _rentalRepository.GetRentalBySearch(model);
        }
    }
}
