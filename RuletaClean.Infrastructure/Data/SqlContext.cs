using Microsoft.EntityFrameworkCore;
using RuletaClean.Core.Entities;
using RuletaClean.Infrastructure.Data.Configurations;

namespace RuletaClean.Infrastructure.Data
{
    public partial class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public virtual DbSet<Ruleta> Ruleta { get; set; }
        public virtual DbSet<Apuesta> Apuesta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RuletaConfiguration());
            modelBuilder.ApplyConfiguration(new ApuestaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
