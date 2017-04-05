using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AceAmazingRace.Models
{
    public class RaceEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Time { get; set; }
        [Required]
        public Location Location {get; set;}

        public string DateAndTime() => $"{Date:dd-MMM-yyyy} {Get24Hours()}";
        public string Get24Hours() => $"{Time / 60:00}:{Time % 60:00} {((Time / 60) >= 12 ? "PM" : "AM")}";
    }
}