namespace GDS.Components.Validators
{
    using GDS.Components.ViewModels;
    using System.ComponentModel.DataAnnotations;

    public class RequiredComplexTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage ?? "The field is required.", new[] { validationContext.MemberName });
            }

            if (value is InputViewModel inputViewModel && string.IsNullOrWhiteSpace(inputViewModel.Value))
            {
                return new ValidationResult(ErrorMessage ?? "The field is required.", new[] { validationContext.MemberName + ".Value" });
            }

            if (value is PasswordViewModel passwordViewModel && string.IsNullOrWhiteSpace(passwordViewModel.Value))
            {
                return new ValidationResult(ErrorMessage ?? "The field is required.", new[] { validationContext.MemberName + ".Value" });
            }

            return ValidationResult.Success;
        }
    }
}