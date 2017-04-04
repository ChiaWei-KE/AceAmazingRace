using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AceAmazingRace.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set;}
        public string Instruction { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}