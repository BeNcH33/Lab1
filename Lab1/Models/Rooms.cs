using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Rooms
    {
        public int ID { get; set; }
        [Display(Name = "Этаж")]
        public int floor { get; set; }
        [Display(Name = "Название помещения")]
        public string NameRoom { get; set; }
        [Display(Name = "Номер помещения")]
        public int NumberRoom { get; set; }

    }
    public class RoomsDBContext : DbContext
    {
        public DbSet<Rooms> Rooms { get; set; }

        public System.Data.Entity.DbSet<Lab1.Models.Contract> Contracts { get; set; }

        public System.Data.Entity.DbSet<Lab1.Models.NewStudent> NewStudents { get; set; }

        public System.Data.Entity.DbSet<Lab1.Models.Violation> Violations { get; set; }

        public System.Data.Entity.DbSet<Lab1.Models.ViolationContent> ViolationContents { get; set; }

        public System.Data.Entity.DbSet<Lab1.Models.LeaveRooms> LeaveRooms { get; set; }
    }
}