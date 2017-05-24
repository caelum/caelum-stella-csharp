using System;
using System.Collections.Generic;
using System.Text;

namespace CaelumStellaCSharp
{
    public class CPFError
    {
        public static string InvalidFormat = "Formato inválido";
        public static string RepeatedDigits = "Dígito repetido";
        public static string InvalidCheckDigits = "Dígito de verificação inválido";
        public static string InvalidDigits = "Dígito inválido";
    }

    public class InvalidStateException : Exception
    {
        private readonly List<string> _errors;
        public InvalidStateException(List<string> errors)
        {
            _errors = errors;
        }

        public List<string> GetErrors()
        {
            return _errors;
        }
    }
}
