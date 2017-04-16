using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace AceAmazingRace.Hub
{
    public class SimulatorHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Send()
        {
            Clients.All.printJson();
        }
    }
}