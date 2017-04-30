using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AceAmazingRace.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using AceAmazingRace.ViewModels;
using System.Data.Entity.Validation;
using System.IO;

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

            ViewBag.RaceEvent = "class = active";
            return View("Index", viewModel);
        }

        public ActionResult Create(int eventId)
        {
            ViewBag.RaceEvent = "class = active";
            return View("Details", new TeamViewModel()
            {
                PitStops = _context.PitStops.Where(x => x.RaceEvent.Id == eventId).ToList(),
                UserAction = "Create",
                RaceEventId = eventId
            });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.RaceEvent = "class = active";
            var team = _context.Teams.FirstOrDefault(x => x.Id == id);
            if(team == null) return HttpNotFound();

            return View("Details", new TeamViewModel()
            {
                Team = team,
                UserAction = "Edit",
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
        public ActionResult Save(TeamViewModel viewModel, HttpPostedFileBase teamPhoto)
        {
            int eventId = viewModel.RaceEventId;
            string userAction = viewModel.UserAction;

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid)
            {
                var reValidation = !string.IsNullOrEmpty(viewModel.Team.Name) &&
                                   !string.IsNullOrEmpty(viewModel.Team.Profile);
                if (!reValidation)
                {
                    viewModel.UserAction = userAction;
                    viewModel.RaceEventId = eventId;
                    return View("Details", viewModel);
                }
            }

            byte[] imageData = null;
            if (teamPhoto != null )
            {
                using (var binary = new BinaryReader(teamPhoto.InputStream))
                {
                    imageData = binary.ReadBytes(teamPhoto.ContentLength);
                }
                viewModel.Team.Photo = imageData;
            }
            

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
            ViewBag.RaceEvent = "class = active";
            var team = _context.Teams.FirstOrDefault(x => x.Id == id);
            var pitStopOrders = _context.PitStopOrders.Where(x => x.Team.Id == team.Id)
                                                 .OrderBy(x => x.Order)
                                                 .ToList();

            return View("EditOrder", new PitStopOrdersViewModel()
            {
                PitStopOrders = pitStopOrders,
                RaceEventId = team.RaceEvent.Id
            });
        }

        public ActionResult MoveUp(int id)
        {
            var current = _context.PitStopOrders.FirstOrDefault(x => x.Id == id);
            SortPitStop(current.Team.Id);
            var orders = _context.PitStopOrders.Where(x => x.Team.Id == current.Team.Id)
                                               .OrderBy(x => x.Order).ToList();

            if (current.Order > 0)
            {
                for (int i = 1; i < orders.Count; i++)
                {
                    if (orders[i].Id == current.Id)
                    {
                        _context.Database.ExecuteSqlCommand($"UPDATE dbo.PitStopOrders SET [Order] = {i - 1} WHERE Id = {orders[i].Id}");
                        _context.Database.ExecuteSqlCommand($"UPDATE dbo.PitStopOrders SET [Order] = {i} WHERE Id = {orders[i - 1].Id}");
                        break;
                    }
                }
            }

            return RedirectToAction("EditOrder", new {id = current.Team.Id});
        }

        public ActionResult MoveDown(int id)
        {
            var current = _context.PitStopOrders.FirstOrDefault(x => x.Id == id);
            SortPitStop(current.Team.Id);
            var orders = _context.PitStopOrders.Where(x => x.Team.Id == current.Team.Id)
                                               .OrderBy(x => x.Order).ToList();

            if (current.Order < orders.Count - 1)
            {
                for (int i = 0; i <= orders.Count - 1; i++)
                {
                    if (orders[i].Id == current.Id)
                    {
                        _context.Database.ExecuteSqlCommand($"UPDATE dbo.PitStopOrders SET [Order] = {i + 1} WHERE Id = {orders[i].Id}");
                        _context.Database.ExecuteSqlCommand($"UPDATE dbo.PitStopOrders SET [Order] = {i} WHERE Id = {orders[i + 1].Id}");
                        break;
                    }
                }
            }

            return RedirectToAction("EditOrder", new {id = current.Team.Id});
        }

        private void SortPitStop(int teamId)
        {
            var orders = _context.PitStopOrders.Where(x => x.Team.Id == teamId)
                                               .OrderBy(x => x.Order);

           
            var index = 0;
            foreach (var order in orders.ToList())
            {
                order.Order = index++;
            }

            try
            {
              _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);
            }
        }
        
    }
}