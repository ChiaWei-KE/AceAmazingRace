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

            ViewBag.RaceEvent = "class = active";
            return View("Index", viewModel);
        }

        public ActionResult Create(int eventId)
        {
            ViewBag.RaceEvent = "class = active";
            return View("Details", new PitStopViewModel()
            {
                Locations = _context.Locations.OrderBy(x => x.Name).ToList(),
                UserAction = "Create",
                RaceEventId = eventId
            });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.RaceEvent = "class = active";
            var pitStop = _context.PitStops.FirstOrDefault(x => x.Id == id);
            if(pitStop == null) return HttpNotFound();

            return View("Details", new PitStopViewModel()
            {
                PitStop = pitStop,
                LocationId = pitStop.Location.Id,
                Locations = _context.Locations.OrderBy(x => x.Name).ToList(),
                UserAction = "Edit",
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
        public ActionResult Save(PitStopViewModel viewModel, int eventId, string userAction)
        {
            if (!ModelState.IsValid)
            {
                var reValidation = !string.IsNullOrEmpty(viewModel.PitStop.Name) &&
                                   viewModel.LocationId > 0;

                if (!reValidation)
                {
                    viewModel.UserAction = userAction;
                    viewModel.Locations = _context.Locations.OrderBy(x => x.Name).ToList();
                    viewModel.RaceEventId = eventId;
                    return View("Details", viewModel);
                }
            }

            var location = _context.Locations.FirstOrDefault(x => x.Id == viewModel.LocationId);
            var raceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == eventId);

            //Update pitStop
            var pitStop = viewModel.PitStop;
            pitStop.Location = location;
            pitStop.RaceEvent = raceEvent;

            _context.PitStops.AddOrUpdate(pitStop);

            //Update pitStopOrder
            int maxIndex;

            if (_context.PitStopOrders.Any(x => x.PitStop.RaceEvent.Id == raceEvent.Id))
                maxIndex = _context.PitStopOrders
                            .Where(x => x.PitStop.RaceEvent.Id == raceEvent.Id)
                            .Max(x => x.Order);
            else
                maxIndex = -1;

            var pitStopOrders = _context.Teams
                    .Where(x => x.RaceEvent.Id == pitStop.RaceEvent.Id)
                    .ToList()
                    .Select(x => new PitStopOrder()
                    {
                        PitStop = pitStop,
                        Team = x,
                        Order = maxIndex + 1
                    });

            foreach (var pitStopOrder in pitStopOrders)
                _context.PitStopOrders.Add(pitStopOrder);

            _context.SaveChanges();

            return RedirectToAction("Index", "PitStop", new {id = eventId});
        }
    }
}