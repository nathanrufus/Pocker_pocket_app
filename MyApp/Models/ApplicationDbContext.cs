using Microsoft.EntityFrameworkCore;
using PokerPocket.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PokerPocket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<PlayerModel> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var configuration = builder.Build();

                optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data
            modelBuilder.Entity<GameModel>().HasData(
                new GameModel { GameId = 1, Name = "HOLD EM" },
                new GameModel { GameId = 2, Name = "OMAHA" },
                new GameModel { GameId = 3, Name = "TOURNAMENT" },
                new GameModel { GameId = 4, Name = "FREE ROLL" }
            );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
