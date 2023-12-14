using Microsoft.EntityFrameworkCore;
using OnlineGame.Models;

namespace OnlineGame.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<GameSession> GameSessions => Set<GameSession>();
        public DbSet<Achievement> Achievements => Set<Achievement>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Mode> Modes => Set<Mode>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
        }
    }
}
