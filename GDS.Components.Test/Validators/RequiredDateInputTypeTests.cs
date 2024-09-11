namespace GDS.Components.Test.Validators
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class RequiredDateInputTypeTests
    {
        private RequiredDateInputTypeAttribute _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new RequiredDateInputTypeAttribute { ErrorMessage = "Date field is required." };
        }

        [Test]
        public void ValidDateInputViewModelMustReturnSuccess()
        {
            // Arrange
            var today = DateTime.Today;
            var dateInputViewModel = new DateInputViewModel { Day = today.Day.ToString(), Month = today.Month.ToString(), Year = today.Year.ToString() };
            var validationContext = new ValidationContext(dateInputViewModel);

            // Act
            var result = _validator.GetValidationResult(dateInputViewModel, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [TestCaseSource(nameof(RequiredDateInputTypeAttributeModelData))]
        public void InvalidDateInputViewModelMustReturnValidationError(string day, string month, string year, string errorMessage)
        {
            // Arrange
            var dateInputViewModel = new DateInputViewModel
            {
                Day = day,
                Month = month,
                Year = year
            };
            var validationContext = new ValidationContext(dateInputViewModel);

            // Act
            var result = _validator.GetValidationResult(dateInputViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe(errorMessage);
            result.MemberNames.ShouldContain(".Value");
        }

        [TestCaseSource(nameof(DefaultRequiredDateInputTypeAttributeModelData))]
        public void DefaultInvalidDateInputViewModelMustReturnDefaultValidationError(string day, string month, string year, string errorMessage)
        {
            // Arrange
            _validator = new RequiredDateInputTypeAttribute();
            var dateInputViewModel = new DateInputViewModel
            {
                Day = day,
                Month = month,
                Year = year
            };
            var validationContext = new ValidationContext(dateInputViewModel);

            // Act
            var result = _validator.GetValidationResult(dateInputViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe(errorMessage);
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void NonDateInputViewModelMustReturnSuccess()
        {
            // Arrange
            var simpleObject = new object();
            var validationContext = new ValidationContext(simpleObject);

            // Act
            var result = _validator.GetValidationResult(simpleObject, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        public static IEnumerable<TestCaseData> RequiredDateInputTypeAttributeModelData()
        {
            yield return new TestCaseData(null, null, null, "Date field is required.");
            yield return new TestCaseData("", "", "", "Date field is required.");
            yield return new TestCaseData("1", "", "", "Valid Date field is required. You are missing a Month and Year.");
            yield return new TestCaseData("", "1", "", "Valid Date field is required. You are missing a Day and a Year.");
            yield return new TestCaseData("", "", "1", "Valid Date field is required. You are missing a Day and a Month.");
            yield return new TestCaseData("1", "1", "", "Valid Date field is required. You are missing a Year.");
            yield return new TestCaseData("", "1", "1", "Valid Date field is required. You are missing a Day.");
            yield return new TestCaseData("1", "", "1", "Valid Date field is required. You are missing a Month.");
            yield return new TestCaseData("x", "", "", "Valid Date field is required. You are missing a numeric Day, a Month and Year.");
            yield return new TestCaseData("", "x", "", "Valid Date field is required. You are missing a Day, a numeric Month and a Year.");
            yield return new TestCaseData("", "", "x", "Valid Date field is required. You are missing a Day, a Month and a numeric Year.");
            yield return new TestCaseData("x", "x", "", "Valid Date field is required. You are missing a numeric Day, a numeric Month and a Year.");
            yield return new TestCaseData("", "x", "x", "Valid Date field is required. You are missing a Day, a numeric Month and a numeric Year.");
            yield return new TestCaseData("x", "", "x", "Valid Date field is required. You are missing a numeric DayMonth and a numeric Year.");
            yield return new TestCaseData("x", "x", "x", "Valid Date field is required. You are missing a numeric Day, a numeric Month and a numeric Year.");
            yield return new TestCaseData("1", "", "x", "Valid Date field is required. You are missing a Month and a numeric Year.");
            yield return new TestCaseData("", "1", "x", "Valid Date field is required. You are missing a Day and a numeric Year.");
            yield return new TestCaseData("1", "1", "x", "Valid Date field is required. You are missing a numeric Year.");
            yield return new TestCaseData("32", "1", "2023", "Valid Date field is required. You are missing a valid numeric Day.");
            yield return new TestCaseData("1", "13", "2023", "Valid Date field is required. You are missing a valid numeric Month.");
            yield return new TestCaseData("29", "2", "2023", "Valid Date field is required.");
        }

        public static IEnumerable<TestCaseData> DefaultRequiredDateInputTypeAttributeModelData()
        {
            yield return new TestCaseData(null, null, null, "The date field is required.");
            yield return new TestCaseData("", "", "", "The date field is required.");
            yield return new TestCaseData("1", "", "", "Valid The date field is required. You are missing a Month and Year.");
            yield return new TestCaseData("", "1", "", "Valid The date field is required. You are missing a Day and a Year.");
            yield return new TestCaseData("", "", "1", "Valid The date field is required. You are missing a Day and a Month.");
            yield return new TestCaseData("1", "1", "", "Valid The date field is required. You are missing a Year.");
            yield return new TestCaseData("", "1", "1", "Valid The date field is required. You are missing a Day.");
            yield return new TestCaseData("1", "", "1", "Valid The date field is required. You are missing a Month.");
            yield return new TestCaseData("x", "", "", "Valid The date field is required. You are missing a numeric Day, a Month and Year.");
            yield return new TestCaseData("", "x", "", "Valid The date field is required. You are missing a Day, a numeric Month and a Year.");
            yield return new TestCaseData("", "", "x", "Valid The date field is required. You are missing a Day, a Month and a numeric Year.");
            yield return new TestCaseData("x", "x", "", "Valid The date field is required. You are missing a numeric Day, a numeric Month and a Year.");
            yield return new TestCaseData("", "x", "x", "Valid The date field is required. You are missing a Day, a numeric Month and a numeric Year.");
            yield return new TestCaseData("x", "", "x", "Valid The date field is required. You are missing a numeric DayMonth and a numeric Year.");
            yield return new TestCaseData("x", "x", "x", "Valid The date field is required. You are missing a numeric Day, a numeric Month and a numeric Year.");
            yield return new TestCaseData("1", "", "x", "Valid The date field is required. You are missing a Month and a numeric Year.");
            yield return new TestCaseData("", "1", "x", "Valid The date field is required. You are missing a Day and a numeric Year.");
            yield return new TestCaseData("32", "1", "2023", "Valid The date field is required. You are missing a valid numeric Day.");
            yield return new TestCaseData("1", "13", "2023", "Valid The date field is required. You are missing a valid numeric Month.");
            yield return new TestCaseData("29", "2", "2023", "Valid The date field is required.");
        }
    }
}
