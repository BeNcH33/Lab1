using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Rooms
    {
        public int ID { get; set; }
        public int floor { get; set; }
        public string NameRoom { get; set; }
        public int NumberRoom { get; set; }

    }
    public class RoomsDBContext : DbContext
    {
        public DbSet<Rooms> Rooms { get; set; }
    }
}