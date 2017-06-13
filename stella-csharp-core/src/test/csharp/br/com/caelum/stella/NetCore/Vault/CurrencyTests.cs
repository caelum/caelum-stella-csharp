using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caelum.Stella.CSharp.Vault;

namespace Caelum.Stella.CSharp.Vault.Tests
{
    [TestClass]
    public class CurrencyTests
    {
        private CultureInfo _culture;

        [TestInitialize]
        public void TestInitialize()
        {
            _culture = CultureInfo.CurrentCulture;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CultureInfo.DefaultThreadCurrentCulture = _culture;
        }
        
        [TestMethod]
        public void Can_create_currency_using_culture_info()
        {
            CurrencyInfo currencyInfo = new CultureInfo("fr-FR");
            Assert.IsNotNull(currencyInfo);
        }

        [TestMethod]
        public void Can_create_currency_using_currency_code()
        {
            CurrencyInfo currencyInfo = Currency.EUR;
            Assert.IsNotNull(currencyInfo);
        }

        [TestMethod]
        public void Can_create_currency_using_current_culture()
        {
            CurrencyInfo currencyInfo = CultureInfo.CurrentCulture;
            Assert.IsNotNull(currencyInfo);
        }

        [TestMethod]
        public void Can_create_currency_using_region_info()
        {
            CurrencyInfo currencyInfo = new RegionInfo("BR");
            Assert.IsNotNull(currencyInfo);
        }

        [TestMethod]
        public void Currency_creation_creates_meaningful_display_cultures()
        {
            // If I'm from Great Britain, and I reference American Dollars,
            // then the default culture for USD should be en-US
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
            CurrencyInfo currencyInfo = Currency.USD;
            Assert.AreEqual(currencyInfo.DisplayCulture, new CultureInfo("en-US"));

            // If I'm from England, and I reference Reais,
            // then the default culture for BRL should be pt-BR
            //CultureInfo.CurrentCulture = new CultureInfo("en-GB");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");

            currencyInfo = Currency.BRL;
            Assert.AreEqual(currencyInfo.DisplayCulture, new CultureInfo("pt-BR"));

            // If I'm from Germany, and I reference US Dollars,
            // then the default culture for USD should be American
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
            currencyInfo = Currency.USD;
            Assert.AreEqual(new CultureInfo("en-US"), currencyInfo.DisplayCulture);

            // ... and it should not display as if it were in de currency!
            Money money = new Money(Currency.USD, 1000);
            Assert.AreEqual("$1,000.00", money.DisplayNative());

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
		    money = new Money(1000);
		    var german = new CultureInfo("de-DE");
            Console.WriteLine(money.DisplayIn(german));  // Output: $1,000.00
        }

        //[TestMethod]
        //public void Currency_creation_creates_meaningful_native_regions()
        //{
        //    CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
        //    CurrencyInfo currencyInfo = Currency.EUR;
        //    Assert.AreEqual(currencyInfo.NativeRegion, new RegionInfo("FR"));

        //    CultureInfo.CurrentCulture = new CultureInfo("en-US");
        //    currencyInfo = Currency.USD;
        //    Assert.AreEqual(currencyInfo.NativeRegion, new RegionInfo("US"));
        //}
    }
}