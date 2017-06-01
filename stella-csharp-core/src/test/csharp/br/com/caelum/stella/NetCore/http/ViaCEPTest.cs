using Caelum.Stella.CSharp.Http;
using Caelum.Stella.CSharp.Http.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace Caelum.Stella.CSharp.Test.Http
{
    [TestClass]
    public class ViaCEPTest
    {
        private const int DEFAULT_VIACEP_REQUEST_DELAY = 100;
        ViaCEP viaCEP;

        [TestInitialize]
        public void Initialize()
        {
            viaCEP = new ViaCEP();
        }

        #region ShouldGetAddressAsXml

        [TestMethod]
        public async Task ShouldGetAddressAsXmlAsync()
        {
            var xmlAddress = await viaCEP.GetEnderecoXmlAsync("04101300");
            Assert.IsNotNull(xmlAddress);
            Assert.IsTrue(xmlAddress.ToString().Contains("<xmlcep>"));
            Assert.IsTrue(xmlAddress.ToString().Contains("<logradouro>Rua Vergueiro</logradouro>"));
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            xmlAddress = await viaCEP.GetEnderecoXmlAsync("04101-300");
            Assert.IsNotNull(xmlAddress);
            Assert.IsTrue(xmlAddress.ToString().Contains("<xmlcep>"));
            Assert.IsTrue(xmlAddress.ToString().Contains("<logradouro>Rua Vergueiro</logradouro>"));
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        [TestMethod]
        public void ShouldGetAddressAsXml()
        {
            var xmlAddress = viaCEP.GetEnderecoXml("04101300");
            Assert.IsNotNull(xmlAddress);
            Assert.IsTrue(xmlAddress.ToString().Contains("<xmlcep>"));
            Assert.IsTrue(xmlAddress.ToString().Contains("<logradouro>Rua Vergueiro</logradouro>"));
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            xmlAddress = viaCEP.GetEnderecoXml("04101-300");
            Assert.IsNotNull(xmlAddress);
            Assert.IsTrue(xmlAddress.ToString().Contains("<xmlcep>"));
            Assert.IsTrue(xmlAddress.ToString().Contains("<logradouro>Rua Vergueiro</logradouro>"));
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        #endregion

        #region ShouldGetAddressAsQuerty

        [TestMethod]
        public async Task ShouldGetAddressAsQuertyAsync()
        {
            var quertyAddress = await viaCEP.GetEnderecoQuertyAsync("04101300");
            Assert.IsTrue(quertyAddress.Contains("cep=04101-300&logradouro=Rua+Vergueiro"));
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            quertyAddress = await viaCEP.GetEnderecoQuertyAsync("04101-300");
            Assert.IsTrue(quertyAddress.Contains("cep=04101-300&logradouro=Rua+Vergueiro"));
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        [TestMethod]
        public void ShouldGetAddressAsQuerty()
        {
            var quertyAddress = viaCEP.GetEnderecoQuerty("04101300");
            Assert.IsTrue(quertyAddress.Contains("cep=04101-300&logradouro=Rua+Vergueiro"));
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            quertyAddress = viaCEP.GetEnderecoQuerty("04101-300");
            Assert.IsTrue(quertyAddress.Contains("cep=04101-300&logradouro=Rua+Vergueiro"));
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        #endregion

        #region ShouldGetAddressAsPiped

        [TestMethod]
        public async Task ShouldGetAddressAsPipedAsync()
        {
            var pipedAddress = await viaCEP.GetEnderecoPipedAsync("04101300");
            Assert.IsTrue(pipedAddress.Contains("cep:04101-300|logradouro:Rua Vergueiro"));
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            pipedAddress = await viaCEP.GetEnderecoPipedAsync("04101-300");
            Assert.IsTrue(pipedAddress.Contains("cep:04101-300|logradouro:Rua Vergueiro"));
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        [TestMethod]
        public void ShouldGetAddressAsPiped()
        {
            var pipedAddress = viaCEP.GetEnderecoPiped("04101300");
            Assert.IsTrue(pipedAddress.Contains("cep:04101-300|logradouro:Rua Vergueiro"));
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            pipedAddress = viaCEP.GetEnderecoPiped("04101-300");
            Assert.IsTrue(pipedAddress.Contains("cep:04101-300|logradouro:Rua Vergueiro"));
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        #endregion

        #region ShouldGetAddressAsJson

        [TestMethod]
        public async Task ShouldGetAddressAsJsonAsync()
        {
            var jsonAddress = await viaCEP.GetEnderecoJsonAsync("04101300");
            Assert.IsTrue(jsonAddress.Contains("\"cep\": \"04101-300\""));
            Assert.IsTrue(jsonAddress.Contains("\"logradouro\": \"Rua Vergueiro\""));
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            jsonAddress = await viaCEP.GetEnderecoJsonAsync("04101-300");
            Assert.IsTrue(jsonAddress.Contains("\"cep\": \"04101-300\""));
            Assert.IsTrue(jsonAddress.Contains("\"logradouro\": \"Rua Vergueiro\""));
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        [TestMethod]
        public void ShouldGetAddressAsJson()
        {
            var jsonAddress = viaCEP.GetEnderecoJson("04101300");
            Assert.IsTrue(jsonAddress.Contains("\"cep\": \"04101-300\""));
            Assert.IsTrue(jsonAddress.Contains("\"logradouro\": \"Rua Vergueiro\""));
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            jsonAddress = viaCEP.GetEnderecoJson("04101-300");
            Assert.IsTrue(jsonAddress.Contains("\"cep\": \"04101-300\""));
            Assert.IsTrue(jsonAddress.Contains("\"logradouro\": \"Rua Vergueiro\""));
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        #endregion

        #region ShouldGetAddress

        [TestMethod]
        public async Task ShouldGetAddressAsync()
        {
            var endereco = await viaCEP.GetEnderecoAsync("04101300");
            Assert.IsNotNull(endereco);
            Assert.AreEqual("04101-300", endereco.CEP);
            Assert.AreEqual("Rua Vergueiro", endereco.Logradouro);
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            endereco = await viaCEP.GetEnderecoAsync("04101-300");
            Assert.IsNotNull(endereco);
            Assert.AreEqual("04101-300", endereco.CEP);
            Assert.AreEqual("Rua Vergueiro", endereco.Logradouro);
            await Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        [TestMethod]
        public void ShouldGetAddress()
        {
            var endereco = viaCEP.GetEndereco("04101300");
            Assert.IsNotNull(endereco);
            Assert.AreEqual("04101-300", endereco.CEP);
            Assert.AreEqual("Rua Vergueiro", endereco.Logradouro);
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);

            endereco = viaCEP.GetEndereco("04101-300");
            Assert.IsNotNull(endereco);
            Assert.AreEqual("04101-300", endereco.CEP);
            Assert.AreEqual("Rua Vergueiro", endereco.Logradouro);
            Task.Delay(DEFAULT_VIACEP_REQUEST_DELAY);
        }

        [TestMethod]
        [ExpectedException(typeof(ZipCodeDoesNotExist))]
        public void ShouldFailWhenZipCodeDoesNotExist()
        {
            viaCEP.GetEndereco("00000-000");
        }

        #endregion


        #region Failed Tests

        [TestMethod]
        public void ShouldFailUponErrorStatusCode()
        {
            HttpStatusCode[] expectedStatusCode = new HttpStatusCode[]
            {
                HttpStatusCode.GatewayTimeout,
                HttpStatusCode.InternalServerError,
                HttpStatusCode.ProxyAuthenticationRequired,
                HttpStatusCode.Unauthorized,
                HttpStatusCode.Forbidden,
                HttpStatusCode.MethodNotAllowed,
                HttpStatusCode.ServiceUnavailable
            };
            foreach (var statusCode in expectedStatusCode)
            {
                ShouldFailUponRequestOfSameStatusCode(statusCode);
            }
        }

        private void ShouldFailUponRequestOfSameStatusCode(HttpStatusCode expectedStatusCode)
        {
            try
            {
                var jsonAddress =
                    new ViaCEP(new BrokenClientHandler(expectedStatusCode))
                        .GetEnderecoJson("04101300");
                Assert.Fail();
            }
            catch (HttpRequestFailException exc)
            {
                if (exc.StatusCode != expectedStatusCode)
                    Assert.Fail();
            }
        }

        #endregion
    }
}
