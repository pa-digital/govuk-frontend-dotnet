namespace GDS.Components.Validators
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class CustomRegExTypeAttribute : ValidationAttribute
    {
        public string Pattern { get; set; }
        public new string ErrorMessage { get; set; }

        public CustomRegExTypeAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueProperty = value.GetType().GetProperty("Value");
                if (valueProperty != null)
                {
                    var propertyValue = valueProperty.GetValue(value) as string;

                    if (!string.IsNullOrEmpty(propertyValue))
                    {
                        var regex = new Regex(Pattern);
                        if (!regex.IsMatch(propertyValue))
                        {
                            return new ValidationResult(ErrorMessage ?? $"The value '{propertyValue}' does not match the required pattern.", new[] { validationContext.MemberName + ".Value" });
                        }
                    }
                }
                else
                {
                    var simpleValue = value as string;
                    if (!string.IsNullOrEmpty(simpleValue))
                    {
                        var regex = new Regex(Pattern);
                        if (!regex.IsMatch(simpleValue))
                        {
                            return new ValidationResult(ErrorMessage ?? $"The value '{simpleValue}' does not match the required pattern.");
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
