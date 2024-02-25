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
                var response = new DateTime(currentDate.Year, currentDate.Month + 1, 1);
                return response.AddDays(-1);
            }
        }
    }
}
