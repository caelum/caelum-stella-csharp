using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaelumStellaCSharp.Test
{
    [TestClass]
    public class NumeroBRTest
    {
        NumeroBR numeroBR;

        [TestInitialize]    
        public void Initialize()
        {
            numeroBR = new NumeroBR();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void shouldNotTransformNegativeDouble()
        {
            string extenso = numeroBR.Extenso(-1);
        }

        [TestMethod]
        public void shouldTransform0InWords()
        {
            string extenso = numeroBR.Extenso(0);
            Assert.AreEqual("zero", extenso);
        }

        [TestMethod]
        public void shouldTransform1InWords()
        {
            string extenso = numeroBR.Extenso(1);
            Assert.AreEqual("um", extenso);
        }

        [TestMethod]
        public void shouldTransform2InWords()
        {
            string extenso = numeroBR.Extenso(2);
            Assert.AreEqual("dois", extenso);
        }

        [TestMethod]
        public void shouldTransform14InWords()
        {
            string extenso = numeroBR.Extenso(14);
            Assert.AreEqual("quatorze", extenso);
        }

        [TestMethod]
        public void shouldTransform53InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(53);
            Assert.AreEqual("cinquenta e três", extenso);
        }

        [TestMethod]
        public void shouldTransform99InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(99);
            Assert.AreEqual("noventa e nove", extenso);
        }

        [TestMethod]
        public void shouldTransformOneHundredInWords()
        {
            string extenso = numeroBR.Extenso(100);
            Assert.AreEqual("cem", extenso);
        }

        [TestMethod]
        public void shouldTransform101InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(101);
            Assert.AreEqual("cento e um", extenso);
        }

        [TestMethod]
        public void shouldTransform199InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(199);
            Assert.AreEqual("cento e noventa e nove", extenso);
        }

        [TestMethod]
        public void shouldTransform200InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(200);
            Assert.AreEqual("duzentos", extenso);
        }

        [TestMethod]
        public void shouldTransform201InWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(201);
            Assert.AreEqual("duzentos e um", extenso);
        }

        [TestMethod]
        public void shouldTransform999InWords()
        {
            string extenso = numeroBR.Extenso(999);
            Assert.AreEqual("novecentos e noventa e nove", extenso);
        }

        [TestMethod]
        public void shouldTransformThousandInWords()
        {
            string extenso = numeroBR.Extenso(1000);
            Assert.AreEqual("um mil", extenso);
        }

        [TestMethod]
        public void shouldTransform1001InWords()
        {
            string extenso = numeroBR.Extenso(1001);
            Assert.AreEqual("um mil e um", extenso);
        }

        [TestMethod]
        public void shouldTransformThousandInWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(1031);
            Assert.AreEqual("um mil e trinta e um", extenso);
        }

        [TestMethod]
        public void shouldTransformAMillionIntoNumberInWordsUsingSingular()
        {
            string extenso = numeroBR.Extenso(1000000);
            Assert.AreEqual("um milhão", extenso);
        }

        [TestMethod]
        public void shouldTransformAMillionIntoNumberInWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(1000150.99);
            Assert.AreEqual("um milhão e cento e cinquenta e um", extenso);
        }

        [TestMethod]
        public void shouldTransformAMillionAndThousandIntoNumberInWordsUsingAnd()
        {
            string extenso = numeroBR.Extenso(1023850);
            Assert.AreEqual("um milhão, vinte e três mil e oitocentos e cinquenta", extenso);
        }

        [TestMethod]
        public void shouldTransformTwoMillionUsingPlural()
        {
            string extenso = numeroBR.Extenso(2e6);
            Assert.AreEqual("dois milhões", extenso);
        }

        [TestMethod]
        public void shouldTransformANumberInWordsUsingFraction()
        {
            string extenso = numeroBR.Extenso(222);
            Assert.AreEqual("duzentos e vinte e dois", extenso);
        }

        [TestMethod]
        public void shouldTransform1E21()
        {
            string extenso = numeroBR.Extenso(1E21);
            Assert.AreEqual("um sextilhão", extenso);
        }

        [TestMethod]
        public void shouldTransform2E21()
        {
            string extenso = numeroBR.Extenso(2E21);
            Assert.AreEqual("dois sextilhões", extenso);
        }
    }
}
