namespace GDS.Components.Test.Validators
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Newtonsoft.Json;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class CustomRegExTypeAttributeTests
    {
        [TestCaseSource(nameof(RegexPatternValidSimpleDataTestValues))]
        public void CustomRegExTypeReturnsValidResultWhenSimpleInputMatchesPattern(string pattern, string input)
        {
            // Arrange
            var validator = new CustomRegExTypeAttribute { Pattern = pattern, ErrorMessage = "A valid input is required" };
            var validationContext = new ValidationContext(input);

            // Act
            var result = validator.GetValidationResult(input, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [TestCaseSource(nameof(RegexPatternValidComplexDataTestValues))]
        public void CustomRegExTypeReturnsValidResultWhenComplexInputMatchesPattern(string pattern, InputViewModel input)
        {
            // Arrange
            var validator = new CustomRegExTypeAttribute { Pattern = pattern, ErrorMessage = "A valid input is required" };
            var validationContext = new ValidationContext(input);

            // Act
            var result = validator.GetValidationResult(input, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [TestCaseSource(nameof(RegexPatternInvalidSimpleDataTestValues))]
        public void CustomRegExTypeReturnsCorrectInvalidResultWhenSimpleInputDoesNotMatchPattern(string pattern, string? input, string? errorMessage, string expectedErrorMessage)
        {
            // Arrange
            var validator = new CustomRegExTypeAttribute { Pattern = pattern, ErrorMessage = errorMessage };
            var validationContext = new ValidationContext(input);

            // Act
            var result = validator.GetValidationResult(input, validationContext);

            Console.WriteLine($"Simple Result {JsonConvert.SerializeObject(result)}");

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe(expectedErrorMessage);
        }

        [TestCaseSource(nameof(RegexPatternInvalidComplexDataTestValues))]
        public void CustomRegExTypeReturnsCorrectInvalidResultWhenComplexInputDoesNotMatchPattern(string pattern, InputViewModel input, string? errorMessage, string expectedErrorMessage)
        {
            // Arrange
            var validator = new CustomRegExTypeAttribute { Pattern = pattern, ErrorMessage = errorMessage };
            var validationContext = new ValidationContext(input);

            // Act
            var result = validator.GetValidationResult(input, validationContext);

            Console.WriteLine($"Complex Result {JsonConvert.SerializeObject(result)}");

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe(expectedErrorMessage);
            result.MemberNames.ShouldContain(".Value");
        }

        public static IEnumerable<TestCaseData> RegexPatternValidSimpleDataTestValues()
        {
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", string.Empty);
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", "AA123456B");
        }

        public static IEnumerable<TestCaseData> RegexPatternInvalidSimpleDataTestValues()
        { 
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", "123-45-6789", "Error Message populated", "Error Message populated");
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", "123-45-6789", null, "The value '123-45-6789' does not match the required pattern.");
        }

        public static IEnumerable<TestCaseData> RegexPatternValidComplexDataTestValues()
        {
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", new InputViewModel { Value = null });
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", new InputViewModel { Value = string.Empty });
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", new InputViewModel { Value = "AA123456B" });
        }

        public static IEnumerable<TestCaseData> RegexPatternInvalidComplexDataTestValues()
        {
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", new InputViewModel { Value = "123-45-6789" }, "Error Message populated", "Error Message populated");
            yield return new TestCaseData(@"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", new InputViewModel { Value = "123-45-6789" }, null, "The value '123-45-6789' does not match the required pattern.");
        }

    }
}
