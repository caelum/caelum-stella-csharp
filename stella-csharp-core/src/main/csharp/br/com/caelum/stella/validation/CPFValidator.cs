namespace Caelum.Stella.CSharp.Validation
{
    /// <summary>
    /// Verifica se uma cadeia (String) é válida para o documento de CPF (Cadastro de Pessoa Física).
    /// </summary>
    public class CPFValidator : BaseCadastroPessoaValidator 
    {
        public override string RegexFormatted => DocumentFormats.CPF;
        public override string RegexUnformatted => DocumentFormats.CPFUnformatted;
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
