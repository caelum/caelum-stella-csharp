using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Format
{
    public class TituloEleitoralFormatter : BaseFormatter
    {
        public TituloEleitoralFormatter()
            : base(DocumentFormats.TituloEleitoralRegexFormatted, "$1/$2", DocumentFormats.TituloEleitoralRegexUnformatted, "$1$2")
        {
        }
    }
}
