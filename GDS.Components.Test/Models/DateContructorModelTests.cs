namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using Shouldly;
    using System.Reflection;

    [TestFixture]
    public class DateConstructorModelTests
    {
        [Test]
        public void DateConstructorModelHasCorrectNumberOfFields()
        {
            // Arrange/Act
            var assembly = Assembly.Load("GDS.Components");
            var modelType = assembly.GetType("GDS.Components.Models.DateConstructorModel");
            var model = Activator.CreateInstance(modelType, new object[] { "01", "01", "2025" });

            // Assert
            Assert.That(model, Is.Not.Null);
            var fields = modelType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            fields.Length.ShouldBe(4);
        }

        [Test]
        public void DateConstructorModelHasCorrectFieldTypes()
        {
            // Arrange
            var assembly = Assembly.Load("GDS.Components");
            var modelType = assembly.GetType("GDS.Components.Models.DateConstructorModel");
            var model = Activator.CreateInstance(modelType, new object[] { "01", "01", "2025" });

            // Act/Assert
            model.ShouldNotBeNull();

            var dayField = modelType.GetField("Day");
            dayField.ShouldNotBeNull();
            dayField.FieldType.ShouldBe(typeof(int));

            var monthField = modelType.GetField("Month");
            monthField.ShouldNotBeNull();
            monthField.FieldType.ShouldBe(typeof(int));

            var yearField = modelType.GetField("Year");
            yearField.ShouldNotBeNull();
            yearField.FieldType.ShouldBe(typeof(int));

            var dateField = modelType.GetField("Date");
            dateField.ShouldNotBeNull();
            dateField.FieldType.ShouldBe(typeof(DateOnly?));
        }

        [TestCaseSource(typeof(DateConstructorModelTests), nameof(DateConstructorModelInitialisationData))]
        public void DateConstructorModelHasCorrectInitialisedValues(string day, string month, string year, int dayValue, int monthValue, int yearValue, DateOnly? dateValue)
        {
            // Arrange/Act
            var model = new DateConstructorModel(day, month, year);

            // Assert
            model.Day.ShouldBe(dayValue);
            model.Month.ShouldBe(monthValue);
            model.Year.ShouldBe(yearValue);
            model.Date.ShouldBe(dateValue);
        }

        public static IEnumerable<TestCaseData> DateConstructorModelInitialisationData()
        {
            yield return new TestCaseData("", "", "", 0, 0, 0, null);
            yield return new TestCaseData("1", "", "", 0, 0, 0, null);
            yield return new TestCaseData("", "1", "", 0, 0, 0, null);
            yield return new TestCaseData("", "", "1", 0, 0, 0, null);
            yield return new TestCaseData("1", "1", "", 0, 0, 0, null);
            yield return new TestCaseData("1", "", "1", 0, 0, 0, null);
            yield return new TestCaseData("", "1", "1", 0, 0, 0, null);
            yield return new TestCaseData("x", "", "", 0, 0, 0, null);
            yield return new TestCaseData("", "x", "", 0, 0, 0, null);
            yield return new TestCaseData("", "", "x", 0, 0, 0, null);
            yield return new TestCaseData("x", "x", "", 0, 0, 0, null);
            yield return new TestCaseData("x", "", "x", 0, 0, 0, null);
            yield return new TestCaseData("", "x", "x", 0, 0, 0, null);

            yield return new TestCaseData("1", "13", "2023", 0, 0, 0, null);
            yield return new TestCaseData("32", "1", "2023", 0, 0, 0, null);
            yield return new TestCaseData("1", "1", "2023", 1, 1, 2023, new DateOnly(2023, 1, 1));
        }
    }
}
