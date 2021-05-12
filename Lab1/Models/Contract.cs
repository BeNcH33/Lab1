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
        public int number { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateIn { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOut { get; set; }
        public int Cost { get; set; }

    }
}