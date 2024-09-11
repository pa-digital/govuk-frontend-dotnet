namespace GDS.Components.Validators
{
    using GDS.Components.ViewModels;
    using System.ComponentModel.DataAnnotations;
    public class RequiredRadioButtonTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is RadioButtonListViewModel radioButtonListViewModel && !radioButtonListViewModel.RadioButtons.Where(rb => rb.Checked).Any())
            {
                return new ValidationResult(ErrorMessage ?? "The field is required.", new[] { validationContext.MemberName + ".SelectedValue" });
            }

            return ValidationResult.Success;
        }
    }
}
