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
        public int Time { get; set; }
        [Required]
        public string Location {get; set;}

        public void UpdateTime(int hours, int minutes, string periods)
        {
            if (periods == PeriodBeforeMidday)
                Time = hours * 60 + minutes;
            else if (periods == PeriodAfterMidday)
                Time = 12 * 60 + hours * 60 + minutes;
        }

        public string DateAndTime()
        {
            return $"{Date:dd-MMM-yyyy} {GetTimeDisplay()}";
        } 

        private string GetTimeDisplay()
        {
            var hours = Time / 60;
            var minutes = Time % 60;
            var period = PeriodBeforeMidday;

            if (hours >= 12)
            {
                hours -= 12;
                period = PeriodAfterMidday;
            }

            return $"{hours:00}:{minutes:00} {period}";
        }
    }
}