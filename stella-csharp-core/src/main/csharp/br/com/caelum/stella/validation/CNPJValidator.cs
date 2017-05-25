using System.Collections.Generic;

namespace CaelumStellaCSharp
{
    public class CNPJValidator : BaseDocumentValidator
    {
        protected override string RegexFormatted => @"([\d]{2}[\.][\d]{3}[\.][\d]{3}[\/][\d]{4}[-][\d]{2})|([\d]{3}[\.][\d]{3}[\.][\d]{3}[-][\d]{2})";
        protected override string RegexUnformatted => @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})";
        protected override int DocumentLength => 14;

        public CNPJValidator() : base(false) { }

        public CNPJValidator(bool isFormatted) : base(isFormatted) { }

        protected override List<int> GetMultiplicadores(List<int> digitos)
        {
            if (digitos.Count == DocumentLength - 2)
                return new List<int> { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            else
                return new List<int> { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        }
    }
}
