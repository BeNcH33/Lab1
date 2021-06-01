using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class ViolationContent
    {
        public int ID { get; set; }
        [Display(Name = "Название нарушения")]
        public string name { get; set; }
        [Display(Name = "Описание нарушения")]
        public string description { get; set; }
        [Display(Name = "Наказание")]
        public string Penalties { get; set; }
    }
}