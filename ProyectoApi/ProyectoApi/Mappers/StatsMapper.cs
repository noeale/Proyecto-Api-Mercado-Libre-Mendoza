using ProyectoApi.Negocio.Models;
using ProyectoApi.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApi.WebApi.Mappers
{
    public static class StatsMapper
    {
        public static Stats Map(StatsViewModel model)
        {
            return new Stats()
            {
                count_mutant_dna = model.mutant,
                count_human_dna = model.human,
                ratio = model.ratio,
            };
        }
    }
}
