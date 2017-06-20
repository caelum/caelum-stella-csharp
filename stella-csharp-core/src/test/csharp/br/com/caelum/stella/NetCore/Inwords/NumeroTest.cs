using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caelum.Stella.CSharp.Inwords.Test
{
    [TestClass]
    public class NumeroTest
    {
        [TestInitialize]    
        public void Initialize()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotTransformNegativeDouble()
        {
            string extenso = new Numero(-1).Extenso();
        }

        [TestMethod]
        public void ShouldTransform0InWords()
        {
            string extenso = new Numero(0).Extenso();
            Assert.AreEqual("zero", extenso);
        }

        [TestMethod]
        public void ShouldTransform1InWords()
        {
            string extenso = new Numero(1).Extenso();
            Assert.AreEqual("um", extenso);
        }

        [TestMethod]
        public void ShouldTransform2InWords()
        {
            string extenso = new Numero(2).Extenso();
            Assert.AreEqual("dois", extenso);
        }

        [TestMethod]
        public void ShouldTransform14InWords()
        {
            string extenso = new Numero(14).Extenso();
            Assert.AreEqual("quatorze", extenso);
        }

        [TestMethod]
        public void ShouldTransform53InWordsUsingAnd()
        {
            string extenso = new Numero(53).Extenso();
            Assert.AreEqual("cinquenta e três", extenso);
        }

        [TestMethod]
        public void ShouldTransform99InWordsUsingAnd()
        {
            string extenso = new Numero(99).Extenso();
            Assert.AreEqual("noventa e nove", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredInWords()
        {
            string extenso = new Numero(100).Extenso();
            Assert.AreEqual("cem", extenso);
        }

        [TestMethod]
        public void ShouldTransform101InWordsUsingAnd()
        {
            string extenso = new Numero(101).Extenso();
            Assert.AreEqual("cento e um", extenso);
        }

        [TestMethod]
        public void ShouldTransform199InWordsUsingAnd()
        {
            string extenso = new Numero(199).Extenso();
            Assert.AreEqual("cento e noventa e nove", extenso);
        }

        [TestMethod]
        public void ShouldTransform200InWordsUsingAnd()
        {
            string extenso = new Numero(200).Extenso();
            Assert.AreEqual("duzentos", extenso);
        }

        [TestMethod]
        public void ShouldTransform201InWordsUsingAnd()
        {
            string extenso = new Numero(201).Extenso();
            Assert.AreEqual("duzentos e um", extenso);
        }

        [TestMethod]
        public void ShouldTransform999InWords()
        {
            string extenso = new Numero(999).Extenso();
            Assert.AreEqual("novecentos e noventa e nove", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWords()
        {
            string extenso = new Numero(1000).Extenso();
            Assert.AreEqual("um mil", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001InWords()
        {
            string extenso = new Numero(1001).Extenso();
            Assert.AreEqual("um mil e um", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWordsUsingAnd()
        {
            string extenso = new Numero(1031).Extenso();
            Assert.AreEqual("um mil e trinta e um", extenso);
        }

        [TestMethod]
        public void ShouldTransform3108InWords()
        {
            string extenso = new Numero(3108).Extenso();
            Assert.AreEqual("três mil cento e oito", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingSingular()
        {
            string extenso = new Numero(1000000).Extenso();
            Assert.AreEqual("um milhão", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingAnd()
        {
            string extenso = new Numero(1000150.99).Extenso();
            Assert.AreEqual("um milhão e cento e cinquenta e um", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandIntoNumberInWordsUsingAnd()
        {
            string extenso = new Numero(1023850).Extenso();
            Assert.AreEqual("um milhão, vinte e três mil oitocentos e cinquenta", extenso);
        }

        [TestMethod]
        public void ShouldTransformTwoMillionUsingPlural()
        {
            string extenso = new Numero(2e6).Extenso();
            Assert.AreEqual("dois milhões", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberInWordsUsingFraction()
        {
            string extenso = new Numero(222).Extenso();
            Assert.AreEqual("duzentos e vinte e dois", extenso);
        }

        [TestMethod]
        public void ShouldTransform1E21()
        {
            string extenso = new Numero(1E21).Extenso();
            Assert.AreEqual("um sextilhão", extenso);
        }

        [TestMethod]
        public void ShouldTransform2E21()
        {
            string extenso = new Numero(2E21).Extenso();
            Assert.AreEqual("dois sextilhões", extenso);
        }
    }
}
