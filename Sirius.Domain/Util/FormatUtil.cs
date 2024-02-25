using System.Globalization;

namespace Sirius.Domain.Util
{
    public static class FormatUtil
    {
        public static string FormatCurrency(decimal currency, bool symbol = false)
        {
            var cultureInfo = CultureInfo.GetCultureInfo("pt-BR");
            var numberFormat = (NumberFormatInfo)cultureInfo.NumberFormat.Clone();
            if (symbol)
            {
                numberFormat.CurrencySymbol = "R$";
            }
            else
            {
                numberFormat.CurrencySymbol = string.Empty;
            }
            return currency.ToString("C", numberFormat);
        }
    }
}
