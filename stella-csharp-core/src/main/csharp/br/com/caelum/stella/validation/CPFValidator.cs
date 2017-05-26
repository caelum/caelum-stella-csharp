using System.Collections.Generic;

namespace CaelumStellaCSharp
{
    /// <summary>
    /// Verifica se uma cadeia (String) é válida para o documento de CPF (Cadastro de Pessoa Física).
    /// </summary>
    public class CPFValidator : BaseCadastroPessoaValidator 
    {
        protected override string RegexFormatted => @"(\d{3})[.](\d{3})[.](\d{3})-(\d{2})";
        protected override string RegexUnformatted => @"(\d{3})(\d{3})(\d{3})(\d{2})";
        protected override int DocumentLength => 11;

        /// <summary>
        /// Construtor padrão de validador de CPF. Este considera, por padrão, que as cadeias não estão formatadas.
        /// </summary>
        public CPFValidator() : base(false) { }

        /// <summary>
        /// Construtor de validador de CPF. Leva em conta se o valor está ou não formatado.
        /// </summary>
        /// <param name="isFormatted">considera cadeia no formato de CPF:"ddd.ddd.ddd-dd" onde "d" é um dígito decimal.</param>
        public CPFValidator(bool isFormatted) : base(isFormatted) { }

        protected override int[] GetMultiplicadores(int[] digitos)
        {
            if (digitos.Length == DocumentLength - 2)
                return new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            else
                return new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        }
    }
}
