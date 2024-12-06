namespace Sirius.Domain.Util
{
    public static class DateUtil
    {
        public static DateTime CurrentDateByDay(int day)
        {
            var currentDate = DateTime.UtcNow;
            try
            {
                return new DateTime(currentDate.Year, currentDate.Month, day);
            }
            catch (Exception)
            {
                var response = new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(1);
                return response.AddDays(-1);
            }
        }

        public static DateTime GetMinDate()
        {
            return new DateTime(2000, 1, 1);
        }

        public static string GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return string.Empty;
            }
        }
    }
}
