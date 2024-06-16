using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MongoDBEFCore.CRUD;

public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().ToCollection("movies");
        }
        public DbSet<Movie> movies {get;set;}

    }
