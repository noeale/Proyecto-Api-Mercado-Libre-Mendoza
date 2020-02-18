using ProyectoApi.Aplicacion.Contratos.Servicios;
using ProyectoApi.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoApi.Test1
{
    public class SpecieServiceFake : ISpecieService
    {
        public Task<bool> IsMutant(string[] dna)
        {
            throw new NotImplementedException();
        }

        public Task<Stats> GetValueStatistics()
        {
            throw new NotImplementedException();
        }

       

       

       
    }
}
