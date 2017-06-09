using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Inwords
{
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
}
