using CaelumStellaCSharp.validation.error;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CaelumStellaCSharp
{
    public abstract class BaseDocumentValidator
    {
        protected readonly bool _isFormatted;
        protected abstract string GetRegexFormatted { get; }
        protected abstract string GetRegexUnformatted { get; }
        protected abstract int GetDocumentLength { get; }

        public BaseDocumentValidator(bool isFormatted)
        {
            _isFormatted = isFormatted;
        }

        public bool IsValid(string cpf)
        {
            bool result = true;
            List<string> errors = GetInvalidValues(cpf);
            if (errors.Count() > 0)
            {
                throw new InvalidStateException(errors);
            }
            return result;
        }
        
        private List<string> GetInvalidValues(string cpf)
        {
            List<string> errors = new List<string>();
            if (!string.IsNullOrEmpty(cpf))
            {
                string unformattedCPF = cpf;
                if (_isFormatted)
                {
                    if (!CheckFormattedCPF(cpf))
                        errors.Add(CPFError.InvalidFormat);

                    return errors;
                }
                unformattedCPF = UnformatCPF(cpf);

                if (!CheckUnformattedCPF(unformattedCPF))
                    errors.Add(CPFError.InvalidDigits);
                else
                {
                    if (!CheckDocumentLength(unformattedCPF))
                        errors.Add(CPFError.InvalidDigits);

                    string trechoCPF = unformattedCPF.Substring(0, GetDocumentLength - 2);

                    int digito1 = GetDigitoVerificador(trechoCPF);
                    int digito2 = GetDigitoVerificador(trechoCPF + digito1.ToString());

                    if (unformattedCPF != trechoCPF + digito1.ToString() + digito2.ToString())
                        errors.Add(CPFError.InvalidCheckDigits);
                }
            }

            return errors;
        }

        private bool CheckDocumentLength(string cpf)
        {
            return cpf.Length == GetDocumentLength;
        }

        private bool CheckFormattedCPF(string formattedCPF)
        {
            Regex regex = new Regex(GetRegexFormatted);
            return regex.IsMatch(formattedCPF);
        }

        private bool CheckUnformattedCPF(string unformattedCPF)
        {
            Regex regex = new Regex(GetRegexUnformatted);
            return regex.IsMatch(unformattedCPF);
        }

        private string UnformatCPF(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }

        private int GetDigitoVerificador(string trechoCPF)
        {
            int result = 0;
            List<int> digitos = GetDigitos(trechoCPF);
            int soma = GetSoma(trechoCPF, digitos, GetMultiplicadores(digitos));
            int subtracao = GetSubtracao(soma);

            if (subtracao > 9)
                result = 0;
            else
                result = subtracao;
            return result;
        }

        private int GetSubtracao(int soma)
        {
            return 11 - (soma % 11);
        }

        private int GetSoma(string trechoCPF, List<int> digitos, List<int> multiplicadores)
        {
            int soma = 0;
            for (int i = 0; i < trechoCPF.Count(); i++)
                soma += digitos[i] * multiplicadores[i];
            return soma;
        }

        protected abstract List<int> GetMultiplicadores(List<int> digitos);

        private static List<int> GetDigitos(string trechoCPF)
        {
            return trechoCPF
                .ToCharArray()
                .Select(c => int.Parse(c.ToString()))
                .ToList();
        }
    }
}