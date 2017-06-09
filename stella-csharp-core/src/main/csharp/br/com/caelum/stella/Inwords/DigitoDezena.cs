using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Inwords
{
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
}
