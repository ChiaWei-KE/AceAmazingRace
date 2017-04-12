using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AceAmazingRace.Models;
using System.Data.Entity;
using AceAmazingRace.ViewModels;

namespace AceAmazingRace.Controllers
{
    public class LiveEventsController : Controller
    {
         private readonly ApplicationDbContext _context;

        public LiveEventsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            //Todo Temporarily select event with data

            var raceEvent = _context.RaceEvents.Find(2);
            var pitStops = _context.PitStops.Where(x => x.RaceEvent.Id == raceEvent.Id).ToList();
            var supportStops = _context.SupportStops.Where(x => x.RaceEvent.Id == raceEvent.Id).ToList();

            var viewModel = new LiveEventsViewModel()
            {
                RaceEvent = raceEvent,
                PitStops = pitStops,
                SupportStops = supportStops
            };

            return View("Index", viewModel);
        }

        public ActionResult PitStops(int eventId)
        {
            return Json(_context.PitStops.Where(x => x.RaceEvent.Id == eventId).ToList());
        }
    }
}