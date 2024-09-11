namespace GDS.Components.Test.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModelCalculationModels;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class PasswordViewCalculationsModelTests
    {
        [Test]
        public void PasswordViewCalculationsModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.PasswordViewCalculationsModel, GDS.Components");

            // Assert
            model.ShouldNotBeNull();
            model.GetFields().Length.ShouldBe(6);
        }

        [Test]
        public void PasswordViewCalculationsModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.PasswordViewCalculationsModel, GDS.Components");

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

            var hasHintField = model.GetField("hasHint");
            hasHintField.ShouldNotBeNull();
            hasHintField.FieldType.ShouldBe(typeof(bool));

            var isErrorField = model.GetField("isError");
            isErrorField.ShouldNotBeNull();
            isErrorField.FieldType.ShouldBe(typeof(bool));
        }

        [TestCaseSource(nameof(PasswordViewCalculationsModelInitialisationData))]
        public void PasswordViewCalculationsModelHasCorrectInitialisedValues(PasswordViewModel sourceModel, Dictionary<string, object> expectedValues)
        {
            // Arrange/Act
            var model = new PasswordViewCalculationsModel(sourceModel);

            //Assert
            model.containerClass.ShouldBe(expectedValues["ContainerClass"]);
            model.elementClass.ShouldBe(expectedValues["ElementClass"]);
            model.labelClass.ShouldBe(expectedValues["LabelClass"]);
            model.showH1.ShouldBe(expectedValues["ShowH1"]);
            model.hasHint.ShouldBe(expectedValues["HasHint"]);
            model.isError.ShouldBe(expectedValues["IsError"]);

        }

        public static IEnumerable<TestCaseData> PasswordViewCalculationsModelInitialisationData()
        {
            yield return new TestCaseData(new PasswordViewModel(), new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-password-input" },
                    { "ElementClass", "govuk-input govuk-password-input__input govuk-js-password-input-input" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false }
                });
            yield return new TestCaseData(new PasswordViewModel { QuestionType = InputMultiQuestionType.Multiple }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-password-input" },
                    { "ElementClass", "govuk-input govuk-password-input__input govuk-js-password-input-input" },
                    { "LabelClass", "govuk-label" },
                    { "ShowH1", false },
                    { "HasHint", false },
                    { "IsError", false }
                });
            yield return new TestCaseData(new PasswordViewModel { Hint = "hint" }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-password-input" },
                    { "ElementClass", "govuk-input govuk-password-input__input govuk-js-password-input-input" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", true },
                    { "IsError", false }
                });
            yield return new TestCaseData(new PasswordViewModel { Error = "error" }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-password-input govuk-form-group--error" },
                    { "ElementClass", "govuk-input govuk-password-input__input govuk-js-password-input-input govuk-input--error" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", true }
                });
            yield return new TestCaseData(new PasswordViewModel { Hint = "hint", Error = "error" }, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-password-input govuk-form-group--error" },
                    { "ElementClass", "govuk-input govuk-password-input__input govuk-js-password-input-input govuk-input--error" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", true },
                    { "IsError", true }
                });
        }
    }
}
