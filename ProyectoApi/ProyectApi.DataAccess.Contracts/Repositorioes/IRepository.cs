using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectApi.DataAccess.Contracts.Repositorioes
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// T es un tipo generico que se usa para poder aplicar todas estas propiedades
        /// </summary>

        //Se especifica que T tiene que ser una clase para que cuando Realicemos las peticiones de CRUD podamos hacerlo con cualquier tipo de clase
        Task<bool> Exist(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int Id);
        Task DeleteAsync(int Id);
        Task<T> Update(int Id,T element);
        Task<T> Add(T element);

    }
}
