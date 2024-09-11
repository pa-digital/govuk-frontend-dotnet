namespace GDS.Components.Test.Validators
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class PastDateTypeAttributeTests
    {
        private PastDateTypeAttribute _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PastDateTypeAttribute { ErrorMessage = "A past date field is required." };
        }

        [TestCaseSource(nameof(ValidPastDatesData))]
        public void ValidPastDateInputViewModelMustReturnSuccess(string day, string month, string year)
        {
            // Arrange
            var dateInputViewModel = new DateInputViewModel { Day = day, Month = month, Year = year };
            var validationContext = new ValidationContext(dateInputViewModel);

            // Act
            var result = _validator.GetValidationResult(dateInputViewModel, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [TestCaseSource(nameof(InvalidPastDatesNonDefaultErrorData))]
        public void InvalidPastDateInputViewModelMustReturnValidationError(string day, string month, string year, string expectedErrorMessage)
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

        [TestCaseSource(nameof(InvalidPastDatesDefaultErrorData))]
        public void InvalidPastDateWithoutErrorMessageMustUseDefaultMessage(string day, string month, string year, string expectedErrorMessage)
        {
            // Arrange
            var validator = new PastDateTypeAttribute();
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

        public static IEnumerable<TestCaseData> InvalidPastDatesNonDefaultErrorData()
        {
            yield return new TestCaseData(null, null, null, "A past date field is required.");
            yield return new TestCaseData("1", null, null, "A past date field is required.");
            yield return new TestCaseData(null, "1", null, "A past date field is required.");
            yield return new TestCaseData(null, null, "2023", "A past date field is required.");
            yield return new TestCaseData("1", "1", null, "A past date field is required.");
            yield return new TestCaseData(null, "1", "2023", "A past date field is required.");
            yield return new TestCaseData("", "", "", "A past date field is required.");
            yield return new TestCaseData("1", "", "", "A past date field is required.");
            yield return new TestCaseData("", "1", "", "A past date field is required.");
            yield return new TestCaseData("", "", "1", "A past date field is required.");
            yield return new TestCaseData("1", "1", "", "A past date field is required.");
            yield return new TestCaseData("", "1", "1", "A past date field is required.");
            yield return new TestCaseData("1", "", "1", "A past date field is required.");
            yield return new TestCaseData("x", "", "", "A past date field is required.");
            yield return new TestCaseData("", "x", "", "A past date field is required.");
            yield return new TestCaseData("", "", "x", "A past date field is required.");
            yield return new TestCaseData("x", "x", "", "A past date field is required.");
            yield return new TestCaseData("", "x", "x", "A past date field is required.");
            yield return new TestCaseData("x", "", "x", "A past date field is required.");
            yield return new TestCaseData("x", "x", "x", "A past date field is required.");
            yield return new TestCaseData("32", "1", "2023", "A past date field is required.");
            yield return new TestCaseData("1", "13", "2023", "A past date field is required.");
            yield return new TestCaseData("1", "1", "-2023", "A past date field is required.");
            var today = DateTime.Today;
            var todayDateOnly = DateOnly.FromDateTime(today);
            var tomorrowDateOnly = DateOnly.FromDateTime(today).AddDays(1);
            yield return new TestCaseData(tomorrowDateOnly.Day.ToString(), tomorrowDateOnly.Month.ToString(), tomorrowDateOnly.Year.ToString(), "A past date field is required.");
        }

        public static IEnumerable<TestCaseData> InvalidPastDatesDefaultErrorData()
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
            var tomorrowDateOnly = DateOnly.FromDateTime(today).AddDays(1);
            yield return new TestCaseData(tomorrowDateOnly.Day.ToString(), tomorrowDateOnly.Month.ToString(), tomorrowDateOnly.Year.ToString(), "A past date input field is required.");
        }

        public static IEnumerable<TestCaseData> ValidPastDatesData()
        {
            var today = DateTime.Today;
            var todayDateOnly = DateOnly.FromDateTime(today);
            var yesterdayDateOnly = DateOnly.FromDateTime(today).AddDays(-1);
            var lastMonthDateOnly = DateOnly.FromDateTime(today).AddMonths(-1);
            var lastYearDateOnly = DateOnly.FromDateTime(today).AddYears(-1);
            yield return new TestCaseData(todayDateOnly.Day.ToString(), todayDateOnly.Month.ToString(), todayDateOnly.Year.ToString());
            yield return new TestCaseData(yesterdayDateOnly.Day.ToString(), yesterdayDateOnly.Month.ToString(), yesterdayDateOnly.Year.ToString());
            yield return new TestCaseData(lastMonthDateOnly.Day.ToString(), lastMonthDateOnly.Month.ToString(), lastMonthDateOnly.Year.ToString());
            yield return new TestCaseData(lastYearDateOnly.Day.ToString(), lastYearDateOnly.Month.ToString(), lastYearDateOnly.Year.ToString());
        }
    }
}
