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
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Team
        public ActionResult Index(int id)
        {
            var raceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == id);
            var teams = _context.Teams.Where(x => x.RaceEvent.Id == id).ToList();

            var viewModel = new EventTeamsViewModel()
            {
                RaceEvent = raceEvent,
                RaceEventName = raceEvent.Name,
                Teams = teams
            };

            return View("Index", viewModel);
        }

        public ActionResult Create(int eventId)
        {
            return View("Details", new TeamViewModel()
            {
                PitStops = _context.PitStops.Where(x => x.RaceEvent.Id == eventId).ToList(),
                Action = "Create",
                RaceEventId = eventId
            });
        }

        public ActionResult Edit(int id)
        {
            var team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if(team == null) return HttpNotFound();

            return View("Details", new TeamViewModel()
            {
                Team = team,
                Action = "Edit",
                RaceEventId = team.RaceEvent.Id,
                PitStops = _context.PitStops.Where(x => x.RaceEvent.Id == team.RaceEvent.Id).ToList(),
            });
        }

        public ActionResult Delete(int id)
        {
            var team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null) return HttpNotFound();
            var eventId = team.RaceEvent.Id;
            var orders = _context.PitStopOrders.Where(x => x.Team.Id == team.Id);
            
            //Remove team and corresponding team records in pitStopOrders
            _context.Teams.Remove(team);
            _context.PitStopOrders.RemoveRange(orders);
            _context.SaveChanges();

            return RedirectToAction("Index", new {id = eventId});
        }

        [HttpPost]
        public ActionResult Save(TeamViewModel viewModel, int eventId)
        {
            var raceEvent = _context.RaceEvents.FirstOrDefault(x => x.Id == eventId);

            var team = viewModel.Team;
            team.RaceEvent = raceEvent;

            _context.Teams.AddOrUpdate(team);
            _context.SaveChanges();

            //After save team, update orders
            if (!_context.PitStopOrders.Any(x => x.Team.Id == team.Id))
            {
                var pitStopOrders =  _context.PitStops.Where(x => x.RaceEvent.Id == eventId).ToList()
                            .Select((x, i) => new PitStopOrder()
                            {
                                Team = team,
                                PitStop = x,
                                Order = i
                            });

                _context.PitStopOrders.AddRange(pitStopOrders);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Team", new {id = eventId});
        }

        public ActionResult EditOrder(int id)
        {
            var team = _context.Teams.FirstOrDefault(x => x.Id == id);
            var pitStops = _context.PitStopOrders.Where(x => x.Team.Id == team.Id).Select(x => x.PitStop).ToList();

            return View("EditOrder", new TeamViewModel()
            {
                PitStops =pitStops,
                RaceEventId = team.RaceEvent.Id
            });
        }
    }
}