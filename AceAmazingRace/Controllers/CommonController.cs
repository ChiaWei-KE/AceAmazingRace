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
        [Route("events")]
        public IHttpActionResult Events()
        {
            return Ok(_context.RaceEvents.ToList());
        }

        [HttpGet]
        [Route("pitStops")]
        public IHttpActionResult PitStops()
        {
            return Ok(_context.PitStops.ToList());
        }

        [HttpGet]
        [Route("supportStops")]
        public IHttpActionResult SupportStops()
        {
            return Ok(_context.SupportStops.ToList());
        }
    }
}
