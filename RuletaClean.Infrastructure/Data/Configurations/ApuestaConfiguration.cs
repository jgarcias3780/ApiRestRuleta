using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RuletaClean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaClean.Infrastructure.Data.Configurations
{
    public class ApuestaConfiguration : IEntityTypeConfiguration<Apuesta>
    {
        public void Configure(EntityTypeBuilder<Apuesta> entity)
        {
            entity.HasKey(e => e.id_apuesta);

            entity.HasOne(r => r.id_ruleta_navigation)
               .WithMany(a => a.Apuesta)
               .HasForeignKey(r => r.id_ruleta);

            entity.HasOne(r => r.id_usuario_navigation)
               .WithMany(a => a.Apuesta)
               .HasForeignKey(r => r.id_usuario);
        }
    }
}
