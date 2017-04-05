using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AceAmazingRace.Models;
using System.Data.Entity;

namespace AceAmazingRace.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;

        public EventsController()
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

            return View(events);
        }

        [HttpPost]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Edit(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}