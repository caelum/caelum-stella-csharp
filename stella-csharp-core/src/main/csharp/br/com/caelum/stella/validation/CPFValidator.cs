using System.Collections.Generic;

namespace CaelumStellaCSharp
{
    public class CPFValidator : BaseCadastroPessoaValidator
    {
        protected override string RegexFormatted => @"(\d{3})[.](\d{3})[.](\d{3})-(\d{2})";
        protected override string RegexUnformatted => @"(\d{3})(\d{3})(\d{3})(\d{2})";
        protected override int DocumentLength => 11;

        public CPFValidator() : base(false) { }

        public CPFValidator(bool isFormatted) : base(isFormatted) { }

        protected override List<int> GetMultiplicadores(List<int> digitos)
        {
            if (digitos.Count == DocumentLength - 2)
                return new List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            else
                return new List<int> { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        }
    }
}
