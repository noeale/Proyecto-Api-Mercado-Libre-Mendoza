using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoApi.Negocio.Models
{
    public class Specie
    {
        public int id { get; set; }
        public string[] adn { get; set; }
        public bool mutant { get; set; }
    }
}
