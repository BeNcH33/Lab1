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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Otch { get; set; }
        public int PasportSer { get; set; }
        public int PasportNumber { get; set; }
        public int ZachetNumber { get; set; }
        public string Sex { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string Town { get; set; }
    }
    public class StudentDBContext : DbContext
    {
        public DbSet<NewStudent> Students { get; set; }
    }
}
