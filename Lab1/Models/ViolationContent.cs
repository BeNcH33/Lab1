using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class ViolationContent
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string Penalties { get; set; }
    }
}