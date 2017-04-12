using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class LiveEventsViewModel
    {
        public RaceEvent RaceEvent { get; set; }
        public List<PitStop> PitStops { get; set; }
        public List<SupportStop> SupportStops { get; set; }

    }
}