namespace GDS.Components.Validators
{
    using GDS.Components.Enum;
    using System.ComponentModel.DataAnnotations;
    public class CustomDateValidationResult : ValidationResult
    {
        public DateInputErrorType ErrorType { get; }

        public CustomDateValidationResult(string errorMessage, DateInputErrorType errorType, IEnumerable<string> memberNames = null)
            : base(errorMessage, memberNames)
        {
            ErrorType = errorType;
        }
    }
}
