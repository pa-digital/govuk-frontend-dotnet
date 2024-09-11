namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Newtonsoft.Json;
    using Shouldly;
    using System.Text.Json.Nodes;

    [TestFixture]
    public class SelectViewModelTests
    {
        [Test]
        public void SelectViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.SelectViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(6);
        }

        [Test]
        public void SelectViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.SelectViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var labelProperty = model.GetProperty("Label");
            labelProperty.ShouldNotBeNull();
            labelProperty.PropertyType.ShouldBe(typeof(string));

            var questionTypeProperty = model.GetProperty("QuestionType");
            questionTypeProperty.ShouldNotBeNull();
            questionTypeProperty.PropertyType.ShouldBe(typeof(InputMultiQuestionType));

            var optionsProperty = model.GetProperty("Options");
            optionsProperty.ShouldNotBeNull();
            optionsProperty.PropertyType.Name.ShouldBe("IList`1");
            optionsProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("OptionModel");

            var hintProperty = model.GetProperty("Hint");
            hintProperty.ShouldNotBeNull();
            hintProperty.PropertyType.ShouldBe(typeof(string));

            var errorProperty = model.GetProperty("Error");
            errorProperty.ShouldNotBeNull();
            errorProperty.PropertyType.ShouldBe(typeof(string));

            var valueProperty = model.GetProperty("Value");
            valueProperty.ShouldNotBeNull();
            valueProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void SelectViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new SelectViewModel();

            //Assert
            model.Label.ShouldBeNull();
            model.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            model.Options.ShouldNotBeNull();
            model.Options.Count().ShouldBe(0);
            model.Hint.ShouldBeNull();
            model.Error.ShouldBeNull();
            model.Value.ShouldBeNull();
        }

        [Test]
        public void SelectViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new SelectViewModel();

            //Act
            model.Label = "Label";
            model.Options = new List<OptionModel> { new() { Value = "Value", Text = "Text" } };
            model.QuestionType = InputMultiQuestionType.Multiple;
            model.Hint = "hint";
            model.Error = "error";
            model.Value = "Value";

            //Assert
            model.Label.ShouldBe("Label");
            model.Options.ShouldNotBeNull();
            model.Options.Count().ShouldBe(1);
            model.Hint.ShouldBe("hint");
            model.Error.ShouldBe("error");
            model.Value.ShouldBe("Value");
        }

        [TestCaseSource(nameof(SelectViewModelValueData))]
        public void GetValueReturnsCorrectValues(IList<OptionModel>? options, string? value, string expectedValue)
        {
            //Arrange
            var model = new SelectViewModel
            {
                Label = "Label",
                Options = options,
                Value = value
            };

            //Act/Assert
            model.GetValue().ShouldBe(expectedValue);
        }

        [TestCaseSource(nameof(SelectViewModelDisplayData))]
        public void GetDisplayValuesReturnsCorrectValues(IList<OptionModel>? options, string? value, string expectedValue)
        {
            //Arrange
            var model = new SelectViewModel
            {
                Label = "Label",
                Options = options,
                Value = value
            };

            Console.WriteLine($"Options: {JsonConvert.SerializeObject(options)}, Value: {value}, Expected {expectedValue}.");

            //Act/Assert
            model.GetDisplayValue().ShouldBe(expectedValue);
        }

        public static IEnumerable<TestCaseData> SelectViewModelValueData()
        {
            yield return new TestCaseData(null, null, null);
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1" }, new() { Value = "value2", Text = "text2" } }, string.Empty, string.Empty);
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1" }, new() { Value = "value2", Text = "text2" } }, "value2", "value2");
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1", Selected = true }, new() { Value = "value2", Text = "text2" } }, null, "value1");
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1" }, new() { Value = "value2", Text = "text2", Selected = true } }, null, "value2");
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1", Selected = true }, new() { Value = "value2", Text = "text2", Selected = true } }, null, "value1");
        }

        public static IEnumerable<TestCaseData> SelectViewModelDisplayData()
        {
            yield return new TestCaseData(null, null, string.Empty);
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1" }, new() { Value = "value2", Text = "text2" } }, null, string.Empty);
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1" }, new() { Value = "value2", Text = "text2" } }, string.Empty, string.Empty);
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1", Selected = true }, new() { Value = "value2", Text = "text2" } }, null, "text1");
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1" }, new() { Value = "value2", Text = "text2", Selected = true } }, null, "text2");
            yield return new TestCaseData(new List<OptionModel> { new() { Value = "value1", Text = "text1", Selected = true }, new() { Value = "value2", Text = "text2", Selected = true } }, null, "text1");
        }
    }
}
