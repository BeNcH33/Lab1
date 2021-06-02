using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Contract
    {
        public int ID { get; set; }
        [Display(Name = "Номер")]
        public int number { get; set; }
        [Display(Name = "Идентификатор студента")]
        public int NewStudentID { get; set; }
        [Display(Name = "Идентификатор комнаты")]
        public int NewRoomID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата въезда")]
        public DateTime DateIn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата выезда")]
        public DateTime DateOut { get; set; }
        [Display(Name = "Стоимость")]
        public int Cost { get; set; }

    }
}