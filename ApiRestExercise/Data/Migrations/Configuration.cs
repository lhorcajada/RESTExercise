namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Model.ExerciseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Model.ExerciseContext context)
        {
            context.Users.Add(new DomainEntities.User { Name = "Nombre 1 ", BirthDate = new DateTime(1973, 7, 12) });
            context.Users.Add(new DomainEntities.User { Name = "Nombre 2 ", BirthDate = new DateTime(1976, 5, 28) });
            context.Users.Add(new DomainEntities.User { Name = "Nombre 3 ", BirthDate = new DateTime(1945, 8, 21) });
            context.Users.Add(new DomainEntities.User { Name = "Nombre 4 ", BirthDate = new DateTime(1987, 9, 9) });
        }
    }
}
