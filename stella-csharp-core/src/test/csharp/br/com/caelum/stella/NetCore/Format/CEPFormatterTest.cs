using Caelum.Stella.CSharp.Format;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.NetCore.Test.Format
{
    [TestClass]
    public class CEPFormatterTest : IBaseFormatterTest
    {
        private IFormatter formatter;

        [TestInitialize]
        public void TestInitialize()
        {
            formatter = new CEPFormatter();
        }

        [TestMethod]
        public void TestFormat()
        {
            string unformatedValue = "12345678";
            string formatedValue = formatter.Format(unformatedValue);
            Assert.AreEqual(formatedValue, "12345-678");
        }

        [TestMethod]
        public void TestUnformat()
        {
            String unformatedValue = "12345-678";
            String formatedValue = formatter.Unformat(unformatedValue);
            Assert.AreEqual(formatedValue, "12345678");
        }

        [TestMethod]
        public void ShouldDetectIfAValueIsFormattedOrNot()
        {
            Assert.IsTrue(formatter.IsFormatted("12345-678"));
            Assert.IsFalse(formatter.IsFormatted("12345678"));
            Assert.IsFalse(formatter.IsFormatted("12345-67a"));
        }

        [TestMethod]
        public void ShouldDetectIfAValueCanBeFormattedOrNot()
        {
            Assert.IsFalse(formatter.CanBeFormatted("12345-678"));
            Assert.IsTrue(formatter.CanBeFormatted("12345678"));
            Assert.IsFalse(formatter.CanBeFormatted("12345-678"));
        }

        [TestMethod]
        public void TestShoudNotThrowExceptionIfAlreadyUnformated()
        {
            String formatedValue = "12345678";
            String unformatedValue = formatter.Unformat(formatedValue);
            Assert.AreEqual(unformatedValue, "12345678");
        }
    }
}
