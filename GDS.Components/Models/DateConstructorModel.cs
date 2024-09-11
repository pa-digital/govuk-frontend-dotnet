namespace GDS.Components.Models
{
    public class DateConstructorModel
    {
        public int Day;
        public int Month;
        public int Year;
        public readonly DateOnly? Date;

        public DateConstructorModel(string day, string month, string year)
        {
            if (int.TryParse(day, out int dayValue) &&
            int.TryParse(month, out int monthValue) &&
            int.TryParse(year, out int yearValue))
            {
                Day = dayValue;
                Month = monthValue;
                Year = yearValue;

                try
                {
                    Date = new DateOnly(Year, Month, Day);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Day = 0;
                    Month = 0;
                    Year = 0;
                    Date = null;
                }
            }
        }
    }
}
