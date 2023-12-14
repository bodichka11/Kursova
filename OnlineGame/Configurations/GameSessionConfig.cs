using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineGame.Models;

namespace OnlineGame.Configurations
{
    public class GameSessionConfig : IEntityTypeConfiguration<GameSession>
    {
        public void Configure(EntityTypeBuilder<GameSession> builder)
        {
            builder.HasOne(x => x.Game)
                .WithMany(x => x.GameSessions)
                .HasForeignKey(x => x.GameId);

            builder.HasOne(c => c.Mode)
               .WithMany(c => c.GameSessions)
               .HasForeignKey(c => c.ModeId);

            builder.HasMany(z => z.Players)
                .WithMany(z => z.GameSessions);
        }
    }
}
