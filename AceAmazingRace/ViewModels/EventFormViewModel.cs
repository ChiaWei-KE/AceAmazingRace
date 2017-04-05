using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class EventFormViewModel
    {
        public RaceEvent RaceEvent { get; set; }
        public List<Location> Locations {get; set;}
        public int LocationId {get; set;}
    }
}