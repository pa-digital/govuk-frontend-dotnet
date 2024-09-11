namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using Shouldly;

    internal class InputViewModelTests
    {
        [Test]
        public void InputViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.InputViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(6);
        }

        [Test]
        public void InputViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.InputViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var labelProperty = model.GetProperty("Label");
            labelProperty.ShouldNotBeNull();
            labelProperty.PropertyType.ShouldBe(typeof(string));

            var questionTypeProperty = model.GetProperty("QuestionType");
            questionTypeProperty.ShouldNotBeNull();
            questionTypeProperty.PropertyType.ShouldBe(typeof(InputMultiQuestionType));

            var inputTypeProperty = model.GetProperty("InputType");
            inputTypeProperty.ShouldNotBeNull();
            inputTypeProperty.PropertyType.ShouldBe(typeof(InputType));

            var hintProperty = model.GetProperty("Hint");
            hintProperty.ShouldNotBeNull();
            hintProperty.PropertyType.ShouldBe(typeof(string));

            var valueProperty = model.GetProperty("Value");
            valueProperty.ShouldNotBeNull();
            valueProperty.PropertyType.ShouldBe(typeof(string));

            var errorProperty = model.GetProperty("Error");
            errorProperty.ShouldNotBeNull();
            errorProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void InputViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new InputViewModel();

            //Assert
            model.Label.ShouldBeNull();
            model.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            model.InputType.ShouldBe(InputType.Text);
            model.Hint.ShouldBeNull();
            model.Value.ShouldBeNull();
            model.Error.ShouldBeNull();
        }

        [Test]
        public void InputViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new InputViewModel();

            //Act
            model.Label = "Label";
            model.QuestionType = InputMultiQuestionType.Multiple;
            model.InputType = InputType.Email;
            model.Hint = "Hint";
            model.Value = "Value";
            model.Error = "Error";

            //Assert
            model.Label.ShouldBe("Label");
            model.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            model.InputType.ShouldBe(InputType.Email);
            model.Hint.ShouldBe("Hint");
            model.Value.ShouldBe("Value");
            model.Error.ShouldBe("Error");
        }

        [TestCaseSource(nameof(InputViewModelValueData))]
        public void GetValueMustReturnCorrectValue(string? inputValue, string expectedValue)
        {
            //Arrange
            var model = new InputViewModel { Value = inputValue };

            //Act/Assert
            model.GetValue().ShouldBe(expectedValue);
        }

        public static IEnumerable<TestCaseData> InputViewModelValueData()
        {
            yield return new TestCaseData(null, string.Empty);
            yield return new TestCaseData(string.Empty, string.Empty);
            yield return new TestCaseData("value", "value");
        }
    }
}
