namespace Test.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Test.Data.Entities;

    public class TestDbContext : DbContext
    { 
        // If you wish to target a different database and/or database provider, modify the 'TestDbContext' 
        // connection string in the application configuration file.
        public TestDbContext()
            : base("name=TestDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
    }

}