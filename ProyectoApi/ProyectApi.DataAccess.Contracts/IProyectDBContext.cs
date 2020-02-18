using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProyectApi.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectApi.DataAccess.Contracts
{
    public interface IProyectDBContext
    {
       
        public DbSet<SpecieEntity> Especies { get; set; }

        DbSet<Tentity> Set<Tentity>() where Tentity : class;
        DatabaseFacade Database { get; }

        //Metodos que nos permiten realizar las operaciones que realiza el context guardar, remover y modificar
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);
    }
}
