using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineGame.Models;

namespace OnlineGame.Configurations
{
    public class AchievementConfig : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.HasOne(x => x.Player)
             .WithMany(x => x.Achievements)
             .HasForeignKey(x => x.PlayerId);
        }
    }
}
