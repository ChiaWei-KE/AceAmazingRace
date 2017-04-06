using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class RaceEventViewModel
    {
        public RaceEvent RaceEvent { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
        public string Periods { get; set; }
        public string Action { get; set; }
    }
}