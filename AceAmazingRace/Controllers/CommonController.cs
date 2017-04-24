using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AceAmazingRace.Models;
using System.Data.Entity;
using AceAmazingRace.Hub;
using AceAmazingRace.ViewModels;
using Microsoft.AspNet.SignalR;

namespace AceAmazingRace.Controllers
{
    [RoutePrefix("api/common")]
    public class CommonController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CommonController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        [Route("liveData")]
        public IHttpActionResult LiveData()
        {
            var result = new
            {
                Events = _context.RaceEvents.ToList(),
                PitStops = _context.PitStops.ToList(),
                SupportStops = _context.SupportStops.ToList(),
                Teams = _context.Teams.Select(t => new
                {
                    Team = t,
                    PitStops = _context.PitStopOrders.Where(x => x.Team.Id == t.Id).OrderBy(x => x.Order)
                })
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("simulate")]
        public IHttpActionResult Simulator(List<RealTimeData> datas)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SimulatorHub>();
            if (hubContext != null)
            {
                hubContext.Clients.All.sendLiveData(datas);
            }
            return Ok(datas);
        }
    }
}
