using System.Reflection;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class StoreContext : DbContext // (DbContext - from entity core for working with db)
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            // Base constructor call to DbContext passing in options (dependency injection of database configuration options)
        }

        // Courses property representing a table in the database - configure db table
        public DbSet<Course> Courses {get; set;} // DbSet<Course> is used to interact with the Course entity in the database

        public DbSet<Category> Categories {get; set;}

        public DbSet<Requirement> Requirements {get; set;}

        public DbSet<Learning> Learnings {get; set;}
        public DbSet<Basket> Baskets {get; set;}

        // configure entity mappings before interacting with db - CourseConfiguration etc
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}