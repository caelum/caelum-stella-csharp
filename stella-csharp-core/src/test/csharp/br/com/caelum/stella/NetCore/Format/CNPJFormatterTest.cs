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
            Assert.AreEqual("26.637.142/0001-58", formatedValue);
        }

        [TestMethod]
        public void TestUnformat()
        {
            String formatedValue = "98.610.832/0001-24";
            String unformatedValue = formatter.Unformat(formatedValue);
            Assert.AreEqual("98610832000124", unformatedValue);
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
            Assert.AreEqual("26637142000158", unformatedValue);
        }
    }
}
