namespace angularwebb.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<angularwebb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(angularwebb.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Persons.AddOrUpdate(
              p => p.firstName,
              new Person { firstName = "Andrew " ,lastName= "Peters", country="sweden",phone="111111"},
              new Person { firstName = "Brice ",lastName= "aaaa", country="germany",phone="2222222"},
              new Person { firstName = "Rowan ", lastName = "Miller", country = "france", phone = "444444" }
              
            );
            //
        }
    }
}
