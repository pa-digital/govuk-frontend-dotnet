namespace GDS.Components.Test.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModelCalculationModels;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class InputViewCalculationsModelTests
    {
        [Test]
        public void InputViewCalculationsModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.InputViewCalculationsModel, GDS.Components");

            // Assert
            model.ShouldNotBeNull();
            model.GetFields().Length.ShouldBe(7);
        }

        [Test]
        public void InputViewCalculationsModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.InputViewCalculationsModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var containerClassField = model.GetField("containerClass");
            containerClassField.ShouldNotBeNull();
            containerClassField.FieldType.ShouldBe(typeof(string));

            var elementClassField = model.GetField("elementClass");
            elementClassField.ShouldNotBeNull();
            elementClassField.FieldType.ShouldBe(typeof(string));

            var labelClassField = model.GetField("labelClass");
            labelClassField.ShouldNotBeNull();
            labelClassField.FieldType.ShouldBe(typeof(string));

            var showH1Field = model.GetField("showH1");
            showH1Field.ShouldNotBeNull();
            showH1Field.FieldType.ShouldBe(typeof(bool));

            var inputTypeField = model.GetField("inputType");
            inputTypeField.ShouldNotBeNull();
            inputTypeField.FieldType.ShouldBe(typeof(string));

            var hasHintField = model.GetField("hasHint");
            hasHintField.ShouldNotBeNull();
            hasHintField.FieldType.ShouldBe(typeof(bool));

            var isErrorField = model.GetField("isError");
            isErrorField.ShouldNotBeNull();
            isErrorField.FieldType.ShouldBe(typeof(bool));
        }

        [TestCaseSource(nameof(InputViewCalculationsModelInitialisationData))]
        public void InputViewCalculationsModelHasCorrectInitialisedValues(InputViewModel sourceModel, Dictionary<string, object> expectedValues)
        {
            // Arrange/Act
            var model = new InputViewCalculationsModel(sourceModel);

            //Assert
            model.containerClass.ShouldBe(expectedValues["ContainerClass"]);
            model.elementClass.ShouldBe(expectedValues["ElementClass"]);
            model.labelClass.ShouldBe(expectedValues["LabelClass"]);
            model.showH1.ShouldBe(expectedValues["ShowH1"]);
            model.hasHint.ShouldBe(expectedValues["HasHint"]);
            model.isError.ShouldBe(expectedValues["IsError"]);
            model.inputType.ShouldBe(expectedValues["InputType"]);

        }

        public static IEnumerable<TestCaseData> InputViewCalculationsModelInitialisationData()
        {
            yield return new TestCaseData(new InputViewModel(), new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-input" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "InputType", "text" }
                });
            yield return new TestCaseData(new InputViewModel { InputType = InputType.Email }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-input" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "InputType", "email" }
                });
            yield return new TestCaseData(new InputViewModel { InputType = InputType.Number }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-input" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "InputType", "number" }
                });
            yield return new TestCaseData(new InputViewModel { InputType = InputType.Telephone }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-input" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "InputType", "tel" }
                });
            yield return new TestCaseData(new InputViewModel { QuestionType = InputMultiQuestionType.Multiple }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-input" },
                    { "LabelClass", "govuk-label" },
                    { "ShowH1", false },
                    { "HasHint", false },
                    { "IsError", false },
                    { "InputType", "text" }
                });
            yield return new TestCaseData(new InputViewModel { Hint = "hint" }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-input" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", true },
                    { "IsError", false },
                    { "InputType", "text" }
                });
            yield return new TestCaseData(new InputViewModel { Error = "error" }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "ElementClass", "govuk-input govuk-input--error" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", true },
                    { "InputType", "text" }
                });
            yield return new TestCaseData(new InputViewModel { Hint = "hint", Error = "error" }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "ElementClass", "govuk-input govuk-input--error" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", true },
                    { "IsError", true },
                    { "InputType", "text" }
                });
        }
    }
}
