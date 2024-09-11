namespace GDS.Components.Validators
{
    using GDS.Components.ViewModels;
    using System.ComponentModel.DataAnnotations;

    public class RequiredSelectTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is SelectViewModel selectViewModel && string.IsNullOrEmpty(selectViewModel.Value))
            {
                return new ValidationResult(ErrorMessage ?? "The field is required.", new[] { validationContext.MemberName + ".Value" });
            }

            return ValidationResult.Success;
        }
    }
}
