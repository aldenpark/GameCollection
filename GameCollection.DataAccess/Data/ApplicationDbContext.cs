using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameCollection.Models;
using System.ComponentModel.DataAnnotations;

namespace GameCollection.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
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