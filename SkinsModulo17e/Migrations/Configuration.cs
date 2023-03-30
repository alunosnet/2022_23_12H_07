namespace SkinsModulo17e.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SkinsModulo17e.Data.SkinsModulo17eContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SkinsModulo17e.Data.SkinsModulo17eContext";
        }

        protected override void Seed(SkinsModulo17e.Data.SkinsModulo17eContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
