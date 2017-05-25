using CaelumStellaCSharp.validation.error;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CaelumStellaCSharp
{
    public abstract class BaseCadastroPessoaValidator : BaseValidator
    {
        public BaseCadastroPessoaValidator(bool isFormatted) : base(isFormatted) { }

        protected override int GetDigitoVerificador(string documentSubstring)
        {
            int result = 0;
            List<int> digitos = GetDigitos(documentSubstring);
            int soma = GetSomaDosProdutos(documentSubstring, digitos, GetMultiplicadores(digitos));
            int subtracao = GetComplementoDoModuloDe11(soma);

            if (subtracao > 9)
                result = 0;
            else
                result = subtracao;
            return result;
        }
    }
}