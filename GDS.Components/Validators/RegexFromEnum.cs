namespace GDS.Components.Validators
{
    using GDS.Components.Enum;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public class RegexFromEnumAttribute : ValidationAttribute
    {
        private readonly Regex _regexEnum;
        public string Pattern { get; private set; }
        public string ErrorMessage { get; private set; }

        public RegexFromEnumAttribute(Regex regexEnum)
        {
            _regexEnum = regexEnum;
            var regexAttribute = _regexEnum.GetType()
                                       .GetField(_regexEnum.ToString())
                                       .GetCustomAttribute<RegexValidatorExtensionsAttribute>();

            if (regexAttribute != null)
            {
                Pattern = regexAttribute.Pattern;
                ErrorMessage = regexAttribute.Error;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var regexAttribute = _regexEnum.GetType()
                                               .GetField(_regexEnum.ToString())
                                               .GetCustomAttribute<RegexValidatorExtensionsAttribute>();

                if (regexAttribute != null)
                {
                    var pattern = regexAttribute.Pattern;
                    var regex = new System.Text.RegularExpressions.Regex(pattern);
                    var valueProperty = value.GetType().GetProperty("Value");
                    if (valueProperty != null)
                    {
                        var propertyValue = valueProperty.GetValue(value) as string;

                        if (!regex.IsMatch(propertyValue ?? ""))
                        {
                            return new ValidationResult(regexAttribute.Error, new[] { validationContext.MemberName + ".Value" });
                        }
                    }
                    else
                    {
                        return new ValidationResult("The model does not contain a 'Value' property.");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
