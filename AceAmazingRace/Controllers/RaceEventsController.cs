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
            var events = _context.Events.Include(x => x.Location).OrderByDescending(x => x.Date).ToList();

            return View("Index", events);
        }

        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel()
            {
                Locations = _context.Locations.ToList()
            };

            return View("Create", viewModel);
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
        public ActionResult CreateNew(EventFormViewModel viewModel)
        {
            var location =  _context.Locations.FirstOrDefault(x => x.Id == viewModel.LocationId);
            var @event = viewModel.RaceEvent;
            @event.Location = location;

            _context.Events.Add(@event);
            _context.SaveChanges();

            return RedirectToAction("Index", "RaceEvents");
        }
    }
}