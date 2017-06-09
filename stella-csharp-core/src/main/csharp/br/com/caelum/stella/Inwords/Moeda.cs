using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Inwords
{
    public abstract class Moeda : NumeroPT
    {
        protected abstract string MoedaSingular { get; }
        protected abstract string MoedaPlural { get; }
        protected abstract string CentavoSingular { get; }
        protected abstract string CentavoPlural { get; }

        public Moeda(double numeroOrigem) : base(numeroOrigem)
        {
        }

        protected override double PreparaNumeroOrigem(double numeroOrigem)
        {
            return numeroOrigem;
        }

        public override string Extenso()
        {
            StringBuilder builder = new StringBuilder();
            BuildInteiros(numeroOrigem, builder);
            BuildCentavos(numeroOrigem, builder);
            return builder.ToString();
        }

        private void BuildInteiros(double numeroOrigem, StringBuilder builder)
        {
            if (numeroOrigem < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (numeroOrigem >= 1.0 || numeroOrigem == 0)
            {
                BuildNumeroMoeda(numeroOrigem, builder);
                BuildPreposicaoMilhoes(numeroOrigem, builder);
                BuildPalavraMoeda(numeroOrigem, builder);
            }
        }

        protected virtual void BuildPreposicaoMilhoes(double numeroOrigem, StringBuilder builder)
        {
            if (numeroOrigem >= 1000000
                && Math.Truncate(numeroOrigem) % 1000000 == 0)
                builder.Append(" de ");
            else
                builder.Append(" ");
        }

        private void BuildNumeroMoeda(double numeroOrigem, StringBuilder builder)
        {
            builder.Append(new NumeroPT(Math.Truncate(numeroOrigem)).Extenso());
        }

        private void BuildPalavraMoeda(double numeroOrigem, StringBuilder builder)
        {
            if (Math.Truncate(numeroOrigem) > 1)
                builder.Append(MoedaPlural);
            else
                builder.Append(MoedaSingular);
        }

        private void BuildCentavos(double numeroOrigem, StringBuilder builder)
        {
            double centavos = Math.Round((numeroOrigem - Math.Truncate(numeroOrigem)) * 100);
            if (centavos > 0)
            {
                if (numeroOrigem >= 1.0)
                    builder.Append(ResourceManagerHelper.Instance.ResourceManager.GetString("Extensosep"));

                BuildNumeroCentavos(centavos, builder);
                builder.Append(" ");
                BuildPalavraCentavos(centavos, builder);
            }
        }

        private void BuildNumeroCentavos(double centavos, StringBuilder builder)
        {
            builder.Append(new NumeroPT(centavos).Extenso());
        }

        private void BuildPalavraCentavos(double centavos, StringBuilder builder)
        {
            if (Math.Truncate(centavos) > 1)
                builder.Append(CentavoPlural);
            else
                builder.Append(CentavoSingular);
        }
    }
}
