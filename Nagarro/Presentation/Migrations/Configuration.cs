namespace Presentation.Migrations
{
    using Presentation.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Presentation.NagarroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Presentation.NagarroContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var admins = new List<Admin>
            {
                new Admin { UserName = "Admin",   Password = "xyz@abc"},
                new Admin { UserName = "Karishma",   Password = "xyz@123"}
            };
            admins.ForEach(s => context.Admins.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();
        }
    }
}
