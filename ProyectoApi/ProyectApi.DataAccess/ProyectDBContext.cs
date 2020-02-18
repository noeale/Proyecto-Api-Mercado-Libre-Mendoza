using Microsoft.EntityFrameworkCore;
using ProyectApi.DataAccess.Contracts;
using ProyectApi.DataAccess.Contracts.Entities;
using ProyectApi.DataAccess.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectApi.DataAccess
{
    public class ProyectDBContext : DbContext, IProyectDBContext
    {
        public DbSet<SpecieEntity> Especies { get; set; }

        public ProyectDBContext(DbContextOptions options) : base(options)
        {

        }
        public ProyectDBContext()
        {

        }
        
        

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SpecieEntityConfig.SetEntityBuilder(modelBuilder.Entity<SpecieEntity>());

            base.OnModelCreating(modelBuilder);
        }
    }


}
