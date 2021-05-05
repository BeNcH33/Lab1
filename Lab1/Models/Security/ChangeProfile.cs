using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class ChangeProfile
    {
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
    }
}