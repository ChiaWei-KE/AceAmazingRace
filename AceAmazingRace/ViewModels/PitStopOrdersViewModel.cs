using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AceAmazingRace.Models;

namespace AceAmazingRace.ViewModels
{
    public class PitStopOrdersViewModel
    {
        public List<PitStopOrder> PitStopOrders { get; set; }

        public int RaceEventId { get; set; }
    }
}