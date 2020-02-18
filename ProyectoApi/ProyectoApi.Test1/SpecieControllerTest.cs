using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoApi.Test1
{
    [TestClass]
    public class SpecieControllerTest
    {
        private SpecieServiceFake specieServiceFake;
        public SpecieControllerTest()
        {
            specieServiceFake = new SpecieServiceFake();
        }
        [TestMethod]
        public void AdnIngresadoInvalido()
        {
            
        }
    }
}
