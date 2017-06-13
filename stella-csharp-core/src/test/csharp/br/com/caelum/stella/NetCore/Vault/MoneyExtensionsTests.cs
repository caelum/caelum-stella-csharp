using Caelum.Stella.CSharp.Vault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.NetCore.Test.Vault
{
    [TestClass]
    public class MoneyExtensionsTests
    {
        [TestMethod]
        public void ExtensoPara1real99centavos()
        {
            var money = new Money(Currency.BRL, 1.99);
            var extenso = money.Extenso();

            Assert.AreEqual("um real e noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ExtensoPara12reais34centavos()
        {
            var money = new Money(Currency.BRL, 12.34);
            var extenso = money.Extenso();

            Assert.AreEqual("doze reais e trinta e quatro centavos", extenso);
        }

        [TestMethod]
        public void ExtensoPara1dolar99centavos()
        {
            var money = new Money(Currency.USD, 1.99);
            var extenso = money.Extenso();

            Assert.AreEqual("um dólar e noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ExtensoPara12dolares34centavos()
        {
            var money = new Money(Currency.USD, 12.34);
            var extenso = money.Extenso();

            Assert.AreEqual("doze dólares e trinta e quatro centavos", extenso);
        }

        [TestMethod]
        public void ExtensoPara1euro99centavos()
        {
            var money = new Money(Currency.EUR, 1.99);
            var extenso = money.Extenso();

            Assert.AreEqual("um euro e noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ExtensoPara12euros34centavos()
        {
            var money = new Money(Currency.EUR, 12.34);
            var extenso = money.Extenso();

            Assert.AreEqual("doze euros e trinta e quatro centavos", extenso);
        }
    }
}
