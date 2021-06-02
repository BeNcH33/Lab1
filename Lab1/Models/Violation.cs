using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Violation
    {
        public int ID { get; set; }
        [Display(Name = "Название нарушения")]
        public string category { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата совершения")]
        public DateTime Date { get; set; }
        public int IdStudent { get; set; }
    }
}