using ProyectApi.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectApi.DataAccess.Contracts.Repositorioes
{
    public interface ISpecieRepository : IRepository<SpecieEntity>
    {
        Task<SpecieEntity> Update(SpecieEntity entity);
  


    }
}
