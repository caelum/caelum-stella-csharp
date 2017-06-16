using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caelum.Stella.CSharp.Inwords.Test
{
    [TestClass]
    public class MoedaUSDTest
    {
        [TestInitialize]    
        public void Initialize()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotTransformNegativeDouble()
        {
            string extenso = new MoedaUSD(-1).Extenso();
        }

        [TestMethod]
        public void ShouldTransform0InWords()
        {
            string extenso = new MoedaUSD(0).Extenso();
            Assert.AreEqual("zero dólar", extenso);
        }

        [TestMethod]
        public void ShouldTransform99CentsInWords()
        {
            string extenso = new MoedaUSD(0.99).Extenso();
            Assert.AreEqual("noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1InWords()
        {
            string extenso = new MoedaUSD(1).Extenso();
            Assert.AreEqual("um dólar", extenso);
        }

        [TestMethod]
        public void ShouldTransform1and37CentsInWords()
        {
            string extenso = new MoedaUSD(1.37).Extenso();
            Assert.AreEqual("um dólar e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform2InWords()
        {
            string extenso = new MoedaUSD(2).Extenso();
            Assert.AreEqual("dois dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform2and37CentsInWords()
        {
            string extenso = new MoedaUSD(2.37).Extenso();
            Assert.AreEqual("dois dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform14InWords()
        {
            string extenso = new MoedaUSD(14).Extenso();
            Assert.AreEqual("quatorze dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform14and37CentsInWords()
        {
            string extenso = new MoedaUSD(14.37).Extenso();
            Assert.AreEqual("quatorze dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform53InWordsUsingAnd()
        {
            string extenso = new MoedaUSD(53).Extenso();
            Assert.AreEqual("cinquenta e três dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform53and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(53.37).Extenso();
            Assert.AreEqual("cinquenta e três dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform99InWordsUsingAnd()
        {
            string extenso = new MoedaUSD(99).Extenso();
            Assert.AreEqual("noventa e nove dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform99and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(99.37).Extenso();
            Assert.AreEqual("noventa e nove dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredInWords()
        {
            string extenso = new MoedaUSD(100).Extenso();
            Assert.AreEqual("cem dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredand37CentsInWords()
        {
            string extenso = new MoedaUSD(100.37).Extenso();
            Assert.AreEqual("cem dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform101InWordsUsingAnd()
        {
            string extenso = new MoedaUSD(101).Extenso();
            Assert.AreEqual("cento e um dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform101and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(101.37).Extenso();
            Assert.AreEqual("cento e um dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform199InWordsUsingAnd()
        {
            string extenso = new MoedaUSD(199).Extenso();
            Assert.AreEqual("cento e noventa e nove dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform199and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(199.37).Extenso();
            Assert.AreEqual("cento e noventa e nove dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform200InWordsUsingAnd()
        {
            string extenso = new MoedaUSD(200).Extenso();
            Assert.AreEqual("duzentos dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform200and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(200.37).Extenso();
            Assert.AreEqual("duzentos dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform201InWordsUsingAnd()
        {
            string extenso = new MoedaUSD(201).Extenso();
            Assert.AreEqual("duzentos e um dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform201and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(201.37).Extenso();
            Assert.AreEqual("duzentos e um dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform999InWords()
        {
            string extenso = new MoedaUSD(999).Extenso();
            Assert.AreEqual("novecentos e noventa e nove dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform999and37CentsInWords()
        {
            string extenso = new MoedaUSD(999.37).Extenso();
            Assert.AreEqual("novecentos e noventa e nove dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWords()
        {
            string extenso = new MoedaUSD(1000).Extenso();
            Assert.AreEqual("um mil dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandand37CentsInWords()
        {
            string extenso = new MoedaUSD(1000.37).Extenso();
            Assert.AreEqual("um mil dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001InWords()
        {
            string extenso = new MoedaUSD(1001).Extenso();
            Assert.AreEqual("um mil e um dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001and37CentsInWords()
        {
            string extenso = new MoedaUSD(1001.37).Extenso();
            Assert.AreEqual("um mil e um dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(1031).Extenso();
            Assert.AreEqual("um mil e trinta e um dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandand37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(1031.37).Extenso();
            Assert.AreEqual("um mil e trinta e um dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingSingular()
        {
            string extenso = new MoedaUSD(1000000).Extenso();
            Assert.AreEqual("um milhão de dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionand37CentsIntoNumberInWordsUsingSingular()
        {
            string extenso = new MoedaUSD(1000000.37).Extenso();
            Assert.AreEqual("um milhão de dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(1000150.99).Extenso();
            Assert.AreEqual("um milhão e cento e cinquenta dólares e noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(1023850).Extenso();
            Assert.AreEqual("um milhão, vinte e três mil oitocentos e cinquenta dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandand37CentsIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaUSD(1023850.37).Extenso();
            Assert.AreEqual("um milhão, vinte e três mil oitocentos e cinquenta dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformTwoMillionUsingPlural()
        {
            string extenso = new MoedaUSD(2e6).Extenso();
            Assert.AreEqual("dois milhões de dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberInWordsUsingFraction()
        {
            string extenso = new MoedaUSD(222).Extenso();
            Assert.AreEqual("duzentos e vinte e dois dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberand37CentsInWordsUsingFraction()
        {
            string extenso = new MoedaUSD(222.37).Extenso();
            Assert.AreEqual("duzentos e vinte e dois dólares e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1E21()
        {
            string extenso = new MoedaUSD(1E21).Extenso();
            Assert.AreEqual("um sextilhão de dólares", extenso);
        }

        [TestMethod]
        public void ShouldTransform2E21()
        {
            string extenso = new MoedaUSD(2E21).Extenso();
            Assert.AreEqual("dois sextilhões de dólares", extenso);
        }
    }
}
