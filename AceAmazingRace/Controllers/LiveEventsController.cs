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
            ViewBag.LiveEvent = "class = active";
            return View("Index");
        }
    }
}