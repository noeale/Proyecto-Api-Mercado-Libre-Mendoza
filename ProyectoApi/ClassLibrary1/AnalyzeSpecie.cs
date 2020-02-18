using ProyectoApi.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace ProyectoApi.WebApi.Test
{
    public class AnalyzeSpecie
    {
        /*********************************************************************************/
        /*                    Analiza matrix en forma horizontal                         */
        /*********************************************************************************/
        [Fact]
        //Paso la matriz y me analiza en forma horizontal pero no deberia ser un mutante
        public void HorizontalSequenceShouldNotIsMutant()
        {
            //Arange
            String[] dna = { "ATGCGA", "AATACC", "TTATGT", "AGAGGG", "CCCCTA", "TCACTG" };
            bool expected = false;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.HorizontalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //Paso la matriz y me analiza en forma horizontal que si es un mutante
        public void HorizontalSequenceShouldIsMutant()
        {
            //Arange
            String[] dna = { "AAAAGA", "AATACC", "TTATGT", "AGAGGG", "CCCCTA", "TCACTG" };
            bool expected = true;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.HorizontalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HorizontalSequenceFiveDnaShouldNotBeMutant()
        {
            //Arange
            String[] dna = { "ATGCGA", "AAAAAC", "TTATGT", "AGAGGG", "CTCCTA", "TCACTG" };
            bool expected = false;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.HorizontalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HorizontalSequenceInLimitsShouldNotBeMutant()
        {
            //Arange
            string[] dna = { "ATAAAA", "ACATAC", "TTGTGT", "AGAAGG", "CTCCTA", "TCAAAG" };
            bool expected = false;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.HorizontalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HorizontalSequenceInLimitsShouldIsMutant()
        {
            //Arange
            string[] dna = { "ATAAAA", "ACATAC", "TTGTGT", "AGAAGG", "CTCCTA", "TCAAAA" };
            bool expected = true;
            //Act
            bool actual = true;
            int countLine = AnalyzeEspecie.HorizontalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HorizontalOneSequenceCorrelativesShouldNotMutant()
        {
            //Arange
            string[] dna = { "AAAAAAAT", "TGTGTGTG", "CTCTCTCT", "CGCGCGCG", "ATATATAT", "ACACACAC", "CACACACA", "GAGAGAGA" };
            bool expected = false;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.HorizontalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void HorizontalTwoSequenceCorrelativesShouldIsMutant()
        {
            //Arange
            string[] dna = { "AAAAAAAA", "TGTGTGTG", "CTCTCTCT", "CGCGCGCG", "ATATATAT", "ACACACAC", "CACACACA", "GAGAGAGA" };
            bool expected = true;
            //Act
            bool actual = true;
            int countLine = AnalyzeEspecie.HorizontalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }

        /*********************************************************************************/
        /*                    Analiza matrix en forma vertical                         */
        /*********************************************************************************/
        [Fact]
        //Paso la matriz y me analiza en forma vertical pero no deberia ser un mutante
        public void VerticalSequenceShouldNotIsMutant()
        {
            //Arange
            string[] dna = { "ATGCGA", "AATACC", "ATATGT", "AGAGGG", "ACCCTA", "ACACTG" };
            bool expected = false;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.VerticalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //Paso la matriz y me analiza en forma vertical que si es un mutante
        public void VerticalSequenceShouldIsMutant()
        {
            //Arange
            string[] dna = { "ATGCGA", "ATTACC", "ATATGT", "ATAGGG", "ATCCTA", "ATACTG" };
            bool expected = true;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.VerticalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //Paso la matriz y me analiza en forma vertical que si es un mutante
        public void VerticalSequenceInLimitsShouldNotMutant()
        {
            //Arange
            string[] dna = { "CTGCGA", "CTTAAT", "ACATGC", "ATAAGC", "ATCCTC", "ACACTT" };
            bool expected = false;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.VerticalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //Paso la matriz y me analiza en forma vertical que si es un mutante
        public void VerticalSequenceInLimitsShouldISMutant()
        {
            //Arange
            string[] dna = { "CTGCGA", "CTTAAT", "ACATGC", "ATAAGC", "ATCCTC", "ACACTC" };
            bool expected = true;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.VerticalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //Paso la matriz y me analiza en forma vertical que si es un mutante
        public void VerticaltwoSequenceCorrelativesShouldBeMutant()
        {
            //Arange
            string[] dna = { "AGACATAT", "AGTGTGTG", "ATCTCTCT", "AGCGCGCG", "ATATATAT", "ACACACAC", "AACACACA", "AAGAGAGA" };
            bool expected = true;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.VerticalSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine > 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }

        /*********************************************************************************/
        /*                    Analiza matrix en oblicua izquierda a derecha              */
        /*********************************************************************************/
        [Fact]
        //Paso la matriz y me analiza en forma vertical pero no deberia ser un mutante
        public void leftObliqueSequenceShouldNotIsMutant()
        {
            //Arange
            string[] dna = { "ATGCGA", "AATACC", "ATATGT", "AGAGGG", "ACCCTA", "ACACTG" };
            bool expected = false;
            //Act
            bool actual = true;
            int countLine = AnalyzeEspecie.LeftObliqueSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine == 0)
                actual = false;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //Paso la matriz y me analiza en forma vertical que si es un mutante
        public void leftObliqueSequenceShouldIsMutant()
        {
            //Arange
            string[] dna = { "ATGCGG", "CAGTAC", "TTAAAT", "AGAAGG", "CAACAA", "TACCTA" };
            bool expected = true;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.LeftObliqueSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine == 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }
        /*********************************************************************************/
        /*                    Analiza matrix en oblicua izquierda a derecha              */
        /*********************************************************************************/
        [Fact]
        //Paso la matriz y me analiza en forma vertical pero no deberia ser un mutante
        public void rightObliqueSequenceShouldNotIsMutant()
        {
            //Arange
            string[] dna = { "ATGCGA", "AATACC", "ATATGT", "AGAGGG", "ACCCTA", "ACACTG" };
            bool expected = false;
            //Act
            bool actual = true;
            int countLine = AnalyzeEspecie.RightObliqueSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine == 0)
                actual = false;
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        //Paso la matriz y me analiza en forma vertical que si es un mutante
        public void rightObliqueSequenceShouldIsMutant()
        {
            //Arange
            string[] dna = { "ATGCGT", "AATATC", "ATATGT", "ATTAGA", "ATAAT", "TTACTT" };
            bool expected = true;
            //Act
            bool actual = false;
            int countLine = AnalyzeEspecie.RightObliqueSearch(ConvertToMatriz(dna), dna.Length);
            if (countLine == 1)
                actual = true;
            //Assert
            Assert.Equal(expected, actual);
        }

        private string[,] ConvertToMatriz(string[] dna)
        {
            var outMatriz = AnalyzeNitrogenado.SearchNitrogeno(dna);
            return outMatriz.outMatrix;
        }
    }
}
