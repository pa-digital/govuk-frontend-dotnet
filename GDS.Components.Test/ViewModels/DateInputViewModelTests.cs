namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class DateInputViewModelTests
    {
        [Test]
        public void DateInputViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.DateInputViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(8);
        }

        [Test]
        public void DateInputViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.DateInputViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var legendProperty = model.GetProperty("Legend");
            legendProperty.ShouldNotBeNull();
            legendProperty.PropertyType.ShouldBe(typeof(string));

            var questionTypeProperty = model.GetProperty("QuestionType");
            questionTypeProperty.ShouldNotBeNull();
            questionTypeProperty.PropertyType.ShouldBe(typeof(InputMultiQuestionType));

            var dayProperty = model.GetProperty("Day");
            dayProperty.ShouldNotBeNull();
            dayProperty.PropertyType.ShouldBe(typeof(string));

            var monthProperty = model.GetProperty("Month");
            monthProperty.ShouldNotBeNull();
            monthProperty.PropertyType.ShouldBe(typeof(string));

            var yearProperty = model.GetProperty("Year");
            yearProperty.ShouldNotBeNull();
            yearProperty.PropertyType.ShouldBe(typeof(string));

            var hintProperty = model.GetProperty("Hint");
            hintProperty.ShouldNotBeNull();
            hintProperty.PropertyType.ShouldBe(typeof(string));

            var errorTypeProperty = model.GetProperty("ErrorType");
            errorTypeProperty.ShouldNotBeNull();
            errorTypeProperty.PropertyType.ShouldBe(typeof(DateInputErrorType));

        }

        [Test]
        public void DateInputViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new DateInputViewModel();

            //Assert
            model.Legend.ShouldBeNull();
            model.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            model.Day.ShouldBeNull();
            model.Month.ShouldBeNull();
            model.Year.ShouldBeNull();
            model.Hint.ShouldBeNull();
            model.ErrorType.ShouldBe(DateInputErrorType.None);
        }

        [Test]
        public void DateInputViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new DateInputViewModel();

            //Act
            model.Legend = "Legend";
            model.QuestionType = InputMultiQuestionType.Multiple;
            model.Day = "1";
            model.Month = "2";
            model.Year = "3";
            model.Hint = "Hint";
            model.ErrorType = DateInputErrorType.All;

            //Assert
            model.Legend.ShouldBe("Legend");
            model.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            model.Day.ShouldBe("1");
            model.Month.ShouldBe("2");
            model.Year.ShouldBe("3");
            model.Hint.ShouldBe("Hint");
            model.ErrorType.ShouldBe(DateInputErrorType.All);
        }

        [Test]
        public void DateInputViewModelGetValuesReturnsCorrectDateConstructorModel()
        {
            //Arrange
            var model = new DateInputViewModel
            {
                Day = "1",
                Month = "2",
                Year = "2024"
            };
            var expectedDate = new DateOnly(2024, 2, 1);

            //Act
            var result = model.GetValues();

            //Assert
            result.Day.ShouldBe(1);
            result.Month.ShouldBe(2);
            result.Year.ShouldBe(2024);
            result.Date.ShouldBe(expectedDate);
        }

        [TestCaseSource(nameof(DateInputViewModelDatesData))]
        public void DateInputViewModelGetValuesReturnsCorrectDateConstructorModelForInvalidValues(string? day, string? month, string? year, int expectedDay, int expectedMonth, int expectedYear)
        {
            //Arrange
            var model = new DateInputViewModel
            {
                Day = day,
                Month = month,
                Year = year
            };

            //Act
            var result = model.GetValues();

            //Assert
            result.Day.ShouldBe(expectedDay);
            result.Month.ShouldBe(expectedMonth);
            result.Year.ShouldBe(expectedYear);
            result.Date.ShouldBeNull();
        }

        public static IEnumerable<TestCaseData> DateInputViewModelDatesData()
        {
            yield return new TestCaseData(null, null, null, 0, 0, 0);
            yield return new TestCaseData("1", null, null, 0, 0, 0);
            yield return new TestCaseData(null, "1", null, 0, 0, 0);
            yield return new TestCaseData(null, null, "2024", 0, 0, 0);
            yield return new TestCaseData("1", "1", null, 0, 0, 0);
            yield return new TestCaseData(null, "1", "1", 0, 0, 0);
            yield return new TestCaseData("1", null, "1", 0, 0, 0);
            yield return new TestCaseData("32", "4", "2024", 0, 0, 0);
            yield return new TestCaseData("1", "13", "2024", 0, 0, 0);
            yield return new TestCaseData("x", "4", "2024", 0,0,0);
            yield return new TestCaseData("1", "x", "2024", 0, 0, 0);
            yield return new TestCaseData("1", "4", "x", 0, 0, 0);
            yield return new TestCaseData("", "4", "2024", 0, 0, 0);
            yield return new TestCaseData("1", "", "2024", 0, 0, 0);
            yield return new TestCaseData("1", "4", "", 0, 0, 0);
        }
    }
}
