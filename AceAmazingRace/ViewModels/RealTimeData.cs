using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AceAmazingRace.ViewModels
{
    public class RealTimeData
    {
        public int TeamIndex { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public RealTimeData(int teamIndex, double latitude, double longitude)
        {
            TeamIndex = teamIndex;
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public class RealTimeManageData
    {
        public List<RealTimeData> LiveData { get; set; }
        public bool ResetGame { get; set; }
        public string Secret { get; set; }
    }
}