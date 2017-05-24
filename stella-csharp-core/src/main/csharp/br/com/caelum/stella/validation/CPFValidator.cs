using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CaelumStellaCSharp
{
    public class CPFValidator
    {
        private const string FORMATED = "(\\d{3})[.](\\d{3})[.](\\d{3})-(\\d{2})";
        private const string UNFORMATED = "(\\d{3})(\\d{3})(\\d{3})(\\d{2})";

        private readonly bool _isFormatted;
        public CPFValidator()
        {
        }

        public CPFValidator(bool isFormatted)
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
                    if (!CheckCPFLength(unformattedCPF))
                        errors.Add(CPFError.InvalidDigits);

                    string trechoCPF = unformattedCPF.Substring(0, 9);

                    int digito1 = GetDigitoVerificador(trechoCPF);
                    int digito2 = GetDigitoVerificador(trechoCPF + digito1.ToString());

                    if (unformattedCPF != trechoCPF + digito1.ToString() + digito2.ToString())
                        errors.Add(CPFError.InvalidCheckDigits);
                }
            }

            return errors;
        }

        private bool CheckFormattedCPF(string formattedCPF)
        {
            Regex regex = new Regex(FORMATED);
            return regex.IsMatch(formattedCPF);
        }

        private bool CheckUnformattedCPF(string unformattedCPF)
        {
            Regex regex = new Regex(UNFORMATED);
            return regex.IsMatch(unformattedCPF);
        }

        private string UnformatCPF(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "");
        }

        private static bool CheckCPFLength(string cpf)
        {
            return cpf.Length == 11;
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

        private List<int> GetMultiplicadores(List<int> digitos)
        {
            return Enumerable
                .Range(2, digitos.Count())
                .OrderByDescending(m => m)
                .ToList();
        }

        private static List<int> GetDigitos(string trechoCPF)
        {
            return trechoCPF
                .ToCharArray()
                .Select(c => int.Parse(c.ToString()))
                .ToList();
        }
    }
}
