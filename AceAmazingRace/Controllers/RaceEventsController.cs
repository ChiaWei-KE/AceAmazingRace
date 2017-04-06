using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AceAmazingRace.Models;
using System.Data.Entity;
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
            var events = _context.RaceEvents.OrderByDescending(x => x.Date).ToList();

            return View("Index", events);
        }

        public ActionResult Create()
        {
            return View("Create", new RaceEventViewModel());
        }

        public ActionResult Delete(int id)
        {
            var raceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == id);
            if (raceEvent == null) return HttpNotFound();
            _context.RaceEvents.Remove(raceEvent);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public ActionResult CreateNew(RaceEventViewModel viewModel)
        {
            var raceEvent = viewModel.RaceEvent;
            raceEvent.UpdateTime(int.Parse(viewModel.Hours), int.Parse(viewModel.Minutes), viewModel.Periods);

            _context.RaceEvents.Add(raceEvent);
            _context.SaveChanges();

            return RedirectToAction("Index", "RaceEvents");
        }
    }
}