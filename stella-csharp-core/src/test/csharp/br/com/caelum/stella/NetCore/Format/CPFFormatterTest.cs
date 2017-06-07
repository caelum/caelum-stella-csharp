using Caelum.Stella.CSharp.Format;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.NetCore.Test.Format
{
    [TestClass]
    public class CPFFormatterTest : IBaseFormatterTest
    {
        private IFormatter formatter;

        [TestInitialize]
        public void TestInitialize()
        {
            formatter = new CPFFormatter();
        }

        [TestMethod]
        public void TestFormat()
        {
            String unformattedValue = "11122233344";
            String formattedValue = formatter.Format(unformattedValue);
            Assert.AreEqual(formattedValue, "111.222.333-44");
        }

        [TestMethod]
        public void TestUnformat()
        {
            String formattedValue = "111.222.333-44";
            String unformattedValue = formatter.Unformat(formattedValue);
            Assert.AreEqual(unformattedValue, "11122233344");
        }

        [TestMethod]
        public void ShouldDetectIfAValueIsFormattedOrNot()
        {
            Assert.IsTrue(formatter.IsFormatted("111.222.333-44"));
            Assert.IsFalse(formatter.IsFormatted("11122233344"));
            Assert.IsFalse(formatter.IsFormatted("1.1a1.1-2"));
        }

        [TestMethod]
        public void ShouldDetectIfAValueCanBeFormattedOrNot()
        {
            Assert.IsFalse(formatter.CanBeFormatted("111.222.333-44"));
            Assert.IsTrue(formatter.CanBeFormatted("11122233344"));
            Assert.IsFalse(formatter.CanBeFormatted("1.1a1.1-2"));
        }
    }
}
