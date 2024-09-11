using GDS.Components.Enum;

namespace GDS.Components.Helpers
{
    public static class DataValidators
    {
        public static (bool isEntryOk, string response) ValidateNumeric(string data, int maxVal)
        {
            var isEntryOk = false;
            var response = string.Empty;

            isEntryOk = int.TryParse(data, out int monthResult);

            if (!isEntryOk)
            {
                response = "numeric";
            }
            else
            {
                if (monthResult > maxVal)
                {
                    isEntryOk = false;
                    response = "valid numeric";
                }
            }

            return (isEntryOk, response);
        }

        public static (bool isEntryOk, DateOnly? response) ValidateStringDate(string day, string month, string year)
        {
            var dateString = $"{day}-{month}-{year}";
            var isEntryOk = DateOnly.TryParse(dateString, out DateOnly parsedDate);

            if (!isEntryOk)
            {
                return (false, null);
            }

            return (true, parsedDate);
        }

        public static (bool isEntryOk, DateOnly? response) ValidateDate(int day, int month, int year)
        {
            var dateString = $"{year}-{month}-{day}";
            var isEntryOk = DateOnly.TryParse(dateString, out DateOnly parsedDate);

            if (!isEntryOk)
            {
                return (false, null);
            }

            return (true, parsedDate);
        }

        public static DateInputErrorType CalculateDateErrorType(bool isDayOk, bool isMonthOk, bool isYearOk)
        {
            var errorType = DateInputErrorType.None;

            if (!isDayOk && isMonthOk && isYearOk)
            {
                errorType = DateInputErrorType.DayOnly;
            }
            else if (isDayOk && !isMonthOk && isYearOk)
            {
                errorType = DateInputErrorType.MonthOnly;
            }
            else if (isDayOk && isMonthOk && !isYearOk)
            {
                errorType = DateInputErrorType.YearOnly;
            }
            else if (!isDayOk && !isMonthOk && isYearOk)
            {
                errorType = DateInputErrorType.DayMonth;
            }
            else if (!isDayOk && isMonthOk && !isYearOk)
            {
                errorType = DateInputErrorType.DayYear;
            }
            else if (isDayOk && !isMonthOk && !isYearOk)
            {
                errorType = DateInputErrorType.MonthYear;
            }
            else if (!isDayOk && !isMonthOk && !isYearOk)
            {
                errorType = DateInputErrorType.All;
            }

            return errorType;
        }
    }
}
