using CaelumStellaCSharp;
using CaelumStellaCSharp.validation.error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaelumStellaCSharp.Test
{
    [TestClass]
    public class CNPJValidatorTest
    {
        private CNPJValidator cnpjValidator;

        [TestInitialize()]
        public void Initialize()
        {
            cnpjValidator = new CNPJValidator();
        }

        [TestMethod]
        public void shouldValidateValidCNPJ()
        {
            cnpjValidator.IsValid("11222333000181");
            cnpjValidator.IsValid("63025530002409");
            cnpjValidator.IsValid("61519128000150");
            cnpjValidator.IsValid("68745386000102");
        }

        private void AssertMessage(InvalidStateException invalidStateException
            , String expected)
        {
            Assert.IsTrue(invalidStateException
                .GetErrors().Contains(expected));
        }
    }
}
