namespace GDS.Components.Validators
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using System.ComponentModel.DataAnnotations;

    public class FutureDateTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateInputViewModel dateInputViewModel)
            {
                var error = ErrorMessage ?? "A future date input field is required.";

                var validationDate = dateInputViewModel.GetValues();
                if (validationDate.Date != null)
                {
                    var today = DateOnly.FromDateTime(DateTime.Today);

                    if (validationDate.Date == today)
                    {
                        return ValidationResult.Success;
                    }
                    else if (validationDate.Date > today)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new CustomDateValidationResult(error, DateInputErrorType.All, new[] { validationContext.MemberName + ".Value" });
                    }
                }

                return new CustomDateValidationResult(ErrorMessage ?? "The date input field is required.", DateInputErrorType.All, new[] { validationContext.MemberName + ".Value" });
            }

            return ValidationResult.Success;
        }
    }
}
