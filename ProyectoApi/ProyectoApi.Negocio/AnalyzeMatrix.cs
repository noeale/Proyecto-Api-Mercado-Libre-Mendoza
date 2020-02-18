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
    public class AnalyzeMatrix
    {
        public AnalyzeMatrix()
        {

        }
        
        /// <summary>
        /// Verifica que la matriz sea de NXN
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>devuelve un bool</returns>
        public static bool AnalyzeNXN(string[] dna)
        {
            try
            {
                bool outAnalyzeMatriz = false;
                //1-Primero verifico que la matriz sea de NXN
                if (CheckNXN(dna))
                {
                    outAnalyzeMatriz = true;
                }
                return outAnalyzeMatriz;

            }
            catch (Exception e)
            {

                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, "El ADN analizado no permite generar un matriz de NXN"); ;
            }
            
        }

        /// <summary>
        /// Verifica que la cantidad de fila sea igual a la cantidad de columnas 
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>bool</returns>
        #region Toma los valores del arreglo y analiza toda la matriz, teniendo en cuenta si es NXN
        public static bool CheckNXN(string[] dna)
        {
            //try
            //{
                int columnaMax = dna.Max(w => w.Length);
                int columnaMin = dna.Min(w => w.Length);
                int colum = 0;
                if (columnaMax == columnaMin)
                {
                    colum = columnaMax;
                    int fila = dna.Length;
                    if (colum == fila)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new HttpException((int)System.Net.HttpStatusCode.NotFound, "El ADN analizado no puede generar una matriz NXN");

                }

            //}
            //catch (Exception e)
            //{

            //    throw new HttpException((int)System.Net.HttpStatusCode.NotFound, "El ADN analizado no puede generar una matriz NXN");
            //}

        }

        
        #endregion


    }
}
