using System;

namespace Caelum.Stella.CSharp.Vault
{
    /// <summary>
    /// Represents world currency by numeric and alphabetic values, as per ISO 4217:
    /// http://www.iso.org/iso/currency_codes_list-1. This enum is implicitly converted
    /// to <see cref="CurrencyInfo" /> instances internally, so you only need to reference this
    /// enum to work with rich currency objects. 
    /// </summary>
    //[Serializable]
    public enum Currency : ushort
    {
        /// <summary>
        /// USD
        /// </summary>
        USD = 840,
        /// <summary>
        /// EUR
        /// </summary>
        EUR = 978,
        /// <summary>
        /// BRL
        /// </summary>
        BRL = 986
    }
}