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
            context.GenerateLocations();
        }
    }

    public static class SeedData
    {
        public static void GenerateLocations(this ApplicationDbContext context)
        {
            var locations = new List<Location>()
            {
                new Location() {Id = 1, Name = "Orchard Road", Address = "230 Orchard Rd, Singapore", Latitude = 1.3016514, Longitude = 103.8380588},
                new Location() {Id = 2, Name = "Bugis Street", Address = "1 New Bugis St, Singapore 188865", Latitude = 1.300599, Longitude = 103.854892999999},
                new Location() {Id = 3, Name = "Plaza Singapura", Address = "Handy Rd, Singapore", Latitude = 1.3010224, Longitude = 103.8453078},
                new Location() {Id = 4, Name = "Peace Center", Address = "1 Sophia Rd, Singapore 228149", Latitude = 1.301242, Longitude = 103.849608999999},
                new Location() {Id = 5, Name = "The Cathay", Address = "2 Handy Rd, Former Cathay Building, Singapore 229233", Latitude = 1.299414, Longitude = 103.847643999999},
                new Location() {Id = 6, Name = "Concorde Hotel", Address = "100 Orchard Rd, Singapore 238840", Latitude = 1.300525, Longitude = 103.842164599999},
            };

            foreach (var location in locations)
                context.Locations.AddOrUpdate(location);

            context.SaveChanges();
        }
    }
}
