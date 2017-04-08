using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AceAmazingRace.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set;}
        
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }

        public string Clue { get; set; }
    }
}