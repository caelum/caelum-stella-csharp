using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caelum.Stella.CSharp.Inwords.Test
{
    [TestClass]
    public class NumeroPTTest
    {
        NumeroPT numeroBR;

        [TestInitialize]    
        public void Initialize()
        {
            numeroBR = new NumeroPT();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotTransformNegativeDouble()
        {
            string extenso = numeroBR.Extenso(-1);
        }

        [TestMethod]
        public void ShouldTransform0InWords()
        {
            string extenso = numeroBR.Extenso(0);
            Assert.AreEqual("zero", extenso);
        }

        [TestMethod]
        public void ShouldTransform1InWords()
        {
            string extenso = numeroBR.Extenso(1);
            Assert.AreEqual("um", extenso);
        }

        [TestMethod]
        public void ShouldTransform2InWords()
        {
            string extenso = numeroBR.Extenso(2);
            Assert.AreEqual("dois", extenso);
        }

        [TestMethod]
        public void ShouldTransform14InWords()
        {
            string extenso = numeroBR.Extenso(14);
            Assert.AreEqual("quatorze", extenso);
        }

        [TestMethod]
        public void ShouldTransform53InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(53);
            Assert.AreEqual("cinquenta e três", extenso);
        }

        [TestMethod]
        public void ShouldTransform99InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(99);
            Assert.AreEqual("noventa e nove", extenso);
        }

        [TestMethod]
        public void ShouldTransformOneHundredInWords()
        {
            string extenso = numeroBR.Extenso(100);
            Assert.AreEqual("cem", extenso);
        }

        [TestMethod]
        public void ShouldTransform101InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(101);
            Assert.AreEqual("cento e um", extenso);
        }

        [TestMethod]
        public void ShouldTransform199InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(199);
            Assert.AreEqual("cento e noventa e nove", extenso);
        }

        [TestMethod]
        public void ShouldTransform200InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(200);
            Assert.AreEqual("duzentos", extenso);
        }

        [TestMethod]
        public void ShouldTransform201InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(201);
            Assert.AreEqual("duzentos e um", extenso);
        }

        [TestMethod]
        public void ShouldTransform999InWords()
        {
            string extenso = numeroBR.Extenso(999);
            Assert.AreEqual("novecentos e noventa e nove", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWords()
        {
            string extenso = numeroBR.Extenso(1000);
            Assert.AreEqual("um mil", extenso);
        }

        [TestMethod]
        public void ShouldTransform1001InWords()
        {
            string extenso = numeroBR.Extenso(1001);
            Assert.AreEqual("um mil e um", extenso);
        }

        [TestMethod]
        public void ShouldTransformThousandInWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(1031);
            Assert.AreEqual("um mil e trinta e um", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingSingular()
        {
            string extenso = numeroBR.Extenso(1000000);
            Assert.AreEqual("um milhão", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionIntoNumberInWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(1000150.99);
            Assert.AreEqual("um milhão e cento e cinquenta e um", extenso);
        }

        [TestMethod]
        public void ShouldTransformAMillionAndThousandIntoNumberInWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(1023850);
            Assert.AreEqual("um milhão, vinte e três mil e oitocentos e cinquenta", extenso);
        }

        [TestMethod]
        public void ShouldTransformTwoMillionUsingPlural()
        {
            string extenso = numeroBR.Extenso(2e6);
            Assert.AreEqual("dois milhões", extenso);
        }

        [TestMethod]
        public void ShouldTransformANumberInWordsUsingFraction()
        {
            string extenso = numeroBR.Extenso(222);
            Assert.AreEqual("duzentos e vinte e dois", extenso);
        }

        [TestMethod]
        public void ShouldTransform1E21()
        {
            string extenso = numeroBR.Extenso(1E21);
            Assert.AreEqual("um sextilhão", extenso);
        }

        [TestMethod]
        public void ShouldTransform2E21()
        {
            string extenso = numeroBR.Extenso(2E21);
            Assert.AreEqual("dois sextilhões", extenso);
        }
    }
}
