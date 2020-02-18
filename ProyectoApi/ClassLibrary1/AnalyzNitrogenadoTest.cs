using ProyectoApi.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProyectoApi.WebApi.Test
{
    public class AnalyzNitrogenadoTest
    {
        [Fact]
        //Analiza si los datos que le paso estan dentro del nitrogeno permitido
        public void AnalizNitrogenadoFalse()
        {
            //Arange
            string[] dna = { "XTGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA" };
            bool expected = false;
            //Act
            var actual = AnalyzeNitrogenado.SearchNitrogeno(dna);
            //Assert
            Assert.Equal(expected, actual.outNitro);
        }
        [Fact]
        //Analiza si los datos que le paso estan dentro del nitrogeno permitido
        public void AnalizNitrogenadoToNumberFalse()
        {
            //Arange
            string[] dna = { "789456", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA" };
            bool expected = false;
            //Act
            var actual = AnalyzeNitrogenado.SearchNitrogeno(dna);
            //Assert
            Assert.Equal(expected, actual.outNitro);
        }
        [Fact]
        public void AnalizNitrogenadoTrue()
        {
            //Arange
            string[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            bool expected = true;
            //Act
            var actual = AnalyzeNitrogenado.SearchNitrogeno(dna);
            //Assert
            Assert.Equal(expected, actual.outNitro);
        }
    }
}
