﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public List<PitStop> PitStops { get; set; }

        public string Action { get; set; }
        public string RaceEventName { get; set; }
        public int RaceEventId { get; set; }
    }
}