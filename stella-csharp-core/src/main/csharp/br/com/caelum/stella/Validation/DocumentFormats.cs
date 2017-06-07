using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Validation
{
    public class DocumentFormats
    {
        public static string CPFRegexFormatted => @"(\d{3})[.](\d{3})[.](\d{3})-(\d{2})";
        public static string CPFRegexUnformatted => @"(\d{3})(\d{3})(\d{3})(\d{2})";

        public static string CNPJRegexFormatted => @"(\d{2})[.](\d{3})[.](\d{3})\/(\d{4})-(\d{2})";
        public static string CNPJRegexUnformatted => @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})";

        public static string TituloEleitoralRegexFormatted => @"(\d{10})/(\d{2})";
        public static string TituloEleitoralRegexUnformatted => @"(\d{10})(\d{2})";

        public static string CEPRegexFormatted => @"(\d{5})-(\d{3})";
        public static string CEPRegexUnformatted => @"^(\d{5})(\d{3})$";
    }
}
