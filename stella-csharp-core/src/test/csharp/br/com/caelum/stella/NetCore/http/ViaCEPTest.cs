using CaelumStellaCSharp.http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaelumStellaCSharp.Test.http
{
    [TestClass]
    public class ViaCEPTest
    {
        ViaCEP viaCEP;

        [TestInitialize]
        public void Initialize()
        {
            viaCEP = new ViaCEP();
        }

        [TestMethod]
        public async Task GetEndereco()
        {
            var endereco = await viaCEP.GetEndereco("07091000");
        }
    }
}
