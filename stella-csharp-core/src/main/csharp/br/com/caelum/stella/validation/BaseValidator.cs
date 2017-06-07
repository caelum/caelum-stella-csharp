using Caelum.Stella.CSharp.Validation.Error;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Caelum.Stella.CSharp.Error;

namespace Caelum.Stella.CSharp.Validation
{
    public abstract class BaseValidator
    {
        public abstract string RegexFormatted { get; }
        public abstract string RegexUnformatted { get; }
        protected abstract int DocumentLength { get; }
        protected abstract int GetDigitoVerificador(string documentSubstring);
        protected readonly bool isFormatted;

        public BaseValidator(bool isFormatted)
        {
            this.isFormatted = isFormatted;
        }

        public void AssertValid(string document)
        {
            List<string> errors = GetInvalidValues(document);
            if (errors.Count > 0)
                throw new InvalidStateException(errors);
        }

        public bool IsValid(string document)
        {
            try
            {
                AssertValid(document);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private List<string> GetInvalidValues(string document)
        {
            List<string> errors = new List<string>();
            if (!string.IsNullOrEmpty(document))
            {
                string unformattedDocument = document;
                if (isFormatted)
                {
                    if (!CheckFormattedDocument(document))
                        errors.Add(DocumentError.InvalidFormat);

                    return errors;
                }
                unformattedDocument = UnformatDocument(document);

                if (!CheckUnformattedDocument(unformattedDocument))
                    errors.Add(DocumentError.InvalidDigits);
                else if (!CheckMoreThan1DistinctDigit(unformattedDocument))
                    errors.Add(DocumentError.RepeatedDigits);
                else
                {
                    if (!CheckDocumentLength(unformattedDocument))
                        errors.Add(DocumentError.InvalidDigits);

                    string documentSubstring = unformattedDocument.Substring(0, DocumentLength - 2);

                    int digito1 = GetDigitoVerificador(documentSubstring);
                    int digito2 = GetDigitoVerificador(documentSubstring + digito1.ToString());

                    if (unformattedDocument != documentSubstring + digito1.ToString() + digito2.ToString())
                        errors.Add(DocumentError.InvalidCheckDigits);
                }

                if (!CheckCountryState(unformattedDocument))
                {
                    errors.Add(DocumentError.InvalidCountryState);
                }
            }

            return errors;
        }

        private bool CheckMoreThan1DistinctDigit(string unformattedDocument)
        {
            return unformattedDocument.ToCharArray().Distinct().Count() > 1;
        }

        private bool CheckDocumentLength(string document)
        {
            return document.Length == DocumentLength;
        }

        private bool CheckFormattedDocument(string formattedDocument)
        {
            Regex regex = new Regex(RegexFormatted);
            return regex.IsMatch(formattedDocument);
        }

        private bool CheckUnformattedDocument(string unformattedDocument)
        {
            Regex regex = new Regex(RegexUnformatted);
            return regex.IsMatch(unformattedDocument);
        }

        protected virtual bool CheckCountryState(string document)
        {
            return true;
        }

        private string UnformatDocument(string document)
        {
            return document.Replace(".", "").Replace("-", "").Replace("/", ""); ;
        }

        protected int GetComplementoDoModuloDe11(int soma)
        {
            return 11 - (soma % 11);
        }

        protected int GetSomaDosProdutos(string documentSubstring, int[] digitos, int[] multiplicadores)
        {
            int soma = 0;
            for (int i = 0; i < documentSubstring.Count(); i++)
                soma += digitos[i] * multiplicadores[i];
            return soma;
        }

        protected abstract int[] GetMultiplicadores(int[] digitos);

        protected static int[] GetDigitos(string documentSubstring)
        {
            return documentSubstring
                .ToCharArray()
                .Select(c => int.Parse(c.ToString()))
                .ToArray();
        }
    }
}