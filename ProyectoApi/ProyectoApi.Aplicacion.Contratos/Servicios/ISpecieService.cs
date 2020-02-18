using Microsoft.AspNetCore.Mvc;
using ProyectoApi.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoApi.Aplicacion.Contratos.Servicios
{
    public interface ISpecieService
    {
        Task<bool> IsMutant(string[] dna);
        Task<Stats> GetValueStatistics();

     
    }
}
