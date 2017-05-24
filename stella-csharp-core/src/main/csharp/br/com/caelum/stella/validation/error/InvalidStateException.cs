using System;
using System.Collections.Generic;
using System.Text;

namespace CaelumStellaCSharp.validation.error
{
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
