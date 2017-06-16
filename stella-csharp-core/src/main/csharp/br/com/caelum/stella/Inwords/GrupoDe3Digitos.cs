using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Inwords
{
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
                    string separador = string.Empty;

                    if (proximoGrupoComValor.Posicao == 1)
                    {
                        if (Posicao == 2
                            && proximoGrupoComValor.numero >= 100 && proximoGrupoComValor.numero >= 10)
                            separador = string.Empty;
                        else
                            separador = " e";
                    }
                    else
                    {
                        separador = ",";
                    }

                    return string.Format("{0} {1}{2} {3}",
                    digito.Extenso(),
                    nomeGrupo,
                    separador,
                    grupoFilho.Extenso());
                }
            }
        }
    }
}
