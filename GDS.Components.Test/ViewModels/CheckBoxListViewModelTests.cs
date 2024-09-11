namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class CheckBoxListViewModelTests
    {
        [Test]
        public void CheckBoxListViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.CheckBoxListViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(6);
        }

        [Test]
        public void CheckBoxListViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.CheckBoxListViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var legendProperty = model.GetProperty("Legend");
            legendProperty.ShouldNotBeNull();
            legendProperty.PropertyType.ShouldBe(typeof(string));

            var checkBoxesProperty = model.GetProperty("CheckBoxes");
            checkBoxesProperty.ShouldNotBeNull();
            checkBoxesProperty.PropertyType.Name.ShouldBe("IList`1");
            checkBoxesProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("CheckBoxViewModel");

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
        }

        [Test]
        public void CheckBoxListViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new CheckBoxListViewModel();

            //Assert
            model.Legend.ShouldBeNull();
            model.CheckBoxes.ShouldNotBeNull();
            model.CheckBoxes.Count().ShouldBe(0);
            model.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            model.Hint.ShouldBeNull();
            model.Error.ShouldBeNull();
            model.Compact.ShouldBeFalse();
        }

        [Test]
        public void CheckBoxListViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new CheckBoxListViewModel();

            //Act
            model.Legend = "Legend";
            model.CheckBoxes = new List<CheckBoxViewModel> { new () { Id = "Id", Name = "Name", Value = "value", Checked = true, Text = "text", Hint = "Hint", CheckBoxType = CheckBoxType.CheckBox, Exclusive = true } };
            model.QuestionType = InputMultiQuestionType.Multiple;
            model.Hint = "hint";
            model.Error = "error";
            model.Compact = true;

            //Assert
            model.Legend.ShouldBe("Legend");
            model.CheckBoxes.ShouldNotBeNull();
            model.CheckBoxes.Count().ShouldBe(1);
            model.Hint.ShouldBe("hint");
            model.Error.ShouldBe("error");
            model.Compact.ShouldBeTrue();
        }

        [TestCaseSource(nameof(CheckBoxValueData))]
        public void GetValuesReturnsCorrectValues(IList<CheckBoxViewModel> checkBoxes, IList<string> expectedValues)
        {
            //Arrange
            var model = new CheckBoxListViewModel
            {
                Legend = "Legend",
                CheckBoxes = checkBoxes
            };

            //Act/Assert
            model.GetValues().ShouldBe(expectedValues);
        }

        [TestCaseSource(nameof(CheckBoxDisplayData))]
        public void GetDisplayValuesReturnsCorrectValues(IList<CheckBoxViewModel> checkBoxes, IList<string> expectedValues)
        {
            //Arrange
            var model = new CheckBoxListViewModel
            {
                Legend = "Legend",
                CheckBoxes = checkBoxes
            };

            //Act/Assert
            model.GetDisplayValues().ShouldBe(expectedValues);
        }

        public static IEnumerable<TestCaseData> CheckBoxValueData()
        {
            yield return new TestCaseData(new List<CheckBoxViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1" }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2" } }, new List<string>());
            yield return new TestCaseData(new List<CheckBoxViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1", Checked = true }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2" } }, new List<string> { "value1" });
            yield return new TestCaseData(new List<CheckBoxViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1" }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2", Checked = true } }, new List<string> { "value2" });
            yield return new TestCaseData(new List<CheckBoxViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1", Checked = true }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2", Checked = true } }, new List<string> { "value1", "value2" });
        }

        public static IEnumerable<TestCaseData> CheckBoxDisplayData()
        {
            yield return new TestCaseData(new List<CheckBoxViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1" }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2" } }, new List<string>());
            yield return new TestCaseData(new List<CheckBoxViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1", Checked = true }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2" } }, new List<string> { "text1" });
            yield return new TestCaseData(new List<CheckBoxViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1" }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2", Checked = true } }, new List<string> { "text2" });
            yield return new TestCaseData(new List<CheckBoxViewModel> { new() { Id = "Id1", Name = "Name1", Value = "value1", Text = "text1", Checked = true }, new() { Id = "Id2", Name = "Name2", Value = "value2", Text = "text2", Checked = true } }, new List<string> { "text1", "text2" });
        }
    }
}
