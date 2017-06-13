using System.Collections.Generic;

namespace Caelum.Stella.CSharp.Vault
{
    partial class CurrencyInfo
    {
        private static readonly IDictionary<Currency, CurrencyInfo> Currencies = new Dictionary<Currency, CurrencyInfo>(9)
        {
            {
                Currency.USD,
                new CurrencyInfo
                    {
                        DisplayName = "US Dollar",
                        Code = Currency.USD
                    }
                },
            {
                Currency.EUR,
                new CurrencyInfo
                    {
                        DisplayName = "Euro",
                        Code = Currency.EUR
                    }
                },
            {
                Currency.BRL,
                new CurrencyInfo
                    {
                        DisplayName = "Real",
                        Code = Currency.BRL
                    }
                }
        };
    }
}