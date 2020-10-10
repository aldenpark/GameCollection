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
        public DbSet<GameCollection.Models.Customer> Customer { get; set; }
        public DbSet<GameCollection.Models.PurchaseHistory> PurchaseHistory { get; set; }
        public DbSet<GameCollection.Models.Comment> Comment { get; set; }
        public DbSet<GameCollection.Models.ReviewerGameScore> ReviewerGameScore { get; set; }
    }
}