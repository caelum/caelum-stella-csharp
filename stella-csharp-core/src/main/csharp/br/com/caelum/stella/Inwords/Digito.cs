using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Inwords
{
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
}
