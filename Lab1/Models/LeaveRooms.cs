using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class LeaveRooms
    {
        public int ID { get; set; }
        public int NumberRoom { get; set; }
        public int NumberFloor { get; set; }
        public int Count { get; set; }
    }
    public class LeaveRoomsDBContext : DbContext
    {
        public DbSet<LeaveRooms> Rooms { get; set; }
    }
}