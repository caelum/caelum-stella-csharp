using Caelum.Stella.CSharp.Vault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Caelum.Stella.CSharp.Inwords.Test
{
    [TestClass]
    public class MoedaBRLTest
    {
        [TestInitialize]    
        public void Initialize()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotTransformNegativeDouble()
        {
            string extenso = new MoedaBRL(-1).Extenso();
        }

        [TestMethod]
        public void ShouldTransform0InWords()
        {
            string extenso = new MoedaBRL(0).Extenso();
            Assert.AreEqual("zero real", extenso);
        }

        [TestMethod]
        public void ShouldTransform99CentsInWords()
        {
            string extenso = new MoedaBRL(0.99).Extenso();
            Assert.AreEqual("noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1InWords()
        {
            string extenso = new MoedaBRL(1).Extenso();
            Assert.AreEqual("um real", extenso);
        }

        [TestMethod]
        public void ShouldTransform1and37CentsInWords()
        {
            string extenso = new MoedaBRL(1.37).Extenso();
            Assert.AreEqual("um real e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform2InWords()
        {
            string extenso = new MoedaBRL(2).Extenso();
            Assert.AreEqual("dois reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform2and37CentsInWords()
        {
            string extenso = new MoedaBRL(2.37).Extenso();
            Assert.AreEqual("dois reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform14InWords()
        {
            string extenso = new MoedaBRL(14).Extenso();
            Assert.AreEqual("quatorze reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform14and37CentsInWords()
        {
            string extenso = new MoedaBRL(14.37).Extenso();
            Assert.AreEqual("quatorze reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform53InWordsUsingAnd()
        {
            string extenso = new MoedaBRL(53).Extenso();
            Assert.AreEqual("cinquenta e três reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform53and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(53.37).Extenso();
            Assert.AreEqual("cinquenta e três reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform99InWordsUsingAnd()
        {
            string extenso = new MoedaBRL(99).Extenso();
            Assert.AreEqual("noventa e nove reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform99and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(99.37).Extenso();
            Assert.AreEqual("noventa e nove reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredInWords()
        {
            string extenso = new MoedaBRL(100).Extenso();
            Assert.AreEqual("cem reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredand37CentsInWords()
        {
            string extenso = new MoedaBRL(100.37).Extenso();
            Assert.AreEqual("cem reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform101InWordsUsingAnd()
        {
            string extenso = new MoedaBRL(101).Extenso();
            Assert.AreEqual("cento e um reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform101and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(101.37).Extenso();
            Assert.AreEqual("cento e um reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform199InWordsUsingAnd()
        {
            string extenso = new MoedaBRL(199).Extenso();
            Assert.AreEqual("cento e noventa e nove reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform199and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(199.37).Extenso();
            Assert.AreEqual("cento e noventa e nove reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform200InWordsUsingAnd()
        {
            string extenso = new MoedaBRL(200).Extenso();
            Assert.AreEqual("duzentos reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform200and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(200.37).Extenso();
            Assert.AreEqual("duzentos reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform201InWordsUsingAnd()
        {
            string extenso = new MoedaBRL(201).Extenso();
            Assert.AreEqual("duzentos e um reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform201and37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(201.37).Extenso();
            Assert.AreEqual("duzentos e um reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform999InWords()
        {
            string extenso = new MoedaBRL(999).Extenso();
            Assert.AreEqual("novecentos e noventa e nove reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform999and37CentsInWords()
        {
            string extenso = new MoedaBRL(999.37).Extenso();
            Assert.AreEqual("novecentos e noventa e nove reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWords()
        {
            string extenso = new MoedaBRL(1000).Extenso();
            Assert.AreEqual("um mil reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandand37CentsInWords()
        {
            string extenso = new MoedaBRL(1000.37).Extenso();
            Assert.AreEqual("um mil reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001InWords()
        {
            string extenso = new MoedaBRL(1001).Extenso();
            Assert.AreEqual("um mil e um reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001and37CentsInWords()
        {
            string extenso = new MoedaBRL(1001.37).Extenso();
            Assert.AreEqual("um mil e um reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(1031).Extenso();
            Assert.AreEqual("um mil e trinta e um reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandand37CentsInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(1031.37).Extenso();
            Assert.AreEqual("um mil e trinta e um reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform3108InWords()
        {
            string extenso = new MoedaBRL(3108).Extenso();
            Assert.AreEqual("três mil cento e oito reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform3108and37CentsInWords()
        {
            string extenso = new MoedaBRL(3108.37).Extenso();
            Assert.AreEqual("três mil cento e oito reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingSingular()
        {
            string extenso = new MoedaBRL(1000000).Extenso();
            Assert.AreEqual("um milhão de reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionand37CentsIntoNumberInWordsUsingSingular()
        {
            string extenso = new MoedaBRL(1000000.37).Extenso();
            Assert.AreEqual("um milhão de reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(1000150.99).Extenso();
            Assert.AreEqual("um milhão e cento e cinquenta reais e noventa e nove centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(1023850).Extenso();
            Assert.AreEqual("um milhão, vinte e três mil oitocentos e cinquenta reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandand37CentsIntoNumberInWordsUsingAnd()
        {
            string extenso = new MoedaBRL(1023850.37).Extenso();
            Assert.AreEqual("um milhão, vinte e três mil oitocentos e cinquenta reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransformTwoMillionUsingPlural()
        {
            string extenso = new MoedaBRL(2e6).Extenso();
            Assert.AreEqual("dois milhões de reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberInWordsUsingFraction()
        {
            string extenso = new MoedaBRL(222).Extenso();
            Assert.AreEqual("duzentos e vinte e dois reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberand37CentsInWordsUsingFraction()
        {
            string extenso = new MoedaBRL(222.37).Extenso();
            Assert.AreEqual("duzentos e vinte e dois reais e trinta e sete centavos", extenso);
        }

        [TestMethod]
        public void ShouldTransform1E21()
        {
            string extenso = new MoedaBRL(1E21).Extenso();
            Assert.AreEqual("um sextilhão de reais", extenso);
        }

        [TestMethod]
        public void ShouldTransform2E21()
        {
            string extenso = new MoedaBRL(2E21).Extenso();
            Assert.AreEqual("dois sextilhões de reais", extenso);
        }

        [TestMethod]
        public void ShouldTransformReais1and37CentsInWords()
        {
            Money money = new Money(new CultureInfo("pt-BR"), 1.37);
            string extenso = new MoedaBRL(money).Extenso();
            Assert.AreEqual("um real e trinta e sete centavos", extenso);
        }

        //[TestMethod]
        //public void ShouldTransformDollars1and37CentsInWords()
        //{
        //    string extenso = new MoedaBRL(new Money(new CultureInfo("en-US"), 1.37)).Extenso();
        //    Assert.AreEqual("um dólar e trinta e sete centavos", extenso);
        //}
    }
}
