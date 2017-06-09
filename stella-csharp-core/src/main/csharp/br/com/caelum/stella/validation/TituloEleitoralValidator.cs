namespace Caelum.Stella.CSharp.Validation
{
    /// <summary>
    /// Representa um validador de Título de Eleitor. O algoritmo utilzado foi
    /// basaedo na seguinte referência.
    /// 
    /// http://www.tre-al.gov.br/unidades/corregedoria/resolucoes/res21538.pdf
    /// <p>
    /// Art. 12. Os tribunais regionais eleitorais farão distribuir, observada a
    /// seqüência numérica fornecida pela secretaria de informática, às zonas
    /// eleitorais da respectiva circunscrição, séries de números de inscrição
    /// eleitoral, a serem utilizados na forma deste artigo.
    /// </p>
    /// <p>
    /// Parágrafo único. O número de inscrição compor-se-á de até 12 algarismos, por
    /// unidade da Federação, assim discriminados:
    /// </p>
    /// 
    /// a) os oito primeiros algarismos serão seqüenciados,desprezando-se, na
    /// emissão, os zeros à esquerda;
    /// 
    /// b) os dois algarismos seguintes serão representativos da unidade da Federação
    /// de origem da inscrição, conforme códigos constantes da seguinte tabela:
    /// 
    /// <ul>
    /// <li>01 - São Paulo</li>
    /// <li>02 - Minas Gerais</li>
    /// <li>03 - Rio de Janeiro</li>
    /// <li>04 - Rio Grande do Sul</li>
    /// <li>05 - Bahia</li>
    /// <li>06 - Paraná</li>
    /// <li>07 - Ceará</li>
    /// <li>08 - Pernambuco</li>
    /// <li>09 - Santa Catarina</li>
    /// <li>10 - Goiás</li>
    /// <li>11 - Maranhão</li>
    /// <li>12 - Paraíba</li>
    /// <li>13 - Pará</li>
    /// <li>14 - Espírito Santo</li>
    /// <li>15 - Piauí</li>
    /// <li>16 - Rio Grande do Norte</li>
    /// <li>17 - Alagoas</li>
    /// <li>18 - Mato Grosso</li>
    /// <li>19 - Mato Grosso do Sul</li>
    /// <li>20 - Distrito Federal</li>
    /// <li>21 - Sergipe</li>
    /// <li>22 - Amazonas</li>
    /// <li>23 - Rondônia</li>
    /// <li>24 - Acre</li>
    /// <li>25 - Amapá</li>
    /// <li>26 - Roraima</li>
    /// <li>27 - Tocantins</li>
    /// <li>28 - Exterior (ZZ)</li>
    /// </ul>
    /// 
    /// <p>
    /// c) os dois últimos algarismos constituirão dígitos verificadores,
    /// determinados com base no módulo 11, sendo o primeiro calculado sobre o número
    /// seqüencial e o último sobre o código da unidade da Federação seguido do
    /// primeiro dígito verificador.
    /// </p>
    /// </summary>
    public class TituloEleitoralValidator : BaseValidator
    {
        public override string RegexFormatted => DocumentFormats.TituloEleitoral;
        public override string RegexUnformatted => DocumentFormats.TituloEleitoralUnformatted;
        protected override int DocumentLength => 12;

        /// <summary>
        /// Este construtor considera, por padrão, que as cadeias não estão formatadas para geração de mensagens.
        /// </summary>
        public TituloEleitoralValidator() : base(false) { }

        /// <summary>
        /// Este construtor leva em conta se o valor está ou não formatado.
        /// </summary>
        /// <param name="isFormatted">considera cadeia no formato de CNPJ: "dd.ddd.ddd/dddd-dd" onde "d" é um dígito decimal.</param>
        public TituloEleitoralValidator(bool isFormatted) : base(isFormatted) { }

        protected override int GetDigitoVerificador(string documentSubstring)
        {
            int[] digitos = GetDigitos(documentSubstring);
            int modulo = (GetSomaDosProdutos(documentSubstring, digitos, GetMultiplicadores(digitos)) % 11) % 10;

            if (modulo > 9)
                return 0;
            else
                return modulo;
        }

        protected override int[] GetMultiplicadores(int[] digitos)
        {
            if (digitos.Length == DocumentLength - 2)
                return new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 0, 0 };
            else
                return new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 7, 8, 9 };
        }

        protected override bool CheckCountryState(string document)
        {
            int codigoUF = int.Parse(document.Substring(8, 2));
            return codigoUF >= 1 && codigoUF <= 28;
        }
    }
}
