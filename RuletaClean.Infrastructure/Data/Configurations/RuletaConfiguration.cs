using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RuletaClean.Core.Entities;

namespace RuletaClean.Infrastructure.Data.Configurations
{
    public class RuletaConfiguration : IEntityTypeConfiguration<Ruleta>
    {
        public void Configure(EntityTypeBuilder<Ruleta> entity)
        {
            entity.HasKey(e => e.id_ruleta);
        }
    }
}
