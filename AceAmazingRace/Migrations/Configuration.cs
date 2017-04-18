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
            context.GenerateSupportStops();
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
                new Location() {Id = 3, Name = "Bugis - KOI Caf", Address = "201 Victoria St, Singapore 188067", Latitude = 1.299129, Longitude = 103.854168},
                new Location() {Id = 4, Name = "Bugis - Bugis Cube", Address = "470 North Bridge Rd, Singapore 408936", Latitude = 1.298154, Longitude = 103.855611},
                new Location() {Id = 5, Name = "Bugis - National Library", Address = "100 Victoria St, Singapore 188064", Latitude = 1.297542, Longitude = 103.854216},
                new Location() {Id = 6, Name = "Support - Parco Bugis Junction", Address = "200 Victoria St, Singapore 188021", Latitude = 1.29887, Longitude = 103.85495},
                new Location() {Id = 7, Name = "Support - Bugis Junction", Address = "200 Victoria St, Singapore 188021", Latitude = 1.29982, Longitude = 103.85586},
                new Location() {Id = 8, Name = "Bukit Panjiang - Bukit Panjiang Plaza", Address = "1 Jelebu Road, Singapore 677743 ", Latitude = 1.379944, Longitude = 103.764293},
                new Location() {Id = 9, Name = "Bukit Panjiang - Redline-Racing", Address = "Block 179, Lompang Road, #16-26, Singapore 670179 ", Latitude = 1.379882, Longitude = 103.765125},
                new Location() {Id = 10, Name = "Bukit Panjiang - Kems (Singapore) Pte Ltd", Address = "80 Lompang Rd, Singapore 670180", Latitude = 1.379063, Longitude = 103.764860},
                new Location() {Id = 11, Name = "Bukit Panjiang - PCF Sparkletots Childcare Centre", Address = "183 Jelebu Rd, Singapore 670183 ", Latitude = 1.379968, Longitude = 103.763102},
                new Location() {Id = 12, Name = "Bukit Panjiang - Masaru Marketing & Services", Address = "166 Gangsa Rd, Singapore 670166 ", Latitude = 1.377626, Longitude = 103.765452},
                new Location() {Id = 13, Name = "Support - Block 177 HDB Lompang", Address = "177 Lompang Rd, Singapore 670177", Latitude = 1.380222, Longitude = 103.765231},
                new Location() {Id = 14, Name = "Support - Sherwood Educare Pte", Address = "167 Petir Rd, Singapore 670167", Latitude = 1.377543, Longitude = 103.764646},
                new Location() {Id = 15, Name = "Sentosa - Adventure Cove Waterpark", Address = "8 Sentosa Gateway, Resorts World Sentosa, 098269", Latitude = 1.258050, Longitude = 103.820842},
                new Location() {Id = 16, Name = "Sentosa - Tiger Sky Tower", Address = "41 Imbiah Road, Sentosa Island, 099707", Latitude = 1.254972, Longitude = 103.817612},
                new Location() {Id = 17, Name = "Sentosa - Universal Studios Singapore", Address = "8 Sentosa Gateway, 098269", Latitude = 1.254037, Longitude = 103.823819},
                new Location() {Id = 18, Name = "Sentosa - Skyline Luge", Address = "45 Siloso Beach Walk, Sentosa, Resorts World Sentosa, 099003", Latitude = 1.251942, Longitude = 103.816946},
                new Location() {Id = 19, Name = "Sentosa - Palawan Beach", Address = "Sentosa Island, Singapore 099981", Latitude = 1.248307, Longitude = 103.822553},
                new Location() {Id = 20, Name = "Support - Chili¡¯s Resorts World Sentosa", Address = "#01-072/073/074, 26 Sentosa Gateway, Resorts World Sentosa, Singapore 098138", Latitude = 1.256206, Longitude = 103.821229},
                new Location() {Id = 21, Name = "Support - Bora Bora", Address = "Palawan Beach Walk Singapore 098236", Latitude = 1.249356, Longitude = 103.822027},
                new Location() {Id = 22, Name = "Orchard - The Gallery", Address = "181,#04-29 Orchard Rd, Orchard Central, Singapore 238896", Latitude = 1.300722, Longitude = 103.839441},
                new Location() {Id = 23, Name = "Orchard - Goldheart Jewelry - The Centrepoint", Address = "176 Orchard Rd, The Centrepoint, Singapore 238843", Latitude = 1.301608, Longitude = 103.839767},
                new Location() {Id = 24, Name = "Orchard - Candy Empire 313", Address = "313 Orchard Rd, Singapore 238895", Latitude = 1.256206, Longitude = 103.821229},
                new Location() {Id = 25, Name = "Orchard - Singapore Visitor Centre", Address = "216 Orchard Road, Singapore 238898", Latitude = 1.301636, Longitude = 103.838859},
                new Location() {Id = 26, Name = "Orchard - Made with Love", Address = "313 Orchard Road, Singapore 238895", Latitude = 1.301255, Longitude = 103.838643},
                new Location() {Id = 27, Name = "Support - Alley Bar", Address = "180 Orchard Road, Peranakan Place, Singapore 238846", Latitude = 1.301401, Longitude = 103.839286},
                new Location() {Id = 28, Name = "Support - Lucky Plaza", Address = "304 Orchard Road, #02-115, Singapore 238863", Latitude = 1.304398, Longitude = 103.833980},
                new Location() {Id = 29, Name = "Marina - Marina Bay Sands",Address="10 Bayfront Avenue, Singapore 018956",Latitude=1.283564,Longitude=103.860693},
                new Location() {Id = 30, Name = "Marina - Singapore Flyer",Address="30 Raffles Ave, Singapore 039803",Latitude=1.289322,Longitude=103.863105},
                new Location() {Id = 31, Name = "Marina - Suntec Convention Centre",Address="1 Raffles Boulevard, Suntec City, Singapore 039593",Latitude=1.293677,Longitude=103.857311},
                new Location() {Id = 32, Name = "Marina - Esplanade Park",Address="Connaught Drive, Singapore 179682",Latitude=1.289514,Longitude=103.853762},
                new Location() {Id = 33, Name = "Marina - The Promontory",Address="11 Marina Blvd, Singapore 018940",Latitude=1.281670,Longitude=103.854037},
                new Location() {Id = 34, Name = "Support - The Float @ Marina Bay", Address = "20 Raffles Ave, Singapore 039805", Latitude = 1.288156, Longitude = 103.859056},
                new Location() {Id = 35, Name = "Support - Merlion", Address = "1 Fullerton Rd, #01-09 One Fullerton, Singapore 049213", Latitude = 1.286810, Longitude = 103.854456},
                new Location() {Id = 36, Name = "NUS - Institute of Systems Science",Address="25 Heng Mui Keng Terrace, Singapore 119615",Latitude=1.292247,Longitude=103.776563},
                new Location() {Id = 37, Name = "NUS - NUS Arts & Social Sciences",Address="5 Arts Link, Block AS7, Level 5 The Shaw Foundation Building, Singapore 117570",Latitude=1.294199,Longitude=103.771110},
                new Location() {Id = 38, Name = "NUS - NUS Museum",Address="50 Kent Ridge Cres, Singapore 119279",Latitude=1.301903,Longitude=103.772451},
                new Location() {Id = 39, Name = "NUS - University Hall",Address="21 Lower Kent Ridge Rd, National University of Singapore, Singapore 119077",Latitude=1.297152,Longitude=103.777708},
                new Location() {Id = 40, Name = "NUS - NUH Medical Centre",Address="301 S Buona Vista Rd, Singapore 118177",Latitude=1.293430,Longitude=103.784467},
                new Location() {Id = 41, Name = "Support - S15 Quantum Technologies", Address = "National University of Singapore, Block S15, 3 Science Drive 2, Singapore 117543", Latitude = 1.297184, Longitude = 103.780304},
                new Location() {Id = 42, Name = "Support - Yusof Ishak House", Address = "31 Lower Kent Ridge Rd, Singapore 119078", Latitude = 1.298496, Longitude = 103.774787},

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
                    Name = "Bugis Fun Chase",
                    Date = new DateTime(2017, 5, 5),
                    Description = "Are you ready for the biggest amazing run challenge ever in Bugis Area? Attractive prizes are waiting for you!!! ",
                    Location = "Bugis Junction (In front of fountain)",
                    Time = "1:30pm"
                },
                  new RaceEvent()
                {
                    Id = 2,
                    Name = "Bukit Panjiang",
                    Date = new DateTime(2017, 5, 12),
                    Description = "Are you ready for the biggest amazing run challenge ever in Bugis Area? Attractive prizes are waiting for you!!! ",
                    Location = "Bugis Junction (In front of fountain)",
                    Time = "1:30pm"
                },
                new RaceEvent()
                {
                    Id = 3,
                    Name = "Sentosa",
                    Date = new DateTime(2017, 5, 19),
                    Description = "Are you ready for the biggest amazing run challenge ever in Bugis Area? Attractive prizes are waiting for you!!! ",
                    Location = "Bugis Junction (In front of fountain)",
                    Time = "1:30pm"
                },
                new RaceEvent()
                {
                    Id = 4,
                    Name = "Orchard",
                    Date = new DateTime(2017, 5, 26),
                    Description = "Are you ready for the biggest amazing run challenge ever in Bugis Area? Attractive prizes are waiting for you!!! ",
                    Location = "Bugis Junction (In front of fountain)",
                    Time = "1:30pm"
                },
                new RaceEvent()
                {
                    Id = 5,
                    Name = "Marina Run",
                    Date = new DateTime(2017, 6, 2),
                    Description = "Bring your family in!!! Fun and challenge amazing races forever. First runner will have voucher of Takashimaya worth SGD500.",
                    Location = "Marina Bay (5 minutes walking distance from MRT station)",
                    Time = "10:00am"
                },
                new RaceEvent()
                {
                    Id = 6,
                    Name = "NUS",
                    Date = new DateTime(2017, 6, 9),
                    Description = "Are you ready for the biggest amazing run challenge ever in Bugis Area? Attractive prizes are waiting for you!!! ",
                    Location = "Bugis Junction (In front of fountain)",
                    Time = "1:30pm"
                },
            });

            context.SaveChanges();
        }

        public static void GeneratePitStops(this ApplicationDbContext context)
        {
            AddorUpdateRange(context.PitStops, new List<PitStop>()
            {
                new PitStop() { Id =1, Name = "Bugis01", Location = context.Locations.Find(1), RaceEvent = context.RaceEvents.Find(1)},
                new PitStop() { Id =2, Name = "Bugis02", Location = context.Locations.Find(2), RaceEvent = context.RaceEvents.Find(1)},
                new PitStop() { Id =3, Name = "Bugis03", Location = context.Locations.Find(3), RaceEvent = context.RaceEvents.Find(1)},
                new PitStop() { Id =4, Name = "Bugis04", Location = context.Locations.Find(4), RaceEvent = context.RaceEvents.Find(1)},
                new PitStop() { Id =5, Name = "Bugis05", Location = context.Locations.Find(5), RaceEvent = context.RaceEvents.Find(1)},
                new PitStop() { Id =6, Name = "Bukit Panjiang01", Location = context.Locations.Find(8), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =7, Name = "Bukit Panjiang02", Location = context.Locations.Find(9), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =8, Name = "Bukit Panjiang03", Location = context.Locations.Find(10), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =9, Name = "Bukit Panjiang04", Location = context.Locations.Find(11), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =10, Name = "Bukit Panjiang05", Location = context.Locations.Find(12), RaceEvent = context.RaceEvents.Find(2)},
                new PitStop() { Id =11, Name = "Sentosa01", Location = context.Locations.Find(15), RaceEvent = context.RaceEvents.Find(3)},
                new PitStop() { Id =12, Name = "Sentosa02", Location = context.Locations.Find(16), RaceEvent = context.RaceEvents.Find(3)},
                new PitStop() { Id =13, Name = "Sentosa03", Location = context.Locations.Find(17), RaceEvent = context.RaceEvents.Find(3)},
                new PitStop() { Id =14, Name = "Sentosa04", Location = context.Locations.Find(18), RaceEvent = context.RaceEvents.Find(3)},
                new PitStop() { Id =15, Name = "Sentosa05", Location = context.Locations.Find(19), RaceEvent = context.RaceEvents.Find(3)},
                new PitStop() { Id =16, Name = "Orchard01", Location = context.Locations.Find(22), RaceEvent = context.RaceEvents.Find(4)},
                new PitStop() { Id =17, Name = "Orchard02", Location = context.Locations.Find(23), RaceEvent = context.RaceEvents.Find(4)},
                new PitStop() { Id =18, Name = "Orchard03", Location = context.Locations.Find(24), RaceEvent = context.RaceEvents.Find(4)},
                new PitStop() { Id =19, Name = "Orchard04", Location = context.Locations.Find(25), RaceEvent = context.RaceEvents.Find(4)},
                new PitStop() { Id =20, Name = "Orchard05", Location = context.Locations.Find(26), RaceEvent = context.RaceEvents.Find(4)},
                new PitStop() { Id =21, Name = "Marina01", Location = context.Locations.Find(29), RaceEvent = context.RaceEvents.Find(5)},
                new PitStop() { Id =22, Name = "Marina02", Location = context.Locations.Find(30), RaceEvent = context.RaceEvents.Find(5)},
                new PitStop() { Id =23, Name = "Marina03", Location = context.Locations.Find(31), RaceEvent = context.RaceEvents.Find(5)},
                new PitStop() { Id =24, Name = "Marina04", Location = context.Locations.Find(32), RaceEvent = context.RaceEvents.Find(5)},
                new PitStop() { Id =25, Name = "Marina05", Location = context.Locations.Find(33), RaceEvent = context.RaceEvents.Find(5)},
                new PitStop() { Id =26, Name = "NUS01", Location = context.Locations.Find(36), RaceEvent = context.RaceEvents.Find(6)},
                new PitStop() { Id =27, Name = "NUS02", Location = context.Locations.Find(37), RaceEvent = context.RaceEvents.Find(6)},
                new PitStop() { Id =28, Name = "NUS03", Location = context.Locations.Find(38), RaceEvent = context.RaceEvents.Find(6)},
                new PitStop() { Id =29, Name = "NUS04", Location = context.Locations.Find(39), RaceEvent = context.RaceEvents.Find(6)},
                new PitStop() { Id =30, Name = "NUS05", Location = context.Locations.Find(40), RaceEvent = context.RaceEvents.Find(6)},
            });

            context.SaveChanges();
        }

        public static void GenerateSupportStops(this ApplicationDbContext context)
        {
            AddorUpdateRange(context.SupportStops, new List<SupportStop>()
            {
                new SupportStop() {Id = 1, Code = "S01", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(6)},
                new SupportStop() {Id = 2, Code = "S02", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(7)},
                new SupportStop() {Id = 3, Code = "S03", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(13)},
                new SupportStop() {Id = 4, Code = "S04", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(14)},
                new SupportStop() {Id = 5, Code = "S05", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(20)},
                new SupportStop() {Id = 6, Code = "S06", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(21)},
                new SupportStop() {Id = 7, Code = "S07", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(27)},
                new SupportStop() {Id = 8, Code = "S08", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(28)},
                new SupportStop() {Id = 9, Code = "S09", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(34)},
                new SupportStop() {Id = 10, Code = "S10", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(35)},
                new SupportStop() {Id = 11, Code = "S11", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(41)},
                new SupportStop() {Id = 22, Code = "S12", RaceEvent = context.RaceEvents.Find(2), Location = context.Locations.Find(42)},
            });

            context.SaveChanges();
        }

        public static void GenerateTeams(this ApplicationDbContext context)
        {
            AddorUpdateRange(context.Teams, new List<Team>()
            {
                new Team() {Id = 1, Name = "Bugis Team A", Profile = "11111", RaceEvent = context.RaceEvents.Find(1)},
                new Team() {Id = 2, Name = "Bugis Team B", Profile = "11111", RaceEvent = context.RaceEvents.Find(1)},
                new Team() {Id = 3, Name = "Bugis Team C", Profile = "111", RaceEvent = context.RaceEvents.Find(1)},
                new Team() {Id = 4, Name = "Bugis Team D", Profile = "111", RaceEvent = context.RaceEvents.Find(1)},
                new Team() {Id = 5, Name = "Bukit Panjiang Team A", Profile = "111", RaceEvent = context.RaceEvents.Find(2)},
                new Team() {Id = 6, Name = "Bukit Panjiang Team B", Profile = "111", RaceEvent = context.RaceEvents.Find(2)},
                new Team() {Id = 7, Name = "Bukit Panjiang Team C", Profile = "111", RaceEvent = context.RaceEvents.Find(2)},
                new Team() {Id = 8, Name = "Bukit Panjiang Team D", Profile = "111", RaceEvent = context.RaceEvents.Find(2)},
                new Team() {Id = 9, Name = "Sentosa Team A", Profile = "111", RaceEvent = context.RaceEvents.Find(3)},
                new Team() {Id = 10, Name = "Sentosa Team B", Profile = "111", RaceEvent = context.RaceEvents.Find(3)},
                new Team() {Id = 11, Name = "Sentosa Team C", Profile = "111", RaceEvent = context.RaceEvents.Find(3)},
                new Team() {Id = 12, Name = "Sentosa Team D", Profile = "111", RaceEvent = context.RaceEvents.Find(3)},
                new Team() {Id = 13, Name = "Orchard Team A", Profile = "111", RaceEvent = context.RaceEvents.Find(4)},
                new Team() {Id = 14, Name = "Orchard Team B", Profile = "1111", RaceEvent = context.RaceEvents.Find(4)},
                new Team() {Id = 15, Name = "Orchard Team C", Profile = "1111", RaceEvent = context.RaceEvents.Find(4)},
                new Team() {Id = 16, Name = "Orchard Team D", Profile = "1111", RaceEvent = context.RaceEvents.Find(4)},
                new Team() {Id = 17, Name = "Marina Team A", Profile = "1111", RaceEvent = context.RaceEvents.Find(5)},
                new Team() {Id = 18, Name = "Marina Team B", Profile = "11111", RaceEvent = context.RaceEvents.Find(5)},
                new Team() {Id = 19, Name = "Marina Team C", Profile = "1111.", RaceEvent = context.RaceEvents.Find(5)},
                new Team() {Id = 20, Name = "Marina Team D", Profile = "11111", RaceEvent = context.RaceEvents.Find(5)},
                new Team() {Id = 21, Name = "NUS Team A", Profile = "111111.", RaceEvent = context.RaceEvents.Find(6)},
                new Team() {Id = 22, Name = "NUS Team B", Profile = "11111", RaceEvent = context.RaceEvents.Find(6)},
                new Team() {Id = 23, Name = "NUS Team C", Profile = "111111.", RaceEvent = context.RaceEvents.Find(6)},
                new Team() {Id = 24, Name = "NUS Team D", Profile = "11111", RaceEvent = context.RaceEvents.Find(6)},



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
