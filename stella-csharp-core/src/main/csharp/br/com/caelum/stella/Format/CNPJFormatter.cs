using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Format
{
    public class CNPJFormatter : BaseFormatter
    {
        public CNPJFormatter() 
            : base(DocumentFormats.CNPJ, "$1.$2.$3/$4-$5", DocumentFormats.CNPJUnformatted, "$1$2$3$4$5")
        {
        }
    }
}
