using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class LeaveRooms
    {
        public int ID { get; set; }
        [Display(Name = "Номер комнаты")]
        public int NumberRoom { get; set; }
        [Display(Name = "Номер этажа")]
        public int NumberFloor { get; set; }
        [Display(Name = "Количество мест")]
        public int Count { get; set; }
    }
}