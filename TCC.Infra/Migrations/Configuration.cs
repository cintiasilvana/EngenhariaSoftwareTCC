using TCC.Infra.Context;
using System.Data.Entity.Migrations;


namespace TCC.Infra.Migrations
{   

    internal sealed class Configuration : DbMigrationsConfiguration<AcademiaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AcademiaContext context)
        {
            UserSeed.Seed(context);
        }
    }
}
