using System.Collections.Generic;
using AceAmazingRace.Models;

namespace AceAmazingRace.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.GenerateRaceEvents();
            context.GenerateLocations();
            context.GeneratePitStops();
            context.GenerateTeams();
            context.GeneratePitStopOrders();
        }
    }

    public static class SeedData
    {
        private static void AddorUpdateRange<T>(DbSet<T> db, List<T> items) where T : class
        {
            foreach (var item in items)
                db.AddOrUpdate(item);
        }

        public static void GenerateLocations(this ApplicationDbContext context)
        {
            AddorUpdateRange(context.Locations, new List<Location>()
            {
                new Location() {Id = 1, Name = "Bugis - Salon Vim", Address = "235 Victoria St, Singapore 188027", Latitude = 1.300029, Longitude = 103.855058},
                new Location() {Id = 2, Name = "Bugis - Land Transport Authority", Address = "750 Victoria St, Singapore 188062", Latitude = 1.300753, Longitude = 103.856267},
                new Location() {Id = 3, Name = "Bugis - KOI Café", Address = "201 Victoria St, Singapore 188067", Latitude = 1.299129, Longitude = 103.854168},
                new Location() {Id = 4, Name = "Bugis - Bugis Cube", Address = "470 North Bridge Rd, Singapore 408936", Latitude = 1.298154, Longitude = 103.855611},
                new Location() {Id = 5, Name = "Bugis - National Library", Address = "100 Victoria St, Singapore 188064", Latitude = 1.297542, Longitude = 103.854216},
            });

            context.SaveChanges();
        }

        public static void GenerateRaceEvents(this ApplicationDbContext context)
        {
            AddorUpdateRange(context.RaceEvents, new List<RaceEvent>()
            {
                new RaceEvent()
                {
                    Id = 1,
                    Name = "Marina Run",
                    Date = new DateTime(2017, 5, 10),
                    Description = "Bring your family in!!! Fun and challenge amazing races forever. First runner will have voucher of Takashimaya worth SGD500.",
                    Location = "Marina Bay (5 minutes walking distance from MRT station)",
                    Time = "10:00am"
                },
                new RaceEvent()
                {
                    Id = 2,
                    Name = "Bugis Fun Chase",
                    Date = new DateTime(2017, 6, 29),
                    Description = "Are you ready for the biggest amazing run challenge ever in Bugis Area? Attractive prizes are waiting for you!!! ",
                    Location = "Bugis Junction (In front of fountain)",
                    Time = "1:30pm"
                }
            });

            context.SaveChanges();
        }

        public static void GeneratePitStops(this ApplicationDbContext context)
        {
            AddorUpdateRange(context.PitStops, new List<PitStop>()
            {
                new PitStop() { Id =1, Name = "BGS01", Location = context.Locations.Find(1), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =2, Name = "BGS02", Location = context.Locations.Find(2), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =3, Name = "BGS03", Location = context.Locations.Find(3), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =4, Name = "BGS04", Location = context.Locations.Find(4), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =5, Name = "BGS05", Location = context.Locations.Find(5), RaceEvent = context.RaceEvents.Find(2)}
            });

            context.SaveChanges();
        }

        public static void GenerateTeams(this ApplicationDbContext context)
        {
            AddorUpdateRange(context.Teams, new List<Team>()
            {
                new Team() {Id = 1, Name = "Bugis Team A", Profile = "We are engineering students from NTU and enjoy challenges.", RaceEvent = context.RaceEvents.Find(2)},
                new Team() {Id = 2, Name = "Bugis Team B", Profile = "Multinational team from South East Asia countries. ABCD from our names Alice, Byran, Cathy, Daniel!!!", RaceEvent = context.RaceEvents.Find(2)},
                new Team() {Id = 3, Name = "Bugis Team C", Profile = "Family of 4 members, amazing race is great!", RaceEvent = context.RaceEvents.Find(2)}
            });

            context.SaveChanges();
        }

        public static void GeneratePitStopOrders(this ApplicationDbContext context)
        {
            var id = 1;
            var pitStopOrders = new List<PitStopOrder>();
            var raceEvents = context.RaceEvents.ToList();

            foreach (var raceEvent in raceEvents)
            {
                var teams = context.Teams.Where(x => x.RaceEvent.Id == raceEvent.Id).ToList();
                var pitStops = context.PitStops.Where(x => x.RaceEvent.Id == raceEvent.Id).ToList();

                foreach (var team in teams)
                {
                    var order = 0;
                    foreach (var pitStop in pitStops)
                    {
                        pitStopOrders.Add(new PitStopOrder() {Id = id, Order = order, PitStop = pitStop, Team = team});
                        id++;
                        order++;
                    }
                }
            }

            AddorUpdateRange(context.PitStopOrders, pitStopOrders);
            context.SaveChanges();
        }
    }
}
