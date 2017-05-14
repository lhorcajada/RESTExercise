namespace Data.Model
{
    using DomainEntities;
    using System.Data.Entity;
    /// <summary>
    /// Contexto de datos de EntityFrameWork
    /// </summary>
    public class ExerciseContext : DbContext
    {

        public ExerciseContext()
            : base("name=ExerciseModel")
        {
        }


        public virtual DbSet<User> Users { get; set; }
    }

  
}