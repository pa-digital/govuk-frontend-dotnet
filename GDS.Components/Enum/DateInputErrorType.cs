namespace GDS.Components.Enum
{
    public class DateInputErrorTypeExtensionsAttribute : Attribute
    {
        public string DayClassName { get; set; }
        public string MonthClassName { get; set; }
        public string YearClassName { get; set; }
    }

    public enum DateInputErrorType
    {
        [DateInputErrorTypeExtensions(DayClassName = "govuk-input govuk-date-input__input govuk-input--width-2", MonthClassName = "govuk-input govuk-date-input__input govuk-input--width-2", YearClassName = "govuk-input govuk-date-input__input govuk-input--width-4")]
        None,
        [DateInputErrorTypeExtensions(DayClassName = "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error", MonthClassName = "govuk-input govuk-date-input__input govuk-input--width-2", YearClassName = "govuk-input govuk-date-input__input govuk-input--width-4")]
        DayOnly,
        [DateInputErrorTypeExtensions(DayClassName = "govuk-input govuk-date-input__input govuk-input--width-2", MonthClassName = "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error", YearClassName = "govuk-input govuk-date-input__input govuk-input--width-4")]
        MonthOnly,
        [DateInputErrorTypeExtensions(DayClassName = "govuk-input govuk-date-input__input govuk-input--width-2", MonthClassName = "govuk-input govuk-date-input__input govuk-input--width-2", YearClassName = "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error")]
        YearOnly,
        [DateInputErrorTypeExtensions(DayClassName = "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error", MonthClassName = "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error", YearClassName = "govuk-input govuk-date-input__input govuk-input--width-4")]
        DayMonth,
        [DateInputErrorTypeExtensions(DayClassName = "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error", MonthClassName = "govuk-input govuk-date-input__input govuk-input--width-2", YearClassName = "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error")]
        DayYear,
        [DateInputErrorTypeExtensions(DayClassName = "govuk-input govuk-date-input__input govuk-input--width-2", MonthClassName = "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error", YearClassName = "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error")]
        MonthYear,
        [DateInputErrorTypeExtensions(DayClassName = "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error", MonthClassName = "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error", YearClassName = "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error")]
        All
    }
}
