namespace Data.Model
{
    using DomainEntities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ExerciseContext : DbContext
    {
        // Your context has been configured to use a 'ExerciseModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Data.Model.ExerciseModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ExerciseModel' 
        // connection string in the application configuration file.
        public ExerciseContext()
            : base("name=ExerciseModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
    }

  
}