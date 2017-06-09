namespace Caelum.Stella.CSharp.Validation
{
    /// <summary>
    /// Verifica se uma cadeia (String) é válida para o documento de CNPJ (Cadastro Nacional de Pessoa Jurídica).
    /// </summary>
    public class CNPJValidator : BaseCadastroPessoaValidator
    {
        public override string RegexFormatted => DocumentFormats.CNPJ;
        public override string RegexUnformatted => DocumentFormats.CPFUnformatted;
        protected override int DocumentLength => 14;

        /// <summary>
        /// Este construtor considera, por padrão, que as cadeias não estão formatadas para geração de mensagens.
        /// </summary>
        public CNPJValidator() : base(false) { }

        /// <summary>
        /// Este construtor leva em conta se o valor está ou não formatado.
        /// </summary>
        /// <param name="isFormatted">considera cadeia no formato de CNPJ: "dd.ddd.ddd/dddd-dd" onde "d" é um dígito decimal.</param>
        public CNPJValidator(bool isFormatted) : base(isFormatted) { }

        protected override int[] GetMultiplicadores(int[] digitos)
        {
            if (digitos.Length == DocumentLength - 2)
                return new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            else
                return new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        }
    }
}
