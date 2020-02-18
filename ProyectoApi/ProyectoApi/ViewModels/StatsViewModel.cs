using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoApi.WebApi.ViewModels
{
    public class StatsViewModel
    {
        public double mutant { get; set; }
        public double human { get; set; }

        public double ratio { get; set; }
    }
}
