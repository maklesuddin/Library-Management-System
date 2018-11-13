using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LMSDatabase
{
  public class DbContextLms:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Department> Departments { get; set; } 
    }
}
