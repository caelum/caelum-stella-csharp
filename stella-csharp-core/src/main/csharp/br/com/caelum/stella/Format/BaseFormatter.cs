using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Caelum.Stella.CSharp.Format
{
    public class BaseFormatter : IFormatter
    {
        protected readonly string formatted;
        protected readonly string formattedReplacement;
        protected readonly string unformatted;
        protected readonly string unformattedReplacement;

        public BaseFormatter(string formatted, String formattedReplacement, string unformatted, String unformattedReplacement)
        {
            this.formatted = formatted;
            this.formattedReplacement = formattedReplacement;
            this.unformatted = unformatted;
            this.unformattedReplacement = unformattedReplacement;
        }

        public string Format(string value)
        {
            if (value == null) {
                throw new ArgumentNullException("Value may not be null.");
            }
            return new Regex(unformatted).Replace(value, formattedReplacement);
        }

        public string Unformat(string value)
        {
            if (value == null) {
                throw new ArgumentNullException("Value may not be null.");
            }

            if (new Regex(unformatted).IsMatch(value))
                return value;

            return new Regex(formatted).Replace(value, unformattedReplacement);
        }

        public bool IsFormatted(String value)
        {
            return new Regex(formatted).IsMatch(value);
        }

        public bool CanBeFormatted(String value)
        {
            return new Regex(unformatted).IsMatch(value);
        }
    }
}