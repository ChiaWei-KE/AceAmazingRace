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
        public ActionResult Index(int Id)
        {
            var viewModel = new PitStopViewModel()
            {
                RaceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == Id),
                PitStops = _context.PitStops.Where(x => x.RaceEvent.Id == Id).ToList()
            };

            return View("Index", viewModel);
        }
    }
}