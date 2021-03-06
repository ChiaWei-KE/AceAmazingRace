﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class EventTeamsViewModel
    {
        public RaceEvent RaceEvent { get; set; }
        public List<Team> Teams { get; set; }

        public string Action { get; set; }
        public string RaceEventName { get; set; }
    }
}