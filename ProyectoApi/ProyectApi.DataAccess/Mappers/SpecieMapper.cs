using ProyectApi.DataAccess.Contracts.Entities;
using ProyectoApi.Negocio.Functions;
using ProyectoApi.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectApi.DataAccess.Mappers
{
    public static class SpecieMapper
    {
        public static SpecieEntity Map(Specie dto)
        {
            return new SpecieEntity()
            {
                ID = dto.id,
                ADNs = Function.GetStringFromADNArray(dto.adn),
                isMutant = dto.mutant
            };
        }

        public static Specie Map(SpecieEntity entity)
        {
            return new Specie()
            {
                id = entity.ID,
                adn = entity.ADNs.Split(","),
                mutant = entity.isMutant
            };
        }
    }
}
