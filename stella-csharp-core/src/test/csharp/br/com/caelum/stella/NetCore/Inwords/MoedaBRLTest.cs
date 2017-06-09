using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caelum.Stella.CSharp.Inwords.Test
{
    [TestClass]
    public class MoedaBRLTest
    {
        MoedaBRL moedaBR;

        [TestInitialize]    
        public void Initialize()
        {
            moedaBR = new MoedaBRL();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotTransformNegativeDouble()
        {
            string extenso = moedaBR.Extenso(-1);
        }

        [TestMethod]
        public void ShouldTransform0InWords()
        {
            string extenso = moedaBR.Extenso(0);
            Assert.AreEqual("zero real", extenso);
        }

        [TestMethod]
        public void ShouldTransform99CentsInWords()
        {
            string extenso = moedaBR.Extenso(0.99);
            Assert.AreEqual("noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1InWords()
        {
            string extenso = moedaBR.Extenso(1);
            Assert.AreEqual("um real", extenso);
        }

        [TestMethod]
        public void ShouldTransform1and37CentsInWords()
        {
            string extenso = moedaBR.Extenso(1.37);
            Assert.AreEqual("um real e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform2InWords()
        {
            string extenso = moedaBR.Extenso(2);
            Assert.AreEqual("dois reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform2and37CentsInWords()
        {
            string extenso = moedaBR.Extenso(2.37);
            Assert.AreEqual("dois reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform14InWords()
        {
            string extenso = moedaBR.Extenso(14);
            Assert.AreEqual("quatorze reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform14and37CentsInWords()
        {
            string extenso = moedaBR.Extenso(14.37);
            Assert.AreEqual("quatorze reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform53InWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(53);
            Assert.AreEqual("cinquenta e três reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform53and37CentsInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(53.37);
            Assert.AreEqual("cinquenta e três reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform99InWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(99);
            Assert.AreEqual("noventa e nove reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform99and37CentsInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(99.37);
            Assert.AreEqual("noventa e nove reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredInWords()
        {
            string extenso = moedaBR.Extenso(100);
            Assert.AreEqual("cem reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredand37CentsInWords()
        {
            string extenso = moedaBR.Extenso(100.37);
            Assert.AreEqual("cem reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform101InWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(101);
            Assert.AreEqual("cento e um reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform101and37CentsInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(101.37);
            Assert.AreEqual("cento e um reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform199InWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(199);
            Assert.AreEqual("cento e noventa e nove reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform199and37CentsInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(199.37);
            Assert.AreEqual("cento e noventa e nove reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform200InWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(200);
            Assert.AreEqual("duzentos reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform200and37CentsInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(200.37);
            Assert.AreEqual("duzentos reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform201InWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(201);
            Assert.AreEqual("duzentos e um reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform201and37CentsInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(201.37);
            Assert.AreEqual("duzentos e um reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform999InWords()
        {
            string extenso = moedaBR.Extenso(999);
            Assert.AreEqual("novecentos e noventa e nove reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform999and37CentsInWords()
        {
            string extenso = moedaBR.Extenso(999.37);
            Assert.AreEqual("novecentos e noventa e nove reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWords()
        {
            string extenso = moedaBR.Extenso(1000);
            Assert.AreEqual("um mil reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandand37CentsInWords()
        {
            string extenso = moedaBR.Extenso(1000.37);
            Assert.AreEqual("um mil reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001InWords()
        {
            string extenso = moedaBR.Extenso(1001);
            Assert.AreEqual("um mil e um reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001and37CentsInWords()
        {
            string extenso = moedaBR.Extenso(1001.37);
            Assert.AreEqual("um mil e um reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(1031);
            Assert.AreEqual("um mil e trinta e um reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandand37CentsInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(1031.37);
            Assert.AreEqual("um mil e trinta e um reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingSingular()
        {
            string extenso = moedaBR.Extenso(1000000);
            Assert.AreEqual("um milhão de reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionand37CentsIntoNumberInWordsUsingSingular()
        {
            string extenso = moedaBR.Extenso(1000000.37);
            Assert.AreEqual("um milhão de reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(1000150.99);
            Assert.AreEqual("um milhão e cento e cinquenta reais e noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandIntoNumberInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(1023850);
            Assert.AreEqual("um milhão, vinte e três mil e oitocentos e cinquenta reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandand37CentsIntoNumberInWordsUsingAnd()
        {
            string extenso = moedaBR.Extenso(1023850.37);
            Assert.AreEqual("um milhão, vinte e três mil e oitocentos e cinquenta reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformTwoMillionUsingPlural()
        {
            string extenso = moedaBR.Extenso(2e6);
            Assert.AreEqual("dois milhões de reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberInWordsUsingFraction()
        {
            string extenso = moedaBR.Extenso(222);
            Assert.AreEqual("duzentos e vinte e dois reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberand37CentsInWordsUsingFraction()
        {
            string extenso = moedaBR.Extenso(222.37);
            Assert.AreEqual("duzentos e vinte e dois reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1E21()
        {
            string extenso = moedaBR.Extenso(1E21);
            Assert.AreEqual("um sextilhão de reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform2E21()
        {
            string extenso = moedaBR.Extenso(2E21);
            Assert.AreEqual("dois sextilhões de reais", extenso);
        }
    }
}
