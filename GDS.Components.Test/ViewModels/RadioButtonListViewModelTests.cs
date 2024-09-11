namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class RadioButtonListViewModelTests
    {
        [Test]
        public void RadioButtonListViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.RadioButtonListViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(8);
        }

        [Test]
        public void RadioButtonListViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.RadioButtonListViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var legendProperty = model.GetProperty("Legend");
            legendProperty.ShouldNotBeNull();
            legendProperty.PropertyType.ShouldBe(typeof(string));

            var selectedValueProperty = model.GetProperty("SelectedValue");
            selectedValueProperty.ShouldNotBeNull();
            selectedValueProperty.PropertyType.ShouldBe(typeof(string));

            var checkBoxesProperty = model.GetProperty("RadioButtons");
            checkBoxesProperty.ShouldNotBeNull();
            checkBoxesProperty.PropertyType.Name.ShouldBe("IList`1");
            checkBoxesProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("RadioButtonViewModel");

            var questionTypeProperty = model.GetProperty("QuestionType");
            questionTypeProperty.ShouldNotBeNull();
            questionTypeProperty.PropertyType.ShouldBe(typeof(InputMultiQuestionType));

            var hintProperty = model.GetProperty("Hint");
            hintProperty.ShouldNotBeNull();
            hintProperty.PropertyType.ShouldBe(typeof(string));

            var errorProperty = model.GetProperty("Error");
            errorProperty.ShouldNotBeNull();
            errorProperty.PropertyType.ShouldBe(typeof(string));

            var compactProperty = model.GetProperty("Compact");
            compactProperty.ShouldNotBeNull();
            compactProperty.PropertyType.ShouldBe(typeof(bool));

            var inlineProperty = model.GetProperty("Inline");
            inlineProperty.ShouldNotBeNull();
            inlineProperty.PropertyType.ShouldBe(typeof(bool));
        }

        [Test]
        public void RadioButtonListViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new RadioButtonListViewModel();

            //Assert
            model.Legend.ShouldBeNull();
            model.RadioButtons.ShouldNotBeNull();
            model.RadioButtons.Count().ShouldBe(0);
            model.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            model.Hint.ShouldBeNull();
            model.Error.ShouldBeNull();
            model.Compact.ShouldBeFalse();
            model.Inline.ShouldBeFalse();
        }

        [Test]
        public void RadioButtonListViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new RadioButtonListViewModel();

            //Act
            model.Legend = "Legend";
            model.RadioButtons = new List<RadioButtonViewModel> { new() { Id = "Id", Name = "Name", Value = "value", Checked = true, Text = "text", Hint = "Hint", RadioButtonType = RadioButtonType.RadioButton } };
            model.QuestionType = InputMultiQuestionType.Multiple;
            model.Hint = "hint";
            model.Error = "error";
            model.Compact = true;

            //Assert
            model.Legend.ShouldBe("Legend");
            model.RadioButtons.ShouldNotBeNull();
            model.RadioButtons.Count().ShouldBe(1);
            model.Hint.ShouldBe("hint");
            model.Error.ShouldBe("error");
            model.Compact.ShouldBeTrue();
        }

        [TestCaseSource(nameof(RadioButtonListViewModelValueData))]
        public void GetValueReturnsCorrectValues(IList<RadioButtonViewModel> radioButtons, string expectedValue)
        {
            //Arrange
            var model = new RadioButtonListViewModel
            {
                Legend = "Legend",
                RadioButtons = radioButtons
            };

            //Act/Assert
            model.GetValue().ShouldBe(expectedValue);
        }

        [TestCaseSource(nameof(RadioButtonListViewModelDisplayData))]
        public void GetDisplayValuesReturnsCorrectValues(IList<RadioButtonViewModel> radioButtons, string expectedValue)
        {
            //Arrange
            var model = new RadioButtonListViewModel
            {
                Legend = "Legend",
                RadioButtons = radioButtons
            };

            //Act/Assert
            model.GetDisplayValue().ShouldBe(expectedValue);
        }

        public static IEnumerable<TestCaseData> RadioButtonListViewModelValueData()
        {
            yield return new TestCaseData(new List<RadioButtonViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1"}, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2" } }, string.Empty);
            yield return new TestCaseData(new List<RadioButtonViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1", Checked = true }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2" } },  "value1" );
            yield return new TestCaseData(new List<RadioButtonViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1" }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2", Checked = true } },  "value2" );
            yield return new TestCaseData(new List<RadioButtonViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1", Checked = true }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2", Checked = true } }, "value1");
        }

        public static IEnumerable<TestCaseData> RadioButtonListViewModelDisplayData()
        {
            yield return new TestCaseData(new List<RadioButtonViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1" }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2" } }, string.Empty);
            yield return new TestCaseData(new List<RadioButtonViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1", Checked = true }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2" } }, "text1");
            yield return new TestCaseData(new List<RadioButtonViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1" }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2", Checked = true } }, "text2");
            yield return new TestCaseData(new List<RadioButtonViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1", Checked = true }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2", Checked = true } }, "text1");
        }
    }
}
