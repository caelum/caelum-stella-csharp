using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Validation
{
    public class DocumentFormats
    {
        public static string CPF => @"(\d{3})[.](\d{3})[.](\d{3})-(\d{2})";
        public static string CPFUnformatted => @"(\d{3})(\d{3})(\d{3})(\d{2})";
        public static string CPFDigitsOnly => @"^\d{11}$";

        public static string CNPJ => @"(\d{2})[.](\d{3})[.](\d{3})\/(\d{4})-(\d{2})";
        public static string CNPJUnformatted => @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})";
        public static string CNPJDigitsOnly => @"^\d{14}$";

        public static string TituloEleitoral => @"(\d{10})/(\d{2})";
        public static string TituloEleitoralUnformatted => @"(\d{10})(\d{2})";
        public static string TituloEleitoralDigitsOnly => @"^\d{12}$";

        public static string CEP => @"(\d{5})-(\d{3})";
        public static string CEPUnformatted => @"(\d{5})(\d{3})";
        public static string CEPDigitsOnly => @"^\d{8}$";
    }
}
