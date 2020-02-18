using ProyectoApi.Negocio.Models;
using ProyectoApi.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApi.WebApi.Mappers
{
    public static class SpecieMaper
    {
        public static Specie Map(SpecieViewModel model, bool valMutant = false)
        {
            return new Specie()
            {
                adn = model.adn,
                mutant = valMutant,

            };
        }
    }
}
