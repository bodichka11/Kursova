using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineGame.Models;

namespace OnlineGame.Configurations
{
    public class ModeConfig : IEntityTypeConfiguration<Mode>
    {
        public void Configure(EntityTypeBuilder<Mode> builder)
        {
           
        }
    }
}
