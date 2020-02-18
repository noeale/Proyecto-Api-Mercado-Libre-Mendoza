using ProyectoApi.Negocio.Models;
using ProyectoApi.Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProyectoApi.Negocio
{
    public class AnalyzeEspecie
    {
        public AnalyzeEspecie()  {}

        #region Codigo para analizar que especie es (Mutante o Humano)

        /// <summary>
        /// Busca en la matriz que tipo de ADN es
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>bool</returns>
        public static bool SearchIsMutant(string[,] dna, int countFila)
        {
            //int countsearch = 0;
            try
            {
                bool outMutan = false;
                int countsearch = HorizontalSearch(dna,countFila);
                if (countsearch < 2)
                {
                    countsearch += VerticalSearch(dna,countFila);
                    if (countsearch < 2)
                    {
                        countsearch += LeftObliqueSearch(dna,countFila);
                        countsearch += RightObliqueSearch(dna, countFila);
                        if(countsearch == 2)
                        {
                            outMutan = true;
                        }
                    }
                    else
                    {
                        outMutan = true;
                    }
                }
                else
                {
                    outMutan = true;
                }
                return outMutan;
            }
            catch (Exception e)
            {

                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
        }

        #region Realiza tipo de busquedas dentro de la Matriz
        //busqueda Horizontal
        /// <summary>
        /// Realiza una busqueda vertical dentro de la matriz
        /// </summary>
        /// <param name="dna"></param>
        /// <returns>devuelve la cantidad de veces que se repite el ADN de la especie</returns>
        public static int HorizontalSearch(string[,] dna, int counFila)
        {
            
            try
            {
                List<string> ListRight = new List<string>();
                int outNumberRigh = 0;
                for (int i = 0; i < counFila; i++)
                {
                    for (int m = 0; m < counFila; m++)
                    {
                        ListRight.Add(dna[i, m]);

                    }
                    outNumberRigh += GetNumberToRepeat(ListRight);
                    ListRight.Clear();
                }
                return outNumberRigh;
            }
            catch (Exception e)
            {
                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
            
        }

        //busqueda Vertical
        public static int VerticalSearch(string[,] dna, int countFila)
        {
            
            try
            {
                int outlineSearch = 0;
                List<string> Listline = new List<string>();
                for (int i = 0; i < countFila; i++)
                {
                    for (int m = 0; m < countFila; m++)
                    {
                        Listline.Add(dna[m, i]);

                    }
                    outlineSearch += GetNumberToRepeat(Listline);
                    Listline.Clear();
                }
                return outlineSearch;
            }
            catch (Exception e)
            {
                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
            
        }

        //busqueda diagonal iquierda
        public static int LeftObliqueSearch(string[,] dna, int countFila)
        {
           
            try
            {
                int outLeftOblique = 0;
                List<string> ListObliqueLef = new List<string>();
                for (int i = 0; i < countFila; i++)
                {
                    ListObliqueLef.Add(dna[i, i]);

                }
                outLeftOblique += GetNumberToRepeat(ListObliqueLef);
                ListObliqueLef.Clear();
                return outLeftOblique;
            }
            catch (Exception e)
            {
                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
            
        }

        //busqueda diagonal derecha
        public static int RightObliqueSearch(string[,] dna, int countFila)
        {
            
            try
            {
                int outRightOblique = 0;
                int count = countFila-1;
                List<string> ListObliqueRigh = new List<string>();
                int valAuxList = 0;
                for (int i = count; i >= 0; i--)
                {
                    ListObliqueRigh.Add(dna[i, valAuxList]);
                    valAuxList++;
                }
                outRightOblique += GetNumberToRepeat(ListObliqueRigh);
                ListObliqueRigh.Clear();
                return outRightOblique;
            }
            catch (Exception e)
            {
                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
        }
        #endregion

        #region Metodos que ayudan a buscar y analizar el ADN de la especie

        /// <summary>
        /// Obtiene la cantidad de veces que se repite los valores del ADN que estan guardados en la lista
        /// </summary>
        /// <param name="listaADN"></param>
        /// <returns></returns>
        public static int GetNumberToRepeat(List<string> listADN)
        {
            return CountToRepeat(listADN);            
        }

        /// <summary>
        /// devuelve especificamente las veces que existen y las analiza partiendo la linea a la mitad y va analizando
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static int CountToRepeat(List<string> listADN)
        {
            try
            {
                string firstValue = listADN[0];
                string lastValue = listADN[listADN.Count - 1];
                int outToRepeat = 0;

                #region valor del medio parte izquierda
                //calcula la mitad para obtener el valor medio y comprar
                int countLeft = (listADN.Count / 2);
                string listValueLeft = listADN[countLeft];
                //Realiza dos tipos de comparaciones: primero compara el primero con el del medio
                if (firstValue == listValueLeft)
                {
                    outToRepeat = CountToArray(Convert.ToChar(firstValue), listADN);
                    return outToRepeat;
                }

                #endregion

                #region valor del medio de la parte derecha
                int countRight = (listADN.Count / 2) - 1;
                string valueRight = listADN[countRight];
                if (lastValue == valueRight)
                {
                    outToRepeat = CountToArray(Convert.ToChar(lastValue), listADN);
                    return outToRepeat;
                }

                #endregion
                return outToRepeat;
            }
            catch (Exception e)
            {
                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
        }

        /// <summary>
        /// cuenta carracter por caranter para ver cuantas veces existe
        /// </summary>
        /// <param name="caracter"></param>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static int CountToArray(char valueChar, List<string> ListChar)
        {
            try
            {
                int outValueRepeat = 0;
                List<int> auxList = new List<int>();
                for (int i = 0; i < ListChar.Count; i++)
                {
                    if (ListChar[i] == Convert.ToString(valueChar))
                    {
                        outValueRepeat++;
                        if (outValueRepeat == Constant.sequenceNitrogenada)
                        {
                            auxList.Add(outValueRepeat);
                            outValueRepeat = 0;
                        }


                    }
                    else
                    {
                        outValueRepeat = 0;
                    }

                }
                if(auxList.Count > 0)
                {
                    outValueRepeat = auxList.Count;
                }
                else
                {
                    outValueRepeat = 0;
                }              
                
                return outValueRepeat;
            }
            catch (Exception e)
            {
                throw new HttpException((int)System.Net.HttpStatusCode.NotFound, e.ToString());
            }
            
        }

        #endregion

        #endregion
    }
}
