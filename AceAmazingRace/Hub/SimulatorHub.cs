using System;
using System.Collections.Generic;
using System.Web;
using AceAmazingRace.ViewModels;
using Microsoft.AspNet.SignalR;
namespace AceAmazingRace.Hub
{
    public class SimulatorHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Send(List<RealTimeData> data)
        {
            Clients.All.sendLiveData(data);
        }

    }
}