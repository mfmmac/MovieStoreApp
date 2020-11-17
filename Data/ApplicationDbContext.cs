using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.Models;

namespace MovieStoreApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesModel> Movie { get; set; }
        public DbSet<CheckedOutModel> CheckedOutModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesModel>(i =>
            {
                i.HasKey(k => k.Id);
                i.HasData(
                    new MoviesModel { Id = 1, Title = "Shrek", Genre = "Comedy", Runtime = 90 },
                    new MoviesModel { Id = 2, Title = "Shrek 2: The Next Level", Genre = "Comedy", Runtime = 93 },
                    new MoviesModel { Id = 3, Title = "Shrek the Third", Genre = "Comedy", Runtime = 93 },
                    new MoviesModel { Id = 4, Title = "Shrek Forever After", Genre = "Comedy", Runtime = 93 },
                    new MoviesModel { Id = 5, Title = "Scared Shrekless", Genre = "Horror", Runtime = 26 },
                    new MoviesModel { Id = 6, Title = "Shrek the Musical", Genre = "Musical", Runtime = 130 },
                    new MoviesModel { Id = 7, Title = "Avengers: Endgame", Genre = "Action", Runtime = 181 },
                    new MoviesModel { Id = 8, Title = "Star Wars: Episode IX - The Rise of Skywalker", Genre = "Fantasy", Runtime = 141 },
                    new MoviesModel { Id = 9, Title = "Insidious", Genre = "Horror", Runtime = 103 },
                    new MoviesModel { Id = 10, Title = "Safe", Genre = "Action", Runtime = 94 }
                    );
                i.Property(m => m.Title).HasMaxLength(50);
                i.Property(m => m.Genre).HasMaxLength(50);
            });

            modelBuilder.Entity<CheckedOutModel>(i =>
            {
                i.HasKey(k => k.Id);
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
