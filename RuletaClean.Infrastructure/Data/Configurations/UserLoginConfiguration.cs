using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RuletaClean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaClean.Infrastructure.Data.Configurations
{
    class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> entity)
        {
            entity.HasKey(e => e.id_userapi);
        }
    }
}
