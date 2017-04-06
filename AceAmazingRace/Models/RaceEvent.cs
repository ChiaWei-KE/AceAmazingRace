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

        public string GetHoursDisplay()
        {
            var hour = Time / 60;
            if (hour > 12) hour -= 12;
            return $"{hour:00}";
        }

        public string GetMinutesDisplay()
        {
            return $"{(Time % 60):00}";
        }

        public string GetPeriodDisplay()
        {
            var hour = Time / 60;
            if (hour <= 12)
                return PeriodBeforeMidday;
            else
                return PeriodAfterMidday;
        }

        public string GetTimeDisplay()
        {
            return $"{GetHoursDisplay()}:{GetMinutesDisplay()} {GetPeriodDisplay()}";
        }
    }
}