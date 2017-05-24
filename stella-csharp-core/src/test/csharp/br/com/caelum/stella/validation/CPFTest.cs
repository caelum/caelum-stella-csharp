using CaelumStellaCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaelumStellaCSharp.Test
{
    [TestClass]
    public class CPFTest
    {
        private CPFValidator cpfValidator;

        [TestInitialize()]
        public void Initialize()
        {
            cpfValidator = new CPFValidator();
        }

        [TestMethod]
        public void DeveValidarCPFValido()
        {
            cpfValidator.IsValid("11144477735");
            cpfValidator.IsValid("88641577947");
            cpfValidator.IsValid("34608514300");
            cpfValidator.IsValid("47393545608");
        }

        [TestMethod]
        public void DeveValidarCPFNulo()
        {
            cpfValidator.IsValid(null);
        }

        [TestMethod]
        public void DeveValidarCPFComZerosIniciais()
        {
            cpfValidator.IsValid("01169538452");
        }

        [TestMethod]
        public void NaoDeveValidarCPFComMenosDigitosQueOExigido()
        {
            try
            {
                cpfValidator.IsValid("1234567890");
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                AssertMessage(e, CPFError.InvalidDigits);
            }
        }

        [TestMethod]
        public void NaoDeveValidarCPFComMaisDigitosQueOExigido()
        {
            try
            {
                cpfValidator.IsValid("123456789012");
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                AssertMessage(e, CPFError.InvalidDigits);
            }
        }

        [TestMethod]
        public void NaoDeveValidarCPFComCaracterInvalido()
        {
            try
            {
                cpfValidator.IsValid("1111111a111");
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                Assert.IsTrue(e.GetErrors().Count == 1);
                AssertMessage(e, CPFError.InvalidDigits);
            }
        }

        [TestMethod]
        public void NaoDeveValidarDVComPrimeiroDVErrado()
        {
            // VALID CPF = 248.438.034-80
            try
            {
                cpfValidator.IsValid("24843803470");
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                Assert.IsTrue(e.GetErrors().Count == 1);
                AssertMessage(e, CPFError.InvalidCheckDigits);
            }
        }

        [TestMethod]
        public void NaoDeveValidarDVComSegundoDVErrado()
        {
            // VALID CPF = 099.075.865-60
            try
            {
                cpfValidator.IsValid("09907586561");
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                Assert.IsTrue(e.GetErrors().Count == 1);
                AssertMessage(e, CPFError.InvalidCheckDigits);
            }
        }

        [TestMethod]
        public void DeveValidarCPFValidoFormatado()
        {
            CPFValidator cpfValidator = new CPFValidator(true);
            cpfValidator.IsValid("356.296.825-63");
        }

        [TestMethod]
        public void NaoDeveValidarCPFValidoNaoFormatado()
        {
            CPFValidator validator = new CPFValidator(true);
            // VALID CPF = 332.375.322-40
            try
            {
                validator.IsValid("33237532240");
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                Assert.IsTrue(e.GetErrors().Count == 1);
                AssertMessage(e, CPFError.InvalidFormat);
            }
        }

        private void AssertMessage(InvalidStateException invalidStateException
            , String expected)
        {
            Assert.IsTrue(invalidStateException
                .GetErrors().Contains(expected));
        }
    }
}
