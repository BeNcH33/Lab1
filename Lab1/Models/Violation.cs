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
        public string category { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
    public class ViolationDBContext : DbContext
    {
        public DbSet<Violation> Violations { get; set; }

        public System.Data.Entity.DbSet<Lab1.Models.ViolationContent> ViolationContents { get; set; }
    }
}