namespace GDS.Components.Validators
{
    using GDS.Components.ViewModels;
    using System.ComponentModel.DataAnnotations;
    public class RequiredCheckBoxTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is CheckBoxListViewModel checkBoxListViewModel && !checkBoxListViewModel.GetValues().Any())
            {
                return new ValidationResult(ErrorMessage ?? "The field is required.", new[] { validationContext.MemberName + ".Value" });
            }

            return ValidationResult.Success;
        }
    }
}
