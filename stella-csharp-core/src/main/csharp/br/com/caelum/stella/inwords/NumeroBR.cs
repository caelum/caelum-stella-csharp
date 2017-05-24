using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Globalization;
using System.Threading;

namespace CaelumStellaCSharp
{
    public class NumeroBR
    {
        private readonly ResourceManager resourceManager;
        public NumeroBR()
        {
            resourceManager = new ResourceManager(@"CaelumStellaCSharp.Properties.Resources",
                         System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("CaelumStellaCSharp")));
        }

        public string Extenso(double numeroOrigem)
        {
            numeroOrigem = Math.Round(numeroOrigem);
            double numero = numeroOrigem;

            double posicao = 1;
            Grupo grupo = null;
            do
            {
                grupo = new Grupo((long)(numero % (double)1000), posicao, grupo);
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
        }

        private string Extenso0_20(double numero)
        {
            return resourceManager.GetString(string.Format("Extenso{0:000}", numero));
        }
    }

    class Grupo
    {
        private const string NUMERO_NEGATIVO = "Número não pode ser negativo";
        private readonly long numero;
        private readonly double posicao;
        private readonly Digito digito;
        private readonly Grupo grupoFilho;

        public double Posicao => posicao;

        public Grupo(long numero, double posicao, Grupo grupoFilho)
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

        public Grupo PrimeiroGrupoComValor()
        {
            Grupo result = null;

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
                    Grupo proximoGrupoComValor = grupoFilho.PrimeiroGrupoComValor();
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
        public DigitoDezena(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }

        public override string Extenso()
        {
            if (numero == 0)
            {
                return digitoFilho.Extenso();
            }
            else if (numero == 1)
            {
                return base.Extenso(ValorSomenteDoDigito() + digitoFilho.Numero);
            }
            else
            {
                if (digitoFilho.Numero == 0)
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
        public DigitoCentena(long numero, double posicao, Digito digitoFilho) : base(numero, posicao, digitoFilho) { }

        public override string Extenso()
        {
            if (ValorDosFilhos() == 0)
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
