﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelView
{
   public class LanguageVm
    {
       
        public int Id { get; set; }

        [Required]
        [Display(Name = "Language")]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool isDelete { get; set; }

       private ICollection<Book> Books { get; set; }
    }
}
