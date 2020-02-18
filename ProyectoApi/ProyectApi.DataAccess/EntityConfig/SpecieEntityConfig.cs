using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectApi.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectApi.DataAccess.EntityConfig
{
    public class SpecieEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<SpecieEntity>entityBuilder)
        {
            entityBuilder.ToTable("Especies");
            entityBuilder.HasKey(x => x.ID);
            entityBuilder.Property(x => x.ID).IsRequired();
            
        }
    }
}
