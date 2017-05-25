using CaelumStellaCSharp;
using CaelumStellaCSharp.validation.error;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CaelumStellaCSharp.Test
{
    [TestClass]
    public class CNPJValidatorTest : BaseDocumentValidatorTest
    {
        private CNPJValidator cnpjValidator;
        private static String INVALID_FORMAT = "INVALID FORMAT";
        private static String INVALID_CHECK_DIGITS = "INVALID CHECK DIGITS";
        private static String INVALID_DIGITS = "INVALID DIGITS";
        private String validString = "26.637.142/0001-58";
        private String validStringNotFormatted = "26637142000158";

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

        [TestMethod]
        public void shoulValidateNullCNPJ()
        {
            cnpjValidator.IsValid(null);
        }

        [TestMethod]
        public void shouldNotValidateCNPJCheckDigitsWithFirstCheckDigitWrong()
        {
            CNPJValidator validator = new CNPJValidator();
            // VALID CNPJ = 742213250001-30
            try
            {
                String value = "74221325000160";
                cnpjValidator.IsValid(value);
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                Assert.IsTrue(e.GetErrors().Count == 1);
                AssertMessage(e, DocumentError.InvalidCheckDigits);
            }
        }

        [TestMethod]
        public void shouldNotValidateCNPJCheckDigitsWithSecondCheckDigitWrong()
        {
            CNPJValidator validator = new CNPJValidator();

            // VALID CNPJ = 266371420001-58
            try
            {
                String value = "26637142000154";
                cnpjValidator.IsValid(value);
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                Assert.IsTrue(e.GetErrors().Count == 1);
                AssertMessage(e, DocumentError.InvalidCheckDigits);
            }
        }

        [TestMethod]
        public void shouldValidateValidFormattedCNPJ()
        {
            CNPJValidator validator = new CNPJValidator(true);
            String value = validString;
            validator.IsValid(value);
        }

        [TestMethod]
        public void shouldNotValidateValidUnformattedCNPJWhenExplicity()
        {
            CNPJValidator validator = new CNPJValidator(true);

            // VALID CNPJ = 26.637.142/0001-58
            try
            {
                String value = "26637142000158";
                validator.IsValid(value);
                Assert.Fail();
            }
            catch (InvalidStateException e)
            {
                Assert.IsTrue(e.GetErrors().Count == 1);
                AssertMessage(e, DocumentError.InvalidFormat);
            }
        }
    }
}
