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
        [DataType(DataType.Date)]
        [Display(Name = "Дата совершения")]
        public DateTime Date { get; set; }
        [Display(Name = "Идентификатор студента")]
        public int IdStudent { get; set; }
        [Display(Name = "Идентификатор нарушения")]
        public int IdViolation { get; set; }
    }
}