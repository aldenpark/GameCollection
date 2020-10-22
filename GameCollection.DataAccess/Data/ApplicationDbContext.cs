using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameCollection.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GameCollection.DataAccess.Data
{
    // mapping of models to the tables in the db, also using IdentityDbContext for indentify that extends dbContext
    public class ApplicationDbContext : IdentityDbContext //DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GameCollection.Models.Game> Game { get; set; }
        public DbSet<GameCollection.Models.GameGenre> GameGenre { get; set; }
        public DbSet<GameCollection.Models.CatalogGenre> CatalogGenre { get; set; }
        public DbSet<GameCollection.Models.Customer> Customer { get; set; }
        public DbSet<GameCollection.Models.PurchaseHistory> PurchaseHistory { get; set; }
        public DbSet<GameCollection.Models.Comment> Comment { get; set; }
        public DbSet<GameCollection.Models.ReviewerGameScore> ReviewerGameScore { get; set; }
        public DbSet<GameHistory> GameHistory { get; set; }
        public DbSet<GameCollection.Models.ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            modelBuilder.Entity<CatalogGenre>()
                .HasKey(c => new { c.GameId, c.GenreId });
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) // fluent api
        //{
        //    modelBuilder.Entity<CatalogGenre>()
        //        .HasKey(x => new { x.GameId, x.GenreId });

        //    modelBuilder.Entity<CatalogGenre>()
        //        .HasOne(x => x.Game)
        //        .WithMany(y => y.CatalogGenre)
        //        .HasForeignKey(y => y.GenreId);

        //    modelBuilder.Entity<CatalogGenre>()
        //        .HasOne(x => x.Genre)
        //        .WithMany(y => y.CatalogGenre)
        //        .HasForeignKey(y => y.GameId);

        //}
    }
}