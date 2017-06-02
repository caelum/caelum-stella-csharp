using Caelum.Stella.CSharp.Validation;
using Caelum.Stella.CSharp.Validation.Error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Validation.Test
{
    [TestClass]
    public class TituloEleitoralValidatorTest
    {
        private readonly String[] validStrings = { "106644440302", "543275360116","142501480248", "557833330370", "013785610434",
        "253346440540", "033734180663", "585353130710", "884328631058", "553505611201", "028565701333",
        "245770031481", "713782341503", "403374181694", "452083221724" };
        private readonly String[] validStringsFormatted = { "5432753601/16","1425014802/48", "5578333303/70", "0137856104/34",
        "2533464405/40", "0337341806/63", "5853531307/10", "8843286310/58", "5535056112/01", "0285657013/33",
        "2457700314/81", "7137823415/03", "4033741816/94", "4520832217/24"};
        private readonly String[] invalidFirstDigitStrings = { "543275360106", "452083221714", "253346440520", "553505611231",
        "884328631048" };
        private readonly String[] invalidSecondDigitStrings = { "543275360119", "452083221728", "253346440547",
        "553505611206", "884328631055" };

        private TituloEleitoralValidator validator;
        private TituloEleitoralValidator validatorFormatted;

        [TestInitialize()]
        public void Initialize()
        {
            validator = new TituloEleitoralValidator();
            validatorFormatted = new TituloEleitoralValidator(true);
        }


        [TestMethod]
        public void ShouldValidateCorrectString()
        {
            foreach (String validString in validStrings)
            {
                validator.AssertValid(validString);
            }
        }

        [TestMethod]
        public void ShouldValidateCorrectFormattedString()
        {
            foreach (String validString in validStringsFormatted)
            {
                validator.AssertValid(validString);
            }
        }

        [TestMethod]
        public void ShouldNotValidateStringWithFirstCheckDigitWrong()
        {
            foreach (String invalidString in invalidFirstDigitStrings)
            {
                try
                {
                    validator.AssertValid(invalidString);
                    Assert.Fail("O titulo eleitoral " + invalidString + " deve ser considerado inválido!");
                }
                catch (InvalidStateException)
                {
                }
            }
        }

        [TestMethod]
        public void ShouldNotValidateStringWithSecondCheckDigitWrong()
        {
            foreach (String invalidString in invalidSecondDigitStrings)
            {
                try
                {
                    validator.AssertValid(invalidString);
                    Assert.Fail("O titulo eleitoral " + invalidString + " deve ser considerado inválido!");
                }
                catch (InvalidStateException)
                {
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateException))]
        public void ShouldNotValidateStringMoreDigits()
        {
            validator.AssertValid(validStrings[0] + "0");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateException))]
        public void ShouldNotValidateStringWithCodigoDeEstadoInvalidoMenorDoQueUm()
        {
            validator.AssertValid("471235380051");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidStateException))]
        public void ShouldNotValidateStringWithCodigoDeEstadoInvalidoMaiorDoQue28()
        {
            validator.AssertValid("815155812960");
        }
    }
}
