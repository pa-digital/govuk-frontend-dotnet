namespace GDS.Components.Test.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModelCalculationModels;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.Collections.Generic;

    [TestFixture]
    public class CheckBoxListViewCalculationsModelTests
    {
        [Test]
        public void CheckBoxListViewCalculationsModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.CheckBoxListViewCalculationsModel, GDS.Components");

            // Assert
            model.ShouldNotBeNull();
            model.GetFields().Length.ShouldBe(8);
        }

        [Test]
        public void CheckBoxListViewCalculationsModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.CheckBoxListViewCalculationsModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var containerClassField = model.GetField("containerClass");
            containerClassField.ShouldNotBeNull();
            containerClassField.FieldType.ShouldBe(typeof(string));

            var checkBoxGroupClassField = model.GetField("checkBoxGroupClass");
            checkBoxGroupClassField.ShouldNotBeNull();
            checkBoxGroupClassField.FieldType.ShouldBe(typeof(string));

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
        }

        [TestCaseSource(nameof(CheckBoxListViewCalculationsModelInitialisationData))]
        public void CheckBoxListViewCalculationsModelHasCorrectInitialisedValues(CheckBoxListViewModel sourceModel, string baseId, Dictionary<string, object> expectedValues)
        {
            // Arrange/Act
            var model = new CheckBoxListViewCalculationsModel(sourceModel, baseId);

            //Assert
            model.containerClass.ShouldBe(expectedValues["ContainerClass"]);
            model.checkBoxGroupClass.ShouldBe(expectedValues["CheckBoxGroupClass"]);
            model.legendClass.ShouldBe(expectedValues["LegendClass"]);
            model.showH1.ShouldBe(expectedValues["ShowH1"]);
            model.isHint.ShouldBe(expectedValues["IsHint"]);
            model.isError.ShouldBe(expectedValues["IsError"]);
            model.describedByTag.ShouldBe(expectedValues["DescribedByTag"]);
            model.showDescribedByTag.ShouldBe(expectedValues["ShowDescribedByTag"]);
        }

        public static IEnumerable<TestCaseData> CheckBoxListViewCalculationsModelInitialisationData()
        {
            yield return new TestCaseData(new CheckBoxListViewModel(), null, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "CheckBoxGroupClass", "govuk-checkboxes" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new CheckBoxListViewModel(), string.Empty, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "CheckBoxGroupClass", "govuk-checkboxes" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new CheckBoxListViewModel { QuestionType = InputMultiQuestionType.Multiple}, "baseId1", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "CheckBoxGroupClass", "govuk-checkboxes" },
                    { "LegendClass", "govuk-fieldset__legend" },
                    { "ShowH1", false },
                    { "IsHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new CheckBoxListViewModel { Compact = true }, "baseId2", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "CheckBoxGroupClass", "govuk-checkboxes govuk-checkboxes--small" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new CheckBoxListViewModel { Hint = "hint" }, "baseId3", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "CheckBoxGroupClass", "govuk-checkboxes" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", true },
                    { "IsError", false },
                    { "DescribedByTag", "baseId3-hint" },
                    { "ShowDescribedByTag", true },
                });
            yield return new TestCaseData(new CheckBoxListViewModel { Error = "error" }, "baseId4", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "CheckBoxGroupClass", "govuk-checkboxes" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId4-error " },
                    { "ShowDescribedByTag", true },
                });
            yield return new TestCaseData(new CheckBoxListViewModel { Hint = "hint", Error = "error" }, "baseId5", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "CheckBoxGroupClass", "govuk-checkboxes" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "IsHint", true },
                    { "IsError", true },
                    { "DescribedByTag", "baseId5-error baseId5-hint" },
                    { "ShowDescribedByTag", true },
                });
        }
    }
}
