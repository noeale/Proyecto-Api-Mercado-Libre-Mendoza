using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectApi.DataAccess.Contracts.Entities
{
    public class SpecieEntity
    {
        public int ID { get; set; }
        public string ADNs { get; set; }

        public bool isMutant { get; set; }
    }
}
