namespace GDS.Components.Validators
{
    using GDS.Components.Enum;
    using GDS.Components.Helpers;
    using GDS.Components.ViewModels;
    using System.ComponentModel.DataAnnotations;

    public class RequiredDateInputTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorType = DateInputErrorType.All;
            if (value is DateInputViewModel dateInputViewModel)
            {
                var error = ErrorMessage ?? "The date field is required.";
                if (!string.IsNullOrEmpty(dateInputViewModel.Day) && string.IsNullOrEmpty(dateInputViewModel.Month) && string.IsNullOrEmpty(dateInputViewModel.Year))
                {
                    var (isDayOk, response) = DataValidators.ValidateNumeric(dateInputViewModel.Day, 31);
                    var DayError = string.Empty;
                    if (!isDayOk)
                    {
                        DayError = $"{response} Day, a ";
                    }
                    errorType = DataValidators.CalculateDateErrorType(isDayOk, false, false);
                    var fullError = $"Valid {error} You are missing a {DayError}Month and Year.";
                    return new CustomDateValidationResult(fullError, errorType, new[] { validationContext.MemberName + ".Value" });
                }
                if (string.IsNullOrEmpty(dateInputViewModel.Day) && !string.IsNullOrEmpty(dateInputViewModel.Month) && string.IsNullOrEmpty(dateInputViewModel.Year))
                {
                    var (isMonthOk, response) = DataValidators.ValidateNumeric(dateInputViewModel.Month, 12);
                    var MonthError = string.Empty;
                    if (!isMonthOk)
                    {
                        MonthError = $", a {response} Month";
                    }
                    errorType = DataValidators.CalculateDateErrorType(false, isMonthOk, false);
                    var fullError = $"Valid {error} You are missing a Day{MonthError} and a Year.";
                    return new CustomDateValidationResult(fullError, errorType, new[] { validationContext.MemberName + ".Value" });
                }
                if (string.IsNullOrEmpty(dateInputViewModel.Day) && string.IsNullOrEmpty(dateInputViewModel.Month) && !string.IsNullOrEmpty(dateInputViewModel.Year))
                {
                    var IsYearOk = int.TryParse(dateInputViewModel.Year, out int yearResult);
                    var YearError = string.Empty;
                    var MissingError = "a Day and a Month";
                    if (!IsYearOk)
                    {
                        MissingError = "a Day, a Month";
                        YearError = " and a numeric Year";
                    }
                    errorType = DataValidators.CalculateDateErrorType(false, false, IsYearOk);
                    var fullError = $"Valid {error} You are missing {MissingError}{YearError}.";
                    return new CustomDateValidationResult(fullError, errorType, new[] { validationContext.MemberName + ".Value" });
                }
                if (!string.IsNullOrEmpty(dateInputViewModel.Day) && !string.IsNullOrEmpty(dateInputViewModel.Month) && string.IsNullOrEmpty(dateInputViewModel.Year))
                {
                    var (isDayOk, dayResponse) = DataValidators.ValidateNumeric(dateInputViewModel.Day, 31);
                    var DayError = string.Empty;
                    if (!isDayOk)
                    {
                        DayError = $"{dayResponse} Day and a ";
                    }
                    var (isMonthOk, response) = DataValidators.ValidateNumeric(dateInputViewModel.Month, 12);
                    var MonthError = string.Empty;
                    if (!isMonthOk)
                    {
                        if (!isDayOk)
                        {
                            DayError = DayError.Replace(" and a ", ", a ");
                        }
                        MonthError = $"{response} Month and a ";
                    }
                    errorType = DataValidators.CalculateDateErrorType(isDayOk, isMonthOk, false);
                    var fullError = $"Valid {error} You are missing a {DayError}{MonthError}Year.";
                    return new CustomDateValidationResult(fullError, errorType, new[] { validationContext.MemberName + ".Value" });
                }
                if (!string.IsNullOrEmpty(dateInputViewModel.Day) && string.IsNullOrEmpty(dateInputViewModel.Month) && !string.IsNullOrEmpty(dateInputViewModel.Year))
                {
                    var (isDayOk, dayResponse) = DataValidators.ValidateNumeric(dateInputViewModel.Day, 31);
                    var DayError = string.Empty;
                    if (!isDayOk)
                    {
                        DayError = $"{dayResponse} Day and a ";
                    }
                    var IsYearOk = int.TryParse(dateInputViewModel.Year, out int yearResult);
                    var YearError = string.Empty;
                    if (!IsYearOk)
                    {
                        if (!isDayOk)
                        {
                            DayError = DayError.Replace(" and a ", "");
                        }
                        YearError = " and a numeric Year";
                    }
                    var fullError = $"Valid {error} You are missing a {DayError}Month{YearError}.";
                    errorType = DataValidators.CalculateDateErrorType(isDayOk, false, IsYearOk);
                    return new CustomDateValidationResult(fullError, errorType, new[] { validationContext.MemberName + ".Value" });
                }
                if (string.IsNullOrEmpty(dateInputViewModel.Day) && !string.IsNullOrEmpty(dateInputViewModel.Month) && !string.IsNullOrEmpty(dateInputViewModel.Year))
                {
                    var (isMonthOk, response) = DataValidators.ValidateNumeric(dateInputViewModel.Month, 12);
                    var MonthError = string.Empty;
                    if (!isMonthOk)
                    {
                        MonthError = $", a {response} Month";
                    }
                    var IsYearOk = int.TryParse(dateInputViewModel.Year, out int yearResult);
                    var YearError = string.Empty;
                    if (!IsYearOk)
                    {
                        YearError = " and a numeric Year";
                    }
                    var fullError = $"Valid {error} You are missing a Day{MonthError}{YearError}.";
                    errorType = DataValidators.CalculateDateErrorType(false, isMonthOk, IsYearOk);
                    return new CustomDateValidationResult(fullError, errorType, new[] { validationContext.MemberName + ".Value" });
                }
                if (!string.IsNullOrEmpty(dateInputViewModel.Day) && !string.IsNullOrEmpty(dateInputViewModel.Month) && !string.IsNullOrEmpty(dateInputViewModel.Year))
                {
                    var (isDayOk, dayResponse) = DataValidators.ValidateNumeric(dateInputViewModel.Day, 31);
                    var DayError = string.Empty;
                    if (!isDayOk)
                    {
                        DayError = $"{dayResponse} Day";
                    }
                    var (isMonthOk, response) = DataValidators.ValidateNumeric(dateInputViewModel.Month, 12);
                    var MonthError = string.Empty;
                    if (!isMonthOk)
                    {
                        if (!isDayOk)
                        {
                            MonthError = $" and a {response} Month";
                        }
                        else
                        {
                            MonthError = $"{response} Month";
                        }
                    }
                    var IsYearOk = int.TryParse(dateInputViewModel.Year, out int yearResult);
                    var YearError = string.Empty;
                    if (!IsYearOk)
                    {
                        if (!isDayOk || !isMonthOk)
                        {
                            YearError = " and a numeric Year";
                        }
                        else
                        {
                            YearError = "numeric Year";
                        }
                        if (!isDayOk && !isMonthOk)
                        {
                            MonthError = $", a {response} Month";
                        }
                    }
                    if (!isDayOk || !isMonthOk || !IsYearOk)
                    {
                        var fullError = $"Valid {error} You are missing a {DayError}{MonthError}{YearError}.";
                        errorType = DataValidators.CalculateDateErrorType(isDayOk, isMonthOk, IsYearOk);
                        return new CustomDateValidationResult(fullError, errorType, new[] { validationContext.MemberName + ".Value" });
                    }
                    else
                    {
                        var (isDateOk, dateResponse) = DataValidators.ValidateStringDate(dateInputViewModel.Day, dateInputViewModel.Month, dateInputViewModel.Year);
                        if (isDateOk)
                        {
                            return ValidationResult.Success;
                        } else
                        {
                            var fullError = $"Valid {error}";
                            errorType = DataValidators.CalculateDateErrorType(isDayOk, isMonthOk, IsYearOk);
                            return new CustomDateValidationResult(fullError, errorType, new[] { validationContext.MemberName + ".Value" });
                        }
                        
                    }
                }
                
                return new CustomDateValidationResult(error, DateInputErrorType.All, new[] { validationContext.MemberName + ".Value" });
            }

            return ValidationResult.Success;
        }
    }
}
