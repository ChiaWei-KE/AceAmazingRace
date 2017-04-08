using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AceAmazingRace.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using AceAmazingRace.ViewModels;

namespace AceAmazingRace.Controllers
{
    public class PitStopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PitStopController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: PitStop
        public ActionResult Index(int id)
        {
            var raceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == id);
            var pitStops = _context.PitStops.Where(x => x.RaceEvent.Id == id).ToList();

            var viewModel = new EventPitStopsViewModel()
            {
                RaceEvent = raceEvent,
                PitStops = pitStops,
                RaceEventName = raceEvent.Name
            };

            return View("Index", viewModel);
        }

        public ActionResult Create(int eventId)
        {
            return View("Details", new PitStopViewModel()
            {
                Locations = _context.Locations.OrderBy(x => x.Name).ToList(),
                Action = "Create",
                RaceEventId = eventId
            });
        }

        public ActionResult Edit(int id)
        {
            var pitStop = _context.PitStops.FirstOrDefault(x => x.Id == id);
            if(pitStop == null) return HttpNotFound();

            return View("Details", new PitStopViewModel()
            {
                PitStop = pitStop,
                LocationId = pitStop.Location.Id,
                Locations = _context.Locations.OrderBy(x => x.Name).ToList(),
                Action = "Edit",
                RaceEventId = pitStop.RaceEvent.Id
            });
        }

        public ActionResult Delete(int id)
        {
            var pitStop = _context.PitStops.FirstOrDefault(x => x.Id == id);
            var eventId = pitStop.RaceEvent.Id;
            if (pitStop == null) return HttpNotFound();

            _context.PitStops.Remove(pitStop);
            _context.SaveChanges();

            return RedirectToAction("Index", new {id = eventId});
        }

        [HttpPost]
        public ActionResult Save(PitStopViewModel viewModel, int eventId)
        {
            var location = _context.Locations.FirstOrDefault(x => x.Id == viewModel.LocationId);
            var raceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == eventId);

            var pitStop = viewModel.PitStop;
            pitStop.Location = location;
            pitStop.RaceEvent = raceEvent;

            _context.PitStops.AddOrUpdate(pitStop);
            _context.SaveChanges();

            return RedirectToAction("Index", "PitStop", new {id = eventId});
        }

        public ActionResult MoveUp(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult MoveDown(int id)
        {
            throw new NotImplementedException();
        }
    }
}