using ProyectoApi.Negocio.Models;
using ProyectoApi.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProyectoApi.Negocio
{
    public class AnalyzeNitrogenado
    {
        static string[,] sequence;
        public AnalyzeNitrogenado()
        {

        }
        /// <summary>
        /// Realiza la busqueda para ver si el arreglo que le paso contiene el ADN correcto
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>devuelve un bool y la matriz lista ya analizada</returns>
        public static (bool outNitro, string[,] outMatrix) SearchNitrogeno(string[] dna)
        {
            try
            {
                int count = dna.Length;
                sequence = new string[count, count];
                bool outSearch = true;
                for (int i = 0; i < count; i++)
                {
                    //separa letra por letra el arreglo
                    List<string> listADN = GetLetterBYLetter(ref dna[i]);
                    if (outSearch)
                    {
                        //Analisa la lista de listaADN y verifica contra nitrogenado si hay una letra que no pertenece a esa lista lo devuelve a la lista y retorna falso
                        if (VerifyNitrogen(listADN))
                        {
                            outSearch = true;
                            //arma la matriz para poder buscar los valores que determinan si es mutante
                            GetMatrix(listADN, i);
                        }
                        else
                        {
                            i = count;
                            sequence = null;
                            outSearch = false;
                        }
                    }

                }
                return (outSearch, sequence);
            }
            catch (Exception )
            {

                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, "No se pudo convertir el arreglo en una matriz");

            }
           
        }

        /// <summary>
        /// Toma el arreglo y lo devuelve en unas lista letra por letra 
        /// </summary>
        /// <param name="valorADN"></param>
        /// <returns>Una lista con cada letra</returns>
        public static List<string> GetLetterBYLetter(ref string valorADN)
        {
            try
            {
                return valorADN.Select((c, i) => new { c, i })
                                        .GroupBy(x => x.i / 1)
                                        .Select(g => String.Join("", g.Select(y => y.c)))
                                        .ToList();
            }
            catch (Exception e)
            {

                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
            
        }

        /// <summary>
        /// Verifica si existe alguna letra que no pertenece a las variables del nitrogenado
        /// </summary>
        /// <param name="listaADN"></param>
        /// <returns></returns>
        public static bool VerifyNitrogen(List<string> listaADN)
        {
            try
            {
                List<string> verificaExistencia = new List<string>();
                verificaExistencia = listaADN.Where(t => !Constant.nitrogenada.Contains(t)).ToList();
                if (verificaExistencia.Count > 0) return false;
                return true;

            }
            catch (Exception e)
            {

                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
        }

        /// <summary>
        /// Convierte a la lista en una mattriz de NXN
        /// </summary>
        /// <param name="listaADN"></param>
        /// <param name="i"></param>
        public static void GetMatrix(List<string> listaADN, int i)
        {
            try
            {
                for (int x = 0; x < listaADN.Count; x++)
                            {
                                sequence[i, x] = listaADN[x];
                            }
            }
            catch (Exception e)
            {

                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());

            }

        }

    }
}
