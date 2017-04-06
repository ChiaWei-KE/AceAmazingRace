using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AceAmazingRace.Models;
using System.Data.Entity;

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
            return View("Create", new RaceEvent());
        }

        public ActionResult Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Edit(string id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public ActionResult CreateNew(RaceEvent raceEvent)
        {
            _context.RaceEvents.Add(raceEvent);
            _context.SaveChanges();

            return RedirectToAction("Index", "RaceEvents");
        }
    }
}