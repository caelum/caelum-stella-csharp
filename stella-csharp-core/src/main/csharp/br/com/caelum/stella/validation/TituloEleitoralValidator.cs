using System;
using System.Collections.Generic;
using System.Text;

namespace CaelumStellaCSharp.validation
{
    public class TituloEleitoralValidator : BaseValidator
    {
        protected override string RegexFormatted => @"([\d]{10}[\.][\d]{2})";
        protected override string RegexUnformatted => @"([\d]{12})";
        protected override int DocumentLength => 12;

        public TituloEleitoralValidator() : base(false) { }
        public TituloEleitoralValidator(bool isFormatted) : base(isFormatted) { }

        protected override int GetDigitoVerificador(string documentSubstring)
        {
            List<int> digitos = GetDigitos(documentSubstring);
            int modulo = (GetSomaDosProdutos(documentSubstring, digitos, GetMultiplicadores(digitos)) % 11) % 10;

            if (modulo > 9)
                return 0;
            else
                return modulo;
        }

        protected override List<int> GetMultiplicadores(List<int> digitos)
        {
            if (digitos.Count == DocumentLength - 2)
                return new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 0, 0 };
            else
                return new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 7, 8, 9 };
        }

        protected override bool CheckCountryState(string document)
        {
            int codigoUF = int.Parse(document.Substring(8, 2));
            return codigoUF >= 1 && codigoUF <= 28;
        }
    }
}
