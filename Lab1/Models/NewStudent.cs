using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class NewStudent
    {
        public int ID { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]
        public string Otch { get; set; }
        [Display(Name = "Серия паспорта")]
        public int PasportSer { get; set; }
        [Display(Name = "Номер паспорта")]
        public int PasportNumber { get; set; }
        [Display(Name = "Номер зачетной книжки")]
        public int ZachetNumber { get; set; }
        [Display(Name = "Пол")]
        public string Sex { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Родной город")]
        public string Town { get; set; }
    }
}
