using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Inwords
{
    public class MoedaBRL : Moeda
    {
        protected override string MoedaSingular { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaBRLSingular"); }
        protected override string MoedaPlural { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaBRLPlural"); }
        protected override string CentavoSingular { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaCentavo"); }
        protected override string CentavoPlural { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaCentavos"); }

        public MoedaBRL(double numeroOrigem) : base(numeroOrigem)
        {
        }
    }
}
