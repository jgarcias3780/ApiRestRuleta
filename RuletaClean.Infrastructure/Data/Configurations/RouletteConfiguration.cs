using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RuletaClean.Core.Entities;

namespace RuletaClean.Infrastructure.Data.Configurations
{
    public class RouletteConfiguration : IEntityTypeConfiguration<Roulette>
    {
        public void Configure(EntityTypeBuilder<Roulette> entity)
        {
            entity.HasKey(e => e.id_roulette);
        }
    }
}
