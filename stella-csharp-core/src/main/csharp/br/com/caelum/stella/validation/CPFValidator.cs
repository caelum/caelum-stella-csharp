using System.Collections.Generic;

namespace CaelumStellaCSharp
{
    public class CPFValidator : BaseDocumentValidator
    {
        protected override string GetRegexFormatted => @"(\d{3})[.](\d{3})[.](\d{3})-(\d{2})";
        protected override string GetRegexUnformatted => @"(\d{3})(\d{3})(\d{3})(\d{2})";
        protected override int GetDocumentLength => 11;

        public CPFValidator() : base(false) { }

        public CPFValidator(bool isFormatted) : base(isFormatted) { }

        protected override List<int> GetMultiplicadores(List<int> digitos)
        {
            if (digitos.Count == GetDocumentLength - 2)
                return new List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            else
                return new List<int> { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        }
    }
}
