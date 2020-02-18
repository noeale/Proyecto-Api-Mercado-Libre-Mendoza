using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoApi.Negocio.Functions
{
    public class Function
    {

        public static string GetStringFromADNArray(string[] valor)
        {
            string output = String.Join(", ", valor
                          .Select(s => s.ToString())
                          .ToArray());


            return output;
        }
    }
}
