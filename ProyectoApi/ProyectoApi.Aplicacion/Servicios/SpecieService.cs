using Microsoft.AspNetCore.Mvc;
using ProyectApi.DataAccess.Contracts.Repositorioes;
using ProyectApi.DataAccess.Mappers;
using ProyectoApi.Aplicacion.Contratos.Servicios;
using ProyectoApi.Negocio;
using ProyectoApi.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoApi.Aplicacion.Servicios
{
    public class SpecieService : ISpecieService
    {
        #region Declaracion
        //las variables privadas se les agrega el _ para usarse como nomenclatura para todas estas
        private readonly ISpecieRepository _especieRepository;
        public SpecieService(ISpecieRepository especieRepository)
        {
            _especieRepository = especieRepository;
                
        }
        #endregion       
        
        /// <summary>
        /// Verifica si el arreglo ingresado es un mutante o no y lo guarda en la BD
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>boool</returns>
        async Task<bool> ISpecieService.IsMutant(string[] dna)
        {
            Specie especie = new Specie();
            
            bool outgetResult = await AnalyzeSpecies(dna);
            especie.adn = dna;
            especie.mutant = outgetResult;
            var valueEspecie = await this.AddEspecie(especie);
            ChekIfIsNull(valueEspecie);
            return especie.mutant;

        }
        


        /// <summary>
        /// Obtiene los valores estadisticos: cantidad de humanos y mutantes y el ratio
        /// </summary>
        /// <returns></returns>
        public async Task<Stats> GetValueStatistics()
        {

            var specie = await _especieRepository.GetAll();
            return AnalyzEstatistics.EstatisticsSpecie(specie.Select(SpecieMapper.Map));


        }
       


        /********************************************************************************************/

        #region Metodos usados para buscar analizar el arreglo en busqueda del ADN correcto y guardarlo en el caso que sea mutante o humano
            /// <summary>
            /// Analiza todo el arreglo para ver si es o no un arreglo de NXN
            /// </summary>
            /// <param name="dna"></param>
            /// <returns></returns>
        public async Task<bool> AnalyzeSpecies(string[] dna)
        {
            
                bool outResultIsMutant = false;
                if (AnalyzeMatrixNXN(dna))
                {
                    var outSearchN = SearchNitrogeno(dna);
                    if (outSearchN.Item1)
                    {
                        outResultIsMutant = VerifyIsMutan(outSearchN.Item2, dna.Length);
                    }
                    else
                    {
                        throw new HttpException((int)System.Net.HttpStatusCode.NotFound, "El ADN analizado esta fuera del los limites de Nitrogenada");
                    }
                }
                else
                {
                    throw new HttpException((int)System.Net.HttpStatusCode.NotFound, "La matriz esta fuera de rango");
                }
               
                return outResultIsMutant;
           
        }

        /// <summary>
        /// Verifica si se cumple que esa arreglo sea una matriz NXN
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>bool</returns>
        public bool AnalyzeMatrixNXN(string[] dna)
        {
            return AnalyzeMatrix.AnalyzeNXN(dna);
        }

        /// <summary>
        /// Busca nitrogenada
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>bool y un arreglo de NXN</returns>
        public (bool, string[,]) SearchNitrogeno(string[] dna)
        {
            return AnalyzeNitrogenado.SearchNitrogeno(dna);
        }

        /// <summary>
        /// Verifica si es un mutante
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>bool</returns>
        public bool VerifyIsMutan(string[,] dna, int counFila)
        {
            return AnalyzeEspecie.SearchIsMutant(dna, counFila);
        }

        /// <summary>
        /// Agrega la especia para saber si es un mutante o un humano lo que se esta guardando
        /// </summary>
        /// <param name="especie"></param>
        /// <returns>Specie</returns>
        public async Task<Specie> AddEspecie(Specie especie)
        {
            var addEntity = await _especieRepository.Add(SpecieMapper.Map(especie));
            return SpecieMapper.Map(addEntity);
        }

        /// <summary>
        /// Cheque si la Especie devuelta no es un null
        /// </summary>
        /// <param name="especie"></param>
        private void ChekIfIsNull(Specie especie)
        {
            if(especie == null)
            {
                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, "Error al traer la especie");
            }
        }



        #endregion

      
    }
}
