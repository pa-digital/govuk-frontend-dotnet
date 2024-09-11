using GDS.Components.Enum;
using GDS.Components.ViewModelCalculationModels;
using GDS.Components.ViewModels;
using Shouldly;

namespace GDS.Components.Test.ViewModelCalculationModels
{
    [TestFixture]
    public class RadioButtonListViewCalculationModelTests
    {
        [Test]
        public void RadioButtonListViewCalculationModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.RadioButtonListViewCalculationModel, GDS.Components");

            // Assert
            model.ShouldNotBeNull();
            model.GetFields().Length.ShouldBe(8);
        }

        [Test]
        public void RadioButtonListViewCalculationModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.RadioButtonListViewCalculationModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var containerClassField = model.GetField("containerClass");
            containerClassField.ShouldNotBeNull();
            containerClassField.FieldType.ShouldBe(typeof(string));

            var radioButtonGroupClassField = model.GetField("radioButtonGroupClass");
            radioButtonGroupClassField.ShouldNotBeNull();
            radioButtonGroupClassField.FieldType.ShouldBe(typeof(string));

            var legendClassField = model.GetField("legendClass");
            legendClassField.ShouldNotBeNull();
            legendClassField.FieldType.ShouldBe(typeof(string));

            var showH1Field = model.GetField("showH1");
            showH1Field.ShouldNotBeNull();
            showH1Field.FieldType.ShouldBe(typeof(bool));

            var hasHintField = model.GetField("hasHint");
            hasHintField.ShouldNotBeNull();
            hasHintField.FieldType.ShouldBe(typeof(bool));

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

        [TestCaseSource(nameof(RadioButtonListViewCalculationModelInitialisationData))]
        public void RadioButtonListViewCalculationModelHasCorrectInitialisedValues(RadioButtonListViewModel sourceModel, string baseId, Dictionary<string, object> expectedValues)
        {
            // Arrange/Act
            var model = new RadioButtonListViewCalculationModel(sourceModel, baseId);

            //Assert
            model.containerClass.ShouldBe(expectedValues["ContainerClass"]);
            model.radioButtonGroupClass.ShouldBe(expectedValues["RadioButtonGroupClass"]);
            model.legendClass.ShouldBe(expectedValues["LegendClass"]);
            model.showH1.ShouldBe(expectedValues["ShowH1"]);
            model.hasHint.ShouldBe(expectedValues["HasHint"]);
            model.isError.ShouldBe(expectedValues["IsError"]);
            model.describedByTag.ShouldBe(expectedValues["DescribedByTag"]);
            model.showDescribedByTag.ShouldBe(expectedValues["ShowDescribedByTag"]);
        }

        public static IEnumerable<TestCaseData> RadioButtonListViewCalculationModelInitialisationData()
        {
            yield return new TestCaseData(new RadioButtonListViewModel(), null, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "RadioButtonGroupClass", "govuk-radios" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new RadioButtonListViewModel(), string.Empty, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "RadioButtonGroupClass", "govuk-radios" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new RadioButtonListViewModel { QuestionType = InputMultiQuestionType.Multiple }, "baseId1", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "RadioButtonGroupClass", "govuk-radios" },
                    { "LegendClass", "govuk-fieldset__legend" },
                    { "ShowH1", false },
                    { "HasHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new RadioButtonListViewModel { Compact = true }, "baseId2", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "RadioButtonGroupClass", "govuk-radios govuk-radios--small" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new RadioButtonListViewModel { Inline = true }, "baseId3", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "RadioButtonGroupClass", "govuk-radios govuk-radios--inline" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "DescribedByTag", null },
                    { "ShowDescribedByTag", false },
                });
            yield return new TestCaseData(new RadioButtonListViewModel { Hint = "hint" }, "baseId4", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "RadioButtonGroupClass", "govuk-radios" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "HasHint", true },
                    { "IsError", false },
                    { "DescribedByTag", "baseId4-hint" },
                    { "ShowDescribedByTag", true },
                });
            yield return new TestCaseData(new RadioButtonListViewModel { Error = "error" }, "baseId5", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "RadioButtonGroupClass", "govuk-radios" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", true },
                    { "DescribedByTag", "baseId5-error " },
                    { "ShowDescribedByTag", true },
                });
            yield return new TestCaseData(new RadioButtonListViewModel { Hint = "hint", Error = "error" }, "baseId6", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "RadioButtonGroupClass", "govuk-radios" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "ShowH1", true },
                    { "HasHint", true },
                    { "IsError", true },
                    { "DescribedByTag", "baseId6-error baseId6-hint" },
                    { "ShowDescribedByTag", true },
                });
        }
    }
}
