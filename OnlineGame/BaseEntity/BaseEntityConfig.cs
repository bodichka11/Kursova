using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlineGame.Models;

namespace OnlineGame.BaseEntity
{
    public class EntityConfig<T> : IEntityTypeConfiguration<Entity<T>> where T : struct
    {
        public void Configure(EntityTypeBuilder<Entity<T>> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
