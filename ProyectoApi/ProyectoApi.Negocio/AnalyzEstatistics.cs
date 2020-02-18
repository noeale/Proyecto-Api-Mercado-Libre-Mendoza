using ProyectoApi.Negocio.Functions;
using ProyectoApi.Negocio.Models;
using ProyectoApi.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProyectoApi.Negocio
{
    public class AnalyzEstatistics
    {
        public AnalyzEstatistics()
        {

        }
        
        public static Stats EstatisticsSpecie(IEnumerable<Specie> specie)
        {
            try
            {
                 Stats outStats = new Stats();
                            outStats.count_mutant_dna = specie.Where(x => x.mutant == true).Count();
                            outStats.count_human_dna = specie.Where(x => x.mutant == false).Count();
                            outStats.ratio = outStats.count_mutant_dna / outStats.count_human_dna;
                            return outStats;
            }
            catch (Exception e)
            {

                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
           
        }

        


    }
}
