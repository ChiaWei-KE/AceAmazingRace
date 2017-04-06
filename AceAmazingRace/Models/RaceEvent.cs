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
        public const string PeriodBeforeMidday = "AM";
        public const string PeriodAfterMidday = "PM";

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Location {get; set;}

        public string DateAndTimeDisplay => $"{Date: dd-MMM-yyyy} {Time}";
    }
}