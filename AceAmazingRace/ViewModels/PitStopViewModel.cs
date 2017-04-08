using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class PitStopViewModel
    {
        public RaceEvent RaceEvent { get; set; }
        public string Action { get; set; }
        public List<PitStop> PitStops { get; set; }
    }
}