using Caelum.Stella.CSharp.Format;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.NetCore.Test.Format
{
    [TestClass]
    public class CNPJFormatterTest : IBaseFormatterTest
    {
        private IFormatter formatter;

        [TestInitialize]
        public void TestInitialize()
        {
            formatter = new CNPJFormatter();
        }

        [TestMethod]
        public void TestFormat()
        {
            String unformatedValue = "26637142000158";
            String formatedValue = formatter.Format(unformatedValue);
            Assert.AreEqual(formatedValue, "26.637.142/0001-58");
        }

        [TestMethod]
        public void TestUnformat()
        {
            String formatedValue = "26.637.142/0001-58";
            String unformatedValue = formatter.Unformat(formatedValue);
            Assert.AreEqual(unformatedValue, "26637142000158");
        }

        [TestMethod]
        public void ShouldDetectIfAValueIsFormattedOrNot()
        {
            Assert.IsTrue(formatter.IsFormatted("26.637.142/0001-58"));
            Assert.IsFalse(formatter.IsFormatted("26637142000158"));
            Assert.IsFalse(formatter.IsFormatted("26.7.1x2/00a1-58"));
        }

        [TestMethod]
        public void ShouldDetectIfAValueCanBeFormattedOrNot()
        {
            Assert.IsFalse(formatter.CanBeFormatted("26.637.142/0001-58"));
            Assert.IsTrue(formatter.CanBeFormatted("26637142000158"));
            Assert.IsFalse(formatter.CanBeFormatted("26.7.1x2/00a1-58"));
        }

        [TestMethod]
        public void TestShoudNotThrowExceptionIfAlreadyUnformated()
        {
            String fotmatedValue = "26637142000158";
            String unformatedValue = formatter.Unformat(fotmatedValue);
            Assert.AreEqual(unformatedValue, "26637142000158");
        }
    }
}
