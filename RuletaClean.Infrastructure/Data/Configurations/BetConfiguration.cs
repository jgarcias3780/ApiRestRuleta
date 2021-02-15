using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RuletaClean.Core.Entities;

namespace RuletaClean.Infrastructure.Data.Configurations
{
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> entity)
        {
            entity.HasKey(e => e.id_bet);

            entity.HasOne(r => r.id_roulette_navigation)
               .WithMany(a => a.Bet)
               .HasForeignKey(r => r.id_roulette);

            entity.HasOne(r => r.id_user_navigation)
               .WithMany(a => a.Bet)
               .HasForeignKey(r => r.id_user);
        }
    }
}
