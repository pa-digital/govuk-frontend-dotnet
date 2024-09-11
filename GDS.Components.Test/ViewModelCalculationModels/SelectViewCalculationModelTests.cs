namespace GDS.Components.Test.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModelCalculationModels;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class SelectViewCalculationModelTests
    {
        [Test]
        public void SelectViewCalculationModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.SelectViewCalculationModel, GDS.Components");

            // Assert
            model.ShouldNotBeNull();
            model.GetFields().Length.ShouldBe(9);
        }

        [Test]
        public void SelectViewCalculationModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.SelectViewCalculationModel, GDS.Components");

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

            var ariaDescribedByField = model.GetField("ariaDescribedBy");
            ariaDescribedByField.ShouldNotBeNull();
            ariaDescribedByField.FieldType.ShouldBe(typeof(string));

            var showDescribedByTagField = model.GetField("showDescribedByTag");
            showDescribedByTagField.ShouldNotBeNull();
            showDescribedByTagField.FieldType.ShouldBe(typeof(bool));
        }

        [TestCaseSource(nameof(SelectViewCalculationModelInitialisationData))]
        public void SelectViewCalculationModelHasCorrectInitialisedValues(SelectViewModel sourceModel, string baseId, Dictionary<string, object> expectedValues)
        {
            // Arrange/Act
            var model = new SelectViewCalculationModel(sourceModel, baseId);

            //Assert
            model.containerClass.ShouldBe(expectedValues["ContainerClass"]);
            model.elementClass.ShouldBe(expectedValues["ElementClass"]);
            model.labelClass.ShouldBe(expectedValues["LabelClass"]);
            model.showH1.ShouldBe(expectedValues["ShowH1"]);
            model.hasHint.ShouldBe(expectedValues["HasHint"]);
            model.isError.ShouldBe(expectedValues["IsError"]);
            model.ariaDescribedBy.ShouldBe(expectedValues["AriaDescribedBy"]);
            model.showDescribedByTag.ShouldBe(expectedValues["ShowDescribedByTag"]);

        }

        public static IEnumerable<TestCaseData> SelectViewCalculationModelInitialisationData()
        {
            yield return new TestCaseData(new SelectViewModel(), null, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-select" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "AriaDescribedBy", string.Empty },
                    { "ShowDescribedByTag", false }
                });
            yield return new TestCaseData(new SelectViewModel(), string.Empty, new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-select" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", false },
                    { "AriaDescribedBy", string.Empty },
                    { "ShowDescribedByTag", false }
                });
            yield return new TestCaseData(new SelectViewModel { QuestionType = InputMultiQuestionType.Multiple }, "baseId", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-select" },
                    { "LabelClass", "govuk-label" },
                    { "ShowH1", false },
                    { "HasHint", false },
                    { "IsError", false },
                    { "AriaDescribedBy", string.Empty },
                    { "ShowDescribedByTag", false }
                });
            yield return new TestCaseData(new SelectViewModel { Hint = "hint" }, "baseId1", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group" },
                    { "ElementClass", "govuk-select" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", true },
                    { "IsError", false },
                    { "AriaDescribedBy", "baseId1-hint" },
                    { "ShowDescribedByTag", true }
                });
            yield return new TestCaseData(new SelectViewModel { Error = "error" }, "baseId2", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "ElementClass", "govuk-select govuk-input--error" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", false },
                    { "IsError", true },
                    { "AriaDescribedBy", "baseId2-error " },
                    { "ShowDescribedByTag", true }
                });
            yield return new TestCaseData(new SelectViewModel { Hint = "hint", Error = "error" }, "baseId9", new Dictionary<string, object>{
                    { "ContainerClass", "govuk-form-group govuk-form-group--error" },
                    { "ElementClass", "govuk-select govuk-input--error" },
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "ShowH1", true },
                    { "HasHint", true },
                    { "IsError", true },
                    { "AriaDescribedBy", "baseId9-error baseId9-hint" },
                    { "ShowDescribedByTag", true }
                });
        }
    }
}
