namespace GDS.Components.Extensions
{
    using System.Reflection;
    using System.Text;
    using GDS.Components.Validators;

    public static class ClientSideValidationProvider
    {
        public static string GenerateClientSideValidationScript(object model)
        {
            var scriptBuilder = new StringBuilder();
            var properties = model.GetType().GetProperties();
            var order = 1;
            foreach (var property in properties)
            {
                var requiredAttribute = property.GetCustomAttribute<RequiredComplexTypeAttribute>();
                if (requiredAttribute != null)
                {
                    var requiredErrorMessage = requiredAttribute.ErrorMessage ?? "This field is required."; 

                    scriptBuilder.AppendLine($"addRequiredValidation({order},'{property.Name}.Value', '{requiredErrorMessage}');");
                }

                var dateInputRequiredAttribute = property.GetCustomAttribute<RequiredDateInputTypeAttribute>();
                if (dateInputRequiredAttribute != null)
                {
                    var requiredErrorMessage = dateInputRequiredAttribute.ErrorMessage ?? "This field is required.";

                    scriptBuilder.AppendLine($"addDateInputRequiredValidation({order},'{property.Name}.Value', '{requiredErrorMessage}');");
                }

                var dateInputPastAttribute = property.GetCustomAttribute<PastDateTypeAttribute>();
                if (dateInputPastAttribute != null)
                {
                    var pastErrorMessage = dateInputPastAttribute.ErrorMessage ?? "A past date is required.";

                    scriptBuilder.AppendLine($"addDateInputPastValidation({order},'{property.Name}.Value', '{pastErrorMessage}');");
                }

                var dateInputFutureAttribute = property.GetCustomAttribute<FutureDateTypeAttribute>();
                if (dateInputFutureAttribute != null)
                {
                    var futureErrorMessage = dateInputFutureAttribute.ErrorMessage ?? "A future date is required.";

                    scriptBuilder.AppendLine($"addDateInputFutureValidation({order},'{property.Name}.Value', '{futureErrorMessage}');");
                }

                var radioRequiredAttribute = property.GetCustomAttribute<RequiredRadioButtonTypeAttribute>();
                if (radioRequiredAttribute != null)
                {
                    var requiredErrorMessage = radioRequiredAttribute.ErrorMessage ?? "This field is required.";

                    scriptBuilder.AppendLine($"addRequiredValidation({order},'{property.Name}.SelectedValue', '{requiredErrorMessage}', true);");
                }

                var checkBoxRequiredAttribute = property.GetCustomAttribute<RequiredCheckBoxTypeAttribute>();
                if (checkBoxRequiredAttribute != null)
                {
                    var requiredErrorMessage = checkBoxRequiredAttribute.ErrorMessage ?? "This field is required.";

                    scriptBuilder.AppendLine($"addRequiredValidation({order},'{property.Name}', '{requiredErrorMessage}', true);");
                }

                var selectRequiredAttribute = property.GetCustomAttribute<RequiredSelectTypeAttribute>();
                if (selectRequiredAttribute != null)
                {
                    var requiredErrorMessage = selectRequiredAttribute.ErrorMessage ?? "This field is required.";

                    scriptBuilder.AppendLine($"addRequiredValidation({order},'{property.Name}', '{requiredErrorMessage}', true);");
                }

                var regexAttribute = property.GetCustomAttribute<RegexFromEnumAttribute>();
                if (regexAttribute != null)
                {
                    var regexPattern = regexAttribute.Pattern;

                    scriptBuilder.AppendLine($"addRegexValidation({order},'{property.Name}.Value', '{regexPattern}', '{regexAttribute.ErrorMessage}');");
                }

                var customRegexAttribute = property.GetCustomAttribute<CustomRegExTypeAttribute>();
                if (customRegexAttribute != null)
                {
                    var regexPattern = customRegexAttribute.Pattern;

                    scriptBuilder.AppendLine($"addRegexValidation({order},'{property.Name}.Value', '{regexPattern}', '{customRegexAttribute.ErrorMessage}');");
                }

                order++;

            }

            return scriptBuilder.ToString();
        }
    }
}
