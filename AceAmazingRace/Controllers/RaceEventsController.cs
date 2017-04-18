using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AceAmazingRace.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using AceAmazingRace.ViewModels;

namespace AceAmazingRace.Controllers
{
    public class RaceEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceEventsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var events = _context.RaceEvents.OrderByDescending(x => x.Date)
                .ThenBy(x => x.Time)
                .Select(x => new RaceEventViewModel()
                {
                   RaceEvent = x,
                   PitStops = _context.PitStops.Where(y => y.RaceEvent.Id == x.Id).ToList(),
                   Teams = _context.Teams.Where(y => y.RaceEvent.Id == x.Id).ToList()
                })
                .ToList();

            ViewBag.RaceEvent = "class = active";
            return View("Index", events);
        }

        public ActionResult Create()
        {
            ViewBag.RaceEvent = "class = active";
            return View("Details", new RaceEventViewModel() {UserAction = "Create"});
        }

        public ActionResult Delete(int id)
        {
            var raceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == id);
            if (raceEvent == null) return HttpNotFound();
            var raceEventId = raceEvent.Id;

            _context.Database.ExecuteSqlCommand($"DELETE FROM dbo.Teams WHERE RaceEvent_Id = {raceEventId}");
            _context.Database.ExecuteSqlCommand($"DELETE FROM dbo.PitStops WHERE RaceEvent_Id = {raceEventId}");
            _context.Database.ExecuteSqlCommand($"DELETE FROM dbo.RaceEvents WHERE Id = {raceEventId}");

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var raceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == id);
            if(raceEvent == null) return HttpNotFound();

            var viewModel = new RaceEventViewModel()
            {
                RaceEvent = raceEvent,
                UserAction = "Edit"
            };

            ViewBag.RaceEvent = "class = active";
            return View("Details", viewModel);
        }

        [HttpPost]
        public ActionResult Save(RaceEventViewModel viewModel, string userAction)
        {
            if (!ModelState.IsValid)
            {
                viewModel.UserAction = userAction;
                return View("Details", viewModel);
            }

            var raceEvent = viewModel.RaceEvent;

            _context.RaceEvents.AddOrUpdate(raceEvent);
            _context.SaveChanges();

            return RedirectToAction("Index", "RaceEvents");
        }
    }
}