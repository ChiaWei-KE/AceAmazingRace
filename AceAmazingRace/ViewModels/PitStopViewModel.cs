using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class PitStopViewModel
    {
        public PitStop PitStop { get; set; }
        public List<Location> Locations { get; set; }

        public string UserAction { get; set; }
        public int LocationId { get; set; }
        public int RaceEventId { get; set; }
    }
}