using Microsoft.EntityFrameworkCore;
using ProyectApi.DataAccess.Contracts;
using ProyectApi.DataAccess.Contracts.Entities;
using ProyectApi.DataAccess.Contracts.Repositorioes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectApi.DataAccess.Repositorios
{
    public class SpecieRepository : ISpecieRepository
    {
        //Aca se implementa un CRUD (CREAT,READ, UPDATE; DELETE)
        private readonly IProyectDBContext _proyectDBContext;
        //cuando saco el contructor no me lo reconoce
        //public EspecieRepository()
        //{

        //}

        //inyeccion de dependencia
        public SpecieRepository(IProyectDBContext proyectDBContext)
        {
            _proyectDBContext = proyectDBContext;
        }
        public async Task<SpecieEntity> Add(SpecieEntity entity)
        {
            await _proyectDBContext.Especies.AddAsync(entity);
            await _proyectDBContext.SaveChangesAsync();

            return entity;
        }
        public async Task<IEnumerable<SpecieEntity>> GetAll()
        {
            var result = await _proyectDBContext.Especies.ToListAsync();
            return result;
        }

        #region Update de dos tipos pasando el Id o pasando la clase entera
        public async Task<SpecieEntity> Update(int idEntity, SpecieEntity updateEnt)
        {
            var entity = await Get(idEntity);
            //entity.nam
            _proyectDBContext.Especies.Update(entity);
            await _proyectDBContext.SaveChangesAsync();
            return entity;
        }
        public async Task<SpecieEntity> Update(SpecieEntity entity)
        {
            var updateEntity = _proyectDBContext.Especies.Update(entity);
            await _proyectDBContext.SaveChangesAsync();
            return updateEntity.Entity;
        }
        #endregion

        public async Task<SpecieEntity> Get(int idEntity)
        {
            var result = await _proyectDBContext.Especies.FirstOrDefaultAsync(x => x.ID == idEntity);
            return result;
        }

        public Task<bool> Exist(int Id)
        {
            throw new NotImplementedException();
        }

       

        public async Task DeleteAsync(int id)
        {
            var entity = await _proyectDBContext.Especies.SingleAsync(x => x.ID == id);
            _proyectDBContext.Especies.Remove(entity);
            await _proyectDBContext.SaveChangesAsync();

        }
    }
}
