﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models 
{
   public class Student
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Student Identity")]
        public int StudentIdentity { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Department Department { get; set; }

        public bool isDelete { get; set; }
        ICollection<Rental> Rentals { get; set; }
    }
}
