using System;
using System.Resources;

namespace CaelumStellaCSharp
{
    /// <summary>
    /// Responsável por transformar um número em sua representação por extenso, em português.
    /// </summary>
    public class NumeroPT
    {
        private readonly ResourceManager resourceManager;
        public NumeroPT()
        {
            resourceManager = new ResourceManager(@"CaelumStellaCSharp.Properties.Resources",
                         System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("CaelumStellaCSharp")));
        }

        /// <summary>
        /// Transforma um número em sua representação por extenso, em português.
        /// </summary>
        /// <param name="numeroOrigem">número a ser transformado</param>
        /// <returns></returns>
        public string Extenso(double numeroOrigem)
        {
            numeroOrigem = Math.Round(numeroOrigem);
            double numero = numeroOrigem;

            double posicao = 1;
            GrupoDe3Digitos grupo = null;
            do
            {
                grupo = new GrupoDe3Digitos((long)(numero % (double)1000), posicao, grupo);
                posicao++;
                numero /= 1000;

            } while (numero > 0);

            return grupo.Extenso();
        }

        private string Extenso21_999(double numero)
        {
            double numeroDigitos = Math.Floor(Math.Log10(numero));
            double potenciaDe10 = (int)Math.Pow(10, (int)numeroDigitos);
            if (numero % potenciaDe10 == 0)
            {
                return resourceManager.GetString(string.Format("Extenso{0:000}", numero));
            }
            else
            {
                return ExtensoDestaEDasProximasCasas(numero, potenciaDe10);
            }
        }

        private string ExtensoDestaEDasProximasCasas(double numero, double potenciaDe10)
        {
            string estaCasaPorExtenso = string.Empty;
            double estaCasa = (int)((numero / potenciaDe10) * potenciaDe10);
            if (estaCasa == 100)
                estaCasaPorExtenso = resourceManager.GetString("Extenso100mais");
            else
                estaCasaPorExtenso = resourceManager.GetString(string.Format("Extenso{0:000}", estaCasa));

            var proximasCasas = numero % potenciaDe10;
            return string.Format("{0:000} e {1:000}"
                , estaCasaPorExtenso
                , Extenso(proximasCasas));
        }

        private string Extenso0_20(double numero)
        {
            return resourceManager.GetString(string.Format("Extenso{0:000}", numero));
        }
    }

    class GrupoDe3Digitos
    {
        private const string NUMERO_NEGATIVO = "Número não pode ser negativo";
        private readonly long numero;
        private readonly double posicao;
        private readonly Digito digito;
        private readonly GrupoDe3Digitos grupoFilho;

        public double Posicao => posicao;

        public GrupoDe3Digitos(long numero, double posicao, GrupoDe3Digitos grupoFilho)
        {
            if (numero < 0)
            {
                throw new ArgumentOutOfRangeException(NUMERO_NEGATIVO);
            }
            else
            {
                this.numero = numero;
                this.posicao = posicao;
                this.grupoFilho = grupoFilho;
                double posicaoDigito = 1;
                Digito digito = null;
                do
                {
                    switch ((posicaoDigito - 1) % 3)
                    {
                        case 0:
                            digito = new DigitoUnidade(numero % 10, posicaoDigito, digito);
                            break;
                        case 1:
                            digito = new DigitoDezena(numero % 10, posicaoDigito, digito);
                            break;
                        case 2:
                            digito = new DigitoCentena(numero % 10, posicaoDigito, digito);
                            break;
                    }
                    posicaoDigito++;
                    numero /= 10;
                } while (numero > 0);

                this.digito = digito;
            }
        }

        protected double ValorSomenteDoGrupo()
        {
            return digito.ValorTotal();
        }

        protected double ValorDosFilhos()
        {
            if (grupoFilho == null)
            {
                return 0;
            }
            else
            {
                return grupoFilho.ValorTotal();
            }
        }

        public double ValorTotal()
        {
            double result = ValorSomenteDoGrupo();
            if (grupoFilho != null)
                result += grupoFilho.ValorTotal();
            return result;
        }

        public GrupoDe3Digitos PrimeiroGrupoComValor()
        {
            GrupoDe3Digitos result = null;

            if (ValorSomenteDoGrupo() > 0)
                result = this;
            else if (grupoFilho != null)
                result = grupoFilho.PrimeiroGrupoComValor();
            return result;
        }

        public string Extenso()
        {
            if (grupoFilho == null)
                return digito.Extenso();
            else if (ValorSomenteDoGrupo() == 0)
            {
                return grupoFilho.Extenso();
            }
            else
            {
                double valorGrupo = digito.ValorTotal();
                string singularPlural = valorGrupo < 2 ? "singular" : "plural";
                string nomeGrupo =
                    ResourceManagerHelper
                        .Instance
                        .ResourceManager
                        .GetString(string.Format("Extenso1e{0}{1}", (posicao - 1) * 3, singularPlural));

                double valorGrupoFilho = grupoFilho.ValorTotal();

                if (valorGrupoFilho == 0)
                {
                    return string.Format("{0} {1}",
                    digito.Extenso(),
                    nomeGrupo);
                }
                else
                {
                    GrupoDe3Digitos proximoGrupoComValor = grupoFilho.PrimeiroGrupoComValor();
                    string separador = proximoGrupoComValor.Posicao == 1 ? " e" : ",";
                    return string.Format("{0} {1}{2} {3}",
                    digito.Extenso(),
                    nomeGrupo,
                    separador,
                    grupoFilho.Extenso());
                }
            }
        }
    }

    abstract class Digito
    {
        protected readonly long numero;
        protected readonly double posicao;
        protected readonly Digito digitoFilho;

        public long Numero { get { return numero; } }

        public Digito(long numero, double posicao, Digito digitoFilho)
        {
            this.numero = numero;
            this.posicao = posicao;
            this.digitoFilho = digitoFilho;
        }

        public virtual string Extenso()
        {
            return ResourceManagerHelper
                .Instance
                .ResourceManager
                .GetString(string.Format("Extenso{0:000}", ValorSomenteDoDigito()));
        }

        protected double ValorSomenteDoDigito()
        {
            return numero * (int)Math.Pow(10, posicao - 1);
        }

        protected double ValorDosFilhos()
        {
            if (digitoFilho == null)
            {
                return 0;
            }
            else
            {
                return digitoFilho.ValorTotal();
            }
        }

        public double ValorTotal()
        {
            double result = ValorSomenteDoDigito();
            if (digitoFilho != null)
                result += digitoFilho.ValorTotal();
            return result;
        }

        protected string Extenso(double numero)
        {
            return ResourceManagerHelper
                .Instance
                .ResourceManager
                .GetString(string.Format("Extenso{0:000}", numero));
        }

        protected bool Plural
        {
            get { return numero > 1; }
        }
    }

    class DigitoUnidade : Digito
    {
        public DigitoUnidade(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }
    }

    class DigitoDezena : Digito
    {
        private bool MultiploDe10 => digitoFilho.Numero == 0;
        private bool Entre10e19 => numero == 1;
        private bool Entre0e9 => numero == 0;

        public DigitoDezena(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }

        public override string Extenso()
        {
            if (Entre0e9)
            {
                return digitoFilho.Extenso();
            }
            else if (Entre10e19)
            {
                return base.Extenso(ValorSomenteDoDigito() + digitoFilho.Numero);
            }
            else
            {
                if (MultiploDe10)
                    return base.Extenso(ValorSomenteDoDigito());
                else
                    return
                        string.Format("{0} e {1}"
                        , base.Extenso()
                        , digitoFilho.Extenso());
            }
        }
    }

    class DigitoCentena : Digito
    {
        private bool MultiploDe100 => ValorDosFilhos() == 0;

        public DigitoCentena(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }

        public override string Extenso()
        {
            if (MultiploDe100)
                return base.Extenso(ValorSomenteDoDigito());
            else
            {
                string esteDigitoExtenso = string.Empty;
                if (numero == 1)
                    esteDigitoExtenso = ResourceManagerHelper.Instance.ResourceManager.GetString("Extenso100mais");
                else
                    esteDigitoExtenso = base.Extenso();

                return
                    string.Format("{0} e {1}"
                    , esteDigitoExtenso
                    , digitoFilho.Extenso());
            }
        }
    }

    class ResourceManagerHelper
    {
        private readonly ResourceManager resourceManager;
        private static ResourceManagerHelper instance;
        private ResourceManagerHelper()
        {
            resourceManager = new ResourceManager(@"CaelumStellaCSharp.Properties.messages_pt_BR",
             System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("CaelumStellaCSharp")));
        }

        public static ResourceManagerHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new ResourceManagerHelper();
                return instance;
            }
        }

        public ResourceManager ResourceManager
        {
            get
            {
                return resourceManager;
            }
        }
    }
}
