using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Format
{
    public class CEPFormatter : BaseFormatter
    {
        public CEPFormatter() 
            : base(DocumentFormats.CEPRegexFormatted, "$1-$2", DocumentFormats.CEPRegexUnformatted, "$1$2")
        {
        }
    }
}
