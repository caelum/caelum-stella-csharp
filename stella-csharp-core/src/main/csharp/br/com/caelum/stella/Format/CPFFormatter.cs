using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Format
{
    public class CPFFormatter : BaseFormatter
    {
        public CPFFormatter()
            : base(DocumentFormats.CPF, "$1.$2.$3-$4"
                  , DocumentFormats.CPFUnformatted, "$1$2$3$4")
        {
        }
    }
}
