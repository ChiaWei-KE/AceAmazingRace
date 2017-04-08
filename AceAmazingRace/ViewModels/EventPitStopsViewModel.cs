using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class EventPitStopsViewModel
    {
        public RaceEvent RaceEvent { get; set; }
        public List<PitStop> PitStops { get; set; }

        public string Action { get; set; }
        public string RaceEventName { get; set; }
    }
}