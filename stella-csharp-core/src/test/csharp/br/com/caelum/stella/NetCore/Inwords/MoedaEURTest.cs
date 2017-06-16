using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caelum.Stella.CSharp.Inwords.Test
{
    [TestClass]
    public class MoedaEURTest
    {
        [TestInitialize]    
        public void Initialize()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotTransformNegativeDouble()
        {
            string extenso = new MoedaEUR(-1).Extenso();
        }

        [TestMethod]
        public void ShouldTransform0InWords()
        {
            string extenso = new MoedaEUR(0).Extenso();
            Assert.AreEqual("zero euro", extenso);
        }

        [TestMethod]
        public void ShouldTransform99CentsInWords()
        {
            string extenso = new MoedaEUR(0.99).Extenso();
            Assert.AreEqual("noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1InWords()
        {
            string extenso = new MoedaEUR(1).Extenso();
            Assert.AreEqual("um euro", extenso);
        }

        [TestMethod]
        public void ShouldTransform1and37CentsInWords()
        {
            string extenso = new MoedaEUR(1.37).Extenso();
            Assert.AreEqual("um euro e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform2InWords()
        {
            string extenso = new MoedaEUR(2).Extenso();
            Assert.AreEqual("dois euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform2and37CentsInWords()
        {
            string extenso = new MoedaEUR(2.37).Extenso();
            Assert.AreEqual("dois euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform14InWords()
        {
            string extenso = new MoedaEUR(14).Extenso();
            Assert.AreEqual("quatorze euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform14and37CentsInWords()
        {
            string extenso = new MoedaEUR(14.37).Extenso();
            Assert.AreEqual("quatorze euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform53InWordsUsingAnd()
        {
            string extenso = new MoedaEUR(53).Extenso();
            Assert.AreEqual("cinquenta e três euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform53and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(53.37).Extenso();
            Assert.AreEqual("cinquenta e três euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform99InWordsUsingAnd()
        {
            string extenso = new MoedaEUR(99).Extenso();
            Assert.AreEqual("noventa e nove euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform99and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(99.37).Extenso();
            Assert.AreEqual("noventa e nove euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredInWords()
        {
            string extenso = new MoedaEUR(100).Extenso();
            Assert.AreEqual("cem euros", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredand37CentsInWords()
        {
            string extenso = new MoedaEUR(100.37).Extenso();
            Assert.AreEqual("cem euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform101InWordsUsingAnd()
        {
            string extenso = new MoedaEUR(101).Extenso();
            Assert.AreEqual("cento e um euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform101and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(101.37).Extenso();
            Assert.AreEqual("cento e um euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform199InWordsUsingAnd()
        {
            string extenso = new MoedaEUR(199).Extenso();
            Assert.AreEqual("cento e noventa e nove euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform199and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(199.37).Extenso();
            Assert.AreEqual("cento e noventa e nove euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform200InWordsUsingAnd()
        {
            string extenso = new MoedaEUR(200).Extenso();
            Assert.AreEqual("duzentos euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform200and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(200.37).Extenso();
            Assert.AreEqual("duzentos euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform201InWordsUsingAnd()
        {
            string extenso = new MoedaEUR(201).Extenso();
            Assert.AreEqual("duzentos e um euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform201and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(201.37).Extenso();
            Assert.AreEqual("duzentos e um euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform999InWords()
        {
            string extenso = new MoedaEUR(999).Extenso();
            Assert.AreEqual("novecentos e noventa e nove euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform999and37CentsInWords()
        {
            string extenso = new MoedaEUR(999.37).Extenso();
            Assert.AreEqual("novecentos e noventa e nove euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWords()
        {
            string extenso = new MoedaEUR(1000).Extenso();
            Assert.AreEqual("um mil euros", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandand37CentsInWords()
        {
            string extenso = new MoedaEUR(1000.37).Extenso();
            Assert.AreEqual("um mil euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001InWords()
        {
            string extenso = new MoedaEUR(1001).Extenso();
            Assert.AreEqual("um mil e um euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001and37CentsInWords()
        {
            string extenso = new MoedaEUR(1001.37).Extenso();
            Assert.AreEqual("um mil e um euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(1031).Extenso();
            Assert.AreEqual("um mil e trinta e um euros", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandand37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(1031.37).Extenso();
            Assert.AreEqual("um mil e trinta e um euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingSingular()
        {
            string extenso = new MoedaEUR(1000000).Extenso();
            Assert.AreEqual("um milhão de euros", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionand37CentsIntoNumberInWordsUsingSingular()
        {
            string extenso = new MoedaEUR(1000000.37).Extenso();
            Assert.AreEqual("um milhão de euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(1000150.99).Extenso();
            Assert.AreEqual("um milhão e cento e cinquenta euros e noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(1023850).Extenso();
            Assert.AreEqual("um milhão, vinte e três mil oitocentos e cinquenta euros", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandand37CentsIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaEUR(1023850.37).Extenso();
            Assert.AreEqual("um milhão, vinte e três mil oitocentos e cinquenta euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformTwoMillionUsingPlural()
        {
            string extenso = new MoedaEUR(2e6).Extenso();
            Assert.AreEqual("dois milhões de euros", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberInWordsUsingFraction()
        {
            string extenso = new MoedaEUR(222).Extenso();
            Assert.AreEqual("duzentos e vinte e dois euros", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberand37CentsInWordsUsingFraction()
        {
            string extenso = new MoedaEUR(222.37).Extenso();
            Assert.AreEqual("duzentos e vinte e dois euros e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1E21()
        {
            string extenso = new MoedaEUR(1E21).Extenso();
            Assert.AreEqual("um sextilhão de euros", extenso);
        }

        [TestMethod]
        public void ShouldTransform2E21()
        {
            string extenso = new MoedaEUR(2E21).Extenso();
            Assert.AreEqual("dois sextilhões de euros", extenso);
        }
    }
}
