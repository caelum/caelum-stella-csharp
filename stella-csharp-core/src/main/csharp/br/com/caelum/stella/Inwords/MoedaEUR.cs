using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Inwords
{
    public class MoedaEUR : Moeda
    {
        protected override string MoedaSingular { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaEURSingular"); }
        protected override string MoedaPlural { get => ResourceManagerHelper.Instance.ResourceManager.GetString("MoedaEURPlural"); }

        public MoedaEUR(double numeroOrigem) : base(numeroOrigem)
        {
        }
    }
}
