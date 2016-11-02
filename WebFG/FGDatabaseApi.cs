namespace WebFG
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FGDatabaseApi : DbContext
    {
        // Your context has been configured to use a 'FGDatabaseApi' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebFG.FGDatabaseApi' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FGDatabaseApi' 
        // connection string in the application configuration file.
        public FGDatabaseApi()
            : base("name=FGDatabaseApi")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Estudantes> Estudantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }


}