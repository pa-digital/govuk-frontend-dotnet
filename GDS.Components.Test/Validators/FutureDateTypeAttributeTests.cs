namespace GDS.Components.Test.Validators
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class FutureDateTypeAttributeTests
    {
        private FutureDateTypeAttribute _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new FutureDateTypeAttribute { ErrorMessage = "A future date field is required." };
        }

        [TestCaseSource(nameof(ValidFutureDatesData))]
        public void ValidFutureDateInputViewModelMustReturnSuccess(string day, string month, string year)
        {
            // Arrange
             var dateInputViewModel = new DateInputViewModel { Day = day, Month = month, Year = year };
            var validationContext = new ValidationContext(dateInputViewModel);

            // Act
            var result = _validator.GetValidationResult(dateInputViewModel, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [TestCaseSource(nameof(InvalidFutureDatesNonDefaultErrorData))]
        public void InvalidFutureDateInputViewModelMustReturnValidationError(string day, string month, string year, string expectedErrorMessage)
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
            result.ErrorMessage.ShouldBe(expectedErrorMessage);
            result.MemberNames.ShouldContain(".Value");
        }
  
        [TestCaseSource(nameof(InvalidFutureDatesDefaultErrorData))]
        public void InvalidFutureDateWithoutErrorMessageMustUseDefaultMessage(string day, string month, string year, string expectedErrorMessage)
        {
            // Arrange
            var validator = new FutureDateTypeAttribute();
            var dateInputViewModel = new DateInputViewModel
            {
                Day = day,
                Month = month,
                Year = year
            };
            var validationContext = new ValidationContext(dateInputViewModel);

            // Act
            var result = validator.GetValidationResult(dateInputViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe(expectedErrorMessage);
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

        public static IEnumerable<TestCaseData> InvalidFutureDatesNonDefaultErrorData()
        {
            yield return new TestCaseData(null, null, null, "A future date field is required.");
            yield return new TestCaseData("1", null, null, "A future date field is required.");
            yield return new TestCaseData(null, "1", null, "A future date field is required.");
            yield return new TestCaseData(null, null, "2023", "A future date field is required.");
            yield return new TestCaseData("1", "1", null, "A future date field is required.");
            yield return new TestCaseData(null, "1", "2023", "A future date field is required.");
            yield return new TestCaseData("", "", "", "A future date field is required.");
            yield return new TestCaseData("1", "", "", "A future date field is required.");
            yield return new TestCaseData("", "1", "", "A future date field is required.");
            yield return new TestCaseData("", "", "1", "A future date field is required.");
            yield return new TestCaseData("1", "1", "", "A future date field is required.");
            yield return new TestCaseData("", "1", "1", "A future date field is required.");
            yield return new TestCaseData("1", "", "1", "A future date field is required.");
            yield return new TestCaseData("x", "", "", "A future date field is required.");
            yield return new TestCaseData("", "x", "", "A future date field is required.");
            yield return new TestCaseData("", "", "x", "A future date field is required.");
            yield return new TestCaseData("x", "x", "", "A future date field is required.");
            yield return new TestCaseData("", "x", "x", "A future date field is required.");
            yield return new TestCaseData("x", "", "x", "A future date field is required.");
            yield return new TestCaseData("x", "x", "x", "A future date field is required.");
            yield return new TestCaseData("32", "1", "2023", "A future date field is required.");
            yield return new TestCaseData("1", "13", "2023", "A future date field is required.");
            yield return new TestCaseData("1", "1", "-2023", "A future date field is required.");
            var today = DateTime.Today;
            var todayDateOnly = DateOnly.FromDateTime(today);
            var yesterdayDateOnly = DateOnly.FromDateTime(today).AddDays(-1);
            yield return new TestCaseData(yesterdayDateOnly.Day.ToString(), yesterdayDateOnly.Month.ToString(), yesterdayDateOnly.Year.ToString(), "A future date field is required.");
        }

        public static IEnumerable<TestCaseData> InvalidFutureDatesDefaultErrorData()
        {
            yield return new TestCaseData(null, null, null, "The date input field is required.");
            yield return new TestCaseData("1", null, null, "The date input field is required.");
            yield return new TestCaseData(null, "1", null, "The date input field is required.");
            yield return new TestCaseData(null, null, "2023", "The date input field is required.");
            yield return new TestCaseData("1", "1", null, "The date input field is required.");
            yield return new TestCaseData(null, "1", "2023", "The date input field is required.");
            yield return new TestCaseData("", "", "", "The date input field is required.");
            yield return new TestCaseData("1", "", "", "The date input field is required.");
            yield return new TestCaseData("", "1", "", "The date input field is required.");
            yield return new TestCaseData("", "", "1", "The date input field is required.");
            yield return new TestCaseData("1", "1", "", "The date input field is required.");
            yield return new TestCaseData("", "1", "1", "The date input field is required.");
            yield return new TestCaseData("1", "", "1", "The date input field is required.");
            yield return new TestCaseData("x", "", "", "The date input field is required.");
            yield return new TestCaseData("", "x", "", "The date input field is required.");
            yield return new TestCaseData("", "", "x", "The date input field is required.");
            yield return new TestCaseData("x", "x", "", "The date input field is required.");
            yield return new TestCaseData("", "x", "x", "The date input field is required.");
            yield return new TestCaseData("x", "", "x", "The date input field is required.");
            yield return new TestCaseData("x", "x", "x", "The date input field is required.");
            yield return new TestCaseData("32", "1", "2023", "The date input field is required.");
            yield return new TestCaseData("1", "13", "2023", "The date input field is required.");
            yield return new TestCaseData("1", "1", "-2023", "The date input field is required.");
            var today = DateTime.Today;
            var todayDateOnly = DateOnly.FromDateTime(today);
            var yesterdayDateOnly = DateOnly.FromDateTime(today).AddDays(-1);
            yield return new TestCaseData(yesterdayDateOnly.Day.ToString(), yesterdayDateOnly.Month.ToString(), yesterdayDateOnly.Year.ToString(), "A future date input field is required.");
        }

        public static IEnumerable<TestCaseData> ValidFutureDatesData()
        {
            var today = DateTime.Today;
            var todayDateOnly = DateOnly.FromDateTime(today);
            var tomorrowDateOnly = DateOnly.FromDateTime(today).AddDays(1);
            var nextMonthDateOnly = DateOnly.FromDateTime(today).AddMonths(1);
            var nextYearDateOnly = DateOnly.FromDateTime(today).AddMonths(1);
            yield return new TestCaseData(todayDateOnly.Day.ToString(), todayDateOnly.Month.ToString(), todayDateOnly.Year.ToString());
            yield return new TestCaseData(tomorrowDateOnly.Day.ToString(), tomorrowDateOnly.Month.ToString(), tomorrowDateOnly.Year.ToString());
            yield return new TestCaseData(nextMonthDateOnly.Day.ToString(), nextMonthDateOnly.Month.ToString(), nextMonthDateOnly.Year.ToString());
            yield return new TestCaseData(nextYearDateOnly.Day.ToString(), nextYearDateOnly.Month.ToString(), nextYearDateOnly.Year.ToString());
        }
    }
}
