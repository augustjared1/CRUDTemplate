namespace SportsDB.Data.Migrations
{
    using SportsDB.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportsDB.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportsDB.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Athletes.AddOrUpdate(
              p => p.id,
              new Athlete { id = 1, Name = "Michael Jordan", Position = "Power Forward", Team = "Chicago Bulls"},
              new Athlete { id = 2, Name = "Peyton Manning", Position = "Quarterback", Team = "Denver Broncos" },
              new Athlete { id = 3, Name = "Arnold Palmer", Position = "Pro Golfer", Team = "N/A" },
              new Athlete { id = 4, Name = "Hank Aaron", Position = "Outfielder", Team = "Atlanta Braves" },
              new Athlete { id = 5, Name = "Wayne Gretzky", Position = "Centerman", Team = "Edmonton Oilers"}
            );

            context.Sports.AddOrUpdate(
              p => p.id,
              new Sport { id = 1, Name = "National Football League", Acronym = "NFL", Teams = 32, Athleteid = 2},
              new Sport { id = 2, Name = "Major League Baseball", Acronym = "MLB", Teams = 30, Athleteid = 4 },
              new Sport { id = 3, Name = "National Basketball Association", Acronym = "NBA", Teams = 30, Athleteid = 1 },
              new Sport { id = 4, Name = "National Hockey League", Acronym = "NHL", Teams = 32, Athleteid = 5 },
              new Sport { id = 5, Name = "Professional Golfers Association", Acronym = "PGA", Teams = 0, Athleteid = 3 }
            );
        }
    }
}
