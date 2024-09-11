namespace GDS.Components.Test.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModelCalculationModels;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class DateInputViewCalculationsModelTests
    {
        [Test]
        public void DateInputViewCalculationsModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.DateInputViewCalculationsModel, GDS.Components");

            // Assert
            model.ShouldNotBeNull();
            model.GetFields().Length.ShouldBe(10);
        }

        [Test]
        public void DateInputViewCalculationsModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.DateInputViewCalculationsModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var containerClassField = model.GetField("containerClass");
            containerClassField.ShouldNotBeNull();
            containerClassField.FieldType.ShouldBe(typeof(string));

            var legendClassField = model.GetField("legendClass");
            legendClassField.ShouldNotBeNull();
            legendClassField.FieldType.ShouldBe(typeof(string));

            var showH1Field = model.GetField("showH1");
            showH1Field.ShouldNotBeNull();
            showH1Field.FieldType.ShouldBe(typeof(bool));

            var isHintField = model.GetField("isHint");
            isHintField.ShouldNotBeNull();
            isHintField.FieldType.ShouldBe(typeof(bool));

            var isErrorField = model.GetField("isError");
            isErrorField.ShouldNotBeNull();
            isErrorField.FieldType.ShouldBe(typeof(bool));

            var describedByTagField = model.GetField("describedByTag");
            describedByTagField.ShouldNotBeNull();
            describedByTagField.FieldType.ShouldBe(typeof(string));

            var showDescribedByTagField = model.GetField("showDescribedByTag");
            showDescribedByTagField.ShouldNotBeNull();
            showDescribedByTagField.FieldType.ShouldBe(typeof(bool));

            var dayInputClassNameField = model.GetField("dayInputClassName");
            dayInputClassNameField.ShouldNotBeNull();
            dayInputClassNameField.FieldType.ShouldBe(typeof(string));

            var monthInputClassNameField = model.GetField("monthInputClassName");
            monthInputClassNameField.ShouldNotBeNull();
            monthInputClassNameField.FieldType.ShouldBe(typeof(string));

            var yearInputClassNameField = model.GetField("yearInputClassName");
            yearInputClassNameField.ShouldNotBeNull();
            yearInputClassNameField.FieldType.ShouldBe(typeof(string));
        }

        [TestCaseSource(nameof(DateInputViewCalculationsModelInitialisationData))]
        public void DateInputViewCalculationsModelHasCorrectInitialisedValues(DateInputViewModel sourceModel, string baseId, Dictionary<string, object> expectedValues)
        {
            // Arrange/Act
            var model = new DateInputViewCalculationsModel(sourceModel, baseId);

            //Assert
            model.containerClass.ShouldBe(expectedValues["ContainerClass"]);
            model.legendClass.ShouldBe(expectedValues["LegendClass"]);
            model.showH1.ShouldBe(expectedValues["ShowH1"]);
            model.isHint.ShouldBe(expectedValues["IsHint"]);
            model.isError.ShouldBe(expectedValues["IsError"]);
            model.describedByTag.ShouldBe(expectedValues["DescribedByTag"]);
            model.showDescribedByTag.ShouldBe(expectedValues["ShowDescribedByTag"]);
            model.dayInputClassName.ShouldBe(expectedValues["DayInputClassName"]);
            model.monthInputClassName.ShouldBe(expectedValues["MonthInputClassName"]);
            model.yearInputClassName.ShouldBe(expectedValues["YearInputClassName"]);

        }

        public static IEnumerable<TestCaseData> DateInputViewCalculationsModelInitialisationData()
        {
            yield return new TestCaseData(new DateInputViewModel(), null, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                });
            yield return new TestCaseData(new DateInputViewModel(), string.Empty, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                });
            yield return new TestCaseData(new DateInputViewModel { QuestionType = InputMultiQuestionType.Multiple }, "baseId", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "LegendClass", "govuk-fieldset__legend" },
                    { "ShowH1", false },
                    { "IsHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                });
            yield return new TestCaseData(new DateInputViewModel { Hint = "hint" }, "baseId1", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", true },
                    { "IsError", false },
                    { "DescribedByTag", "baseId1-hint" },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                });
            yield return new TestCaseData(new DateInputViewModel { Error = "error", ErrorType = DateInputErrorType.DayOnly }, "baseId2", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId2-error " },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                });
            yield return new TestCaseData(new DateInputViewModel { Error = "error", ErrorType = DateInputErrorType.MonthOnly }, "baseId3", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId3-error " },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                });
            yield return new TestCaseData(new DateInputViewModel { Error = "error", ErrorType = DateInputErrorType.YearOnly }, "baseId4", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId4-error " },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error" }
                });
            yield return new TestCaseData(new DateInputViewModel { Error = "error", ErrorType = DateInputErrorType.DayMonth }, "baseId5", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId5-error " },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                });
            yield return new TestCaseData(new DateInputViewModel { Error = "error", ErrorType = DateInputErrorType.MonthYear }, "baseId6", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId6-error " },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error" }
                });
            yield return new TestCaseData(new DateInputViewModel { Error = "error", ErrorType = DateInputErrorType.DayYear }, "baseId7", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId7-error " },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error" }
                });
            yield return new TestCaseData(new DateInputViewModel { Error = "error", ErrorType = DateInputErrorType.All }, "baseId8", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId8-error " },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error" }
                });
            yield return new TestCaseData(new DateInputViewModel { Hint = "hint", Error = "error", ErrorType = DateInputErrorType.All }, "baseId9", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", true },
                    { "IsError", true },
                    { "DescribedByTag", "baseId9-error baseId9-hint" },
                    { "ShowDescribedByTag", true },
                    { "DayInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "MonthInputClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "YearInputClassName", "govuk-input govuk-date-input__input govuk-input--width-4 govuk-input--error" }
                });
        }
    }
}
