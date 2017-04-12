using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AceAmazingRace.Models;
using System.Data.Entity;

namespace AceAmazingRace.Controllers
{
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
        [Route("api/pitStops/{eventId}")]
        public IHttpActionResult PitStops(int eventId)
        {
            return Ok(_context.PitStops.Where(x => x.RaceEvent.Id == eventId).ToList());
        }
    }
}
