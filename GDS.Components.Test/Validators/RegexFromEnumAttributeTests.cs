namespace GDS.Components.Test.Validators
{
    using GDS.Components.Enum;
    using GDS.Components.Validators;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class RegexFromEnumAttributeTests
    {
        [TestCaseSource(nameof(RegexValidatorValidData))]
        public void RegexValidatorPassesValidationForCorrectInput(Regex regExValue, string input)
        {
            // Arrange
            var validator = new RegexFromEnumAttribute(regExValue);
            var testObject = new TestRegexModel { Value = input };
            var validationContext = new ValidationContext(testObject);

            // Act
            var result = validator.GetValidationResult(testObject, validationContext);

            // Assert  
            result.ShouldBe(ValidationResult.Success);
            string.IsNullOrEmpty(result?.ErrorMessage).ShouldBeTrue();
        }

        [TestCaseSource(nameof(RegexValidatorInvalidData))]
        public void RegexValidatorFailsValidationForInvalidInputWithCorrectErrorMessage(Regex regExValue, string input, string expectedErrorMessage)
        {
            // Arrange
            var validator = new RegexFromEnumAttribute(regExValue);
            var testObject = new TestRegexModel { Value = input };
            var validationContext = new ValidationContext(testObject);

            // Act
            var result = validator.GetValidationResult(testObject, validationContext);

            // Assert  
            result.ShouldNotBe(ValidationResult.Success);
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe(expectedErrorMessage ?? string.Empty);
        }


        [TestCaseSource(nameof(RegexEnumPatternAndErrorValues))]
        public void MustReturnCorrectValidationPatternForEnum(Regex regExValue, string expectedPattern, string expectedErrorMessage)
        {
            // Arrange
            var validator = new RegexFromEnumAttribute(regExValue);

            // Act/Assert
            validator.Pattern.ShouldBe(expectedPattern);
            validator.ErrorMessage.ShouldBe(expectedErrorMessage);
        }

        [TestCaseSource(nameof(RegexEnumValues))]
        public void MustReturnCorrectValidationResultWhenNoValuePropertyExists(Regex regExValue)
        {
            // Arrange
            var validator = new RegexFromEnumAttribute(regExValue);
            var testObject = new TestNoValueModel { SomeOtherProperty = "12345" };
            var validationContext = new ValidationContext(testObject);

            // Act
            var result = validator.GetValidationResult(testObject, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage?.ShouldMatch("The model does not contain a 'Value' property.");
        }

        private class TestRegexModel
        {
            public string Value { get; set; }
        }

        private class TestNoValueModel {
            public string SomeOtherProperty { get; set; }
        }

        public static IEnumerable<TestCaseData> RegexEnumValues()
        {
            yield return new TestCaseData(Regex.Name);
            yield return new TestCaseData(Regex.Email);
            yield return new TestCaseData(Regex.Password);
        }

        public static IEnumerable<TestCaseData> RegexEnumPatternAndErrorValues()
        {
            yield return new TestCaseData(Regex.Name, @"^[a-zA-Z \-\']{2,}$", "Your name must contain at least two characters and can include (A-Z) (a-z) a space, a hyphen and an apostrophe");
            yield return new TestCaseData(Regex.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{1,}$", "Please enter a valid email containing a username, an @ symbol a domain and top level domain");
            yield return new TestCaseData(Regex.Password, @"^[a-zA-Z0-9\-]{8,}$", "Your password must contain at least 8 characters from (A-Z)(a-z)(0-9) and a -");
        }

        public static IEnumerable<TestCaseData> RegexValidatorValidData()
        {
            yield return new TestCaseData(Regex.Name, "Bob Smith");
            yield return new TestCaseData(Regex.Name, "Harry Toffy-Smyth");
            yield return new TestCaseData(Regex.Name, "Tom O'Reilly");

            yield return new TestCaseData(Regex.Email, "a@b.c");
            yield return new TestCaseData(Regex.Email, "a-b@b.c");
            yield return new TestCaseData(Regex.Email, "a.b@b.c");

            yield return new TestCaseData(Regex.Password, "abcd-f12");
            
        }

        public static IEnumerable<TestCaseData> RegexValidatorInvalidData()
        {
            var errorMessage = "Your name must contain at least two characters and can include (A-Z) (a-z) a space, a hyphen and an apostrophe";
            yield return new TestCaseData(Regex.Name, null, errorMessage);
            yield return new TestCaseData(Regex.Name, string.Empty, errorMessage);
            yield return new TestCaseData(Regex.Name, "a", errorMessage);
            yield return new TestCaseData(Regex.Name, "-", errorMessage);
            yield return new TestCaseData(Regex.Name, "A*", errorMessage);

            errorMessage = "Please enter a valid email containing a username, an @ symbol a domain and top level domain";
            yield return new TestCaseData(Regex.Email, null, errorMessage);
            yield return new TestCaseData(Regex.Email, string.Empty, errorMessage);
            yield return new TestCaseData(Regex.Email, "a", errorMessage);
            yield return new TestCaseData(Regex.Email, "a@", errorMessage);
            yield return new TestCaseData(Regex.Email, "a@b", errorMessage);
            yield return new TestCaseData(Regex.Email, "a@b.", errorMessage);
            yield return new TestCaseData(Regex.Email, "a*b@b.c", errorMessage);

            errorMessage = "Your password must contain at least 8 characters from (A-Z)(a-z)(0-9) and a -";
            yield return new TestCaseData(Regex.Password, null, errorMessage);
            yield return new TestCaseData(Regex.Password, string.Empty, errorMessage);
            yield return new TestCaseData(Regex.Password, "a", errorMessage);
            yield return new TestCaseData(Regex.Password, "ab", errorMessage);
            yield return new TestCaseData(Regex.Password, "abc", errorMessage);
            yield return new TestCaseData(Regex.Password, "abcd", errorMessage);
            yield return new TestCaseData(Regex.Password, "abcd-", errorMessage);
            yield return new TestCaseData(Regex.Password, "abcd-f", errorMessage);
            yield return new TestCaseData(Regex.Password, "abcd-f1", errorMessage);
            yield return new TestCaseData(Regex.Password, "abcd-f12*", errorMessage);

        }
    }
}
