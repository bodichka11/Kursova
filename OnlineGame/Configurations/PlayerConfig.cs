using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineGame.Models;

namespace OnlineGame.Configurations
{
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {

        public void Configure(EntityTypeBuilder<Player> builder)
        {

            //builder.HasMany(z => z.GameSessions)
            //     .WithMany(z => z.Players);

            
        }
    }
}
