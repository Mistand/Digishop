using System.Globalization;

namespace Digiseller.Client.Core.Helpers
{
    public static class DecimalExtension
    {
        public static decimal Parse(this string s)
        {
            s = s.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            return decimal.TryParse(s, NumberStyles.Any,
                CultureInfo.InvariantCulture, out decimal result)
                ? result
                : 0.0M;
        }
    }
}
