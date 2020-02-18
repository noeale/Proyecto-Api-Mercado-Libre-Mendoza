using ProyectoApi.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProyectoApi.WebApi.Test
{
    public class AnalizeMatrix
    {
        /*********************************************************************************/
        /*                    Analiza el arreglo                                         */
        /*********************************************************************************/
        [Fact]
        //Paso solamente el arreglo con 5 columnas en vez de 6
        public void RowWithIncompleteInformationShouldNotIsMutan()
        {
            //Arange
            string[] dna = { "ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA"};
            bool expected = false;
            //Act
            bool actual = AnalyzeMatrix.AnalyzeNXN(dna);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        //Paso el arreglo con 6 columnas pero a la primera le faltan datos
        public void ColumnWithIncompleteShouldNotIsMutan()
        {
            //Arange
            String[] dna = { "ATG", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            bool expected = false;
            //Act
            bool actual = AnalyzeMatrix.AnalyzeNXN(dna);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        //Paso el arreglo con datos incorrectos en la tercer columna agrego una X que no corresponde
        public void DnaIsIncorrectShouldNotBeMutant()
        {
            //Arange
            String[] dna = { "CAGTGC", "CAGTGC", "TTXTGT", "AGAAGG", "CCCCTA", "TCACTG" };
            bool expected = false;
            //Act
            bool actual = AnalyzeMatrix.AnalyzeNXN(dna);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
