using Microsoft.EntityFrameworkCore;
using OnlineGame.BaseEntity;

namespace OnlineGame.Data
{
    public static class ModelBuilderExtentions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig<long>).Assembly);
        }
    }
}
