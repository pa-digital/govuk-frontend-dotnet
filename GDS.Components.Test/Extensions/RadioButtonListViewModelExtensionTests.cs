namespace GDS.Components.Test.Extensions
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class RadioButtonListViewModelExtensionTests
    {
        private TestRadioButtonListPopulationModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new TestRadioButtonListPopulationModel();
        }

        [Test]
        public void MustInitializePostedModelIfNull()
        {
            // Arrange
            RadioButtonListViewModel postedModel = null;
            var resetModel = new RadioButtonListViewModel
            {
                Legend = "Test Legend",
                RadioButtons = new List<RadioButtonViewModel>
                {
                    new() { Text = "Radio Button 1", Value = "1" },
                    new() { Text = "Radio Button 2", Value = "2" }
                }
            };

            // Act
            _model.RadioButtonList = RadioButtonListViewModelExtension.PopulateRadioButtonListViewModel(postedModel, resetModel);

            // Assert
            _model.RadioButtonList.ShouldNotBeNull();
            _model.RadioButtonList.Legend.ShouldBe("Test Legend");
            _model.RadioButtonList.RadioButtons.Count.ShouldBe(2);
        }

        [Test]
        public void MustCopyPropertiesFromResetModel()
        {
            // Arrange
            var postedModel = new RadioButtonListViewModel();
            var resetModel = new RadioButtonListViewModel
            {
                Legend = "New Legend",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "This is a hint",
                Compact = true,
                Inline = true,
                Error = "This is an error",
                RadioButtons = new List<RadioButtonViewModel>
            {
                new() { Text = "Radio Button 1", Value = "1", Hint = "Hint 1", Id = "chk1" },
                new() { Text = "Radio Button 2", Value = "2", Hint = "Hint 2", Id = "chk2" }
            }
            };

            // Act
            _model.RadioButtonList = RadioButtonListViewModelExtension.PopulateRadioButtonListViewModel(postedModel, resetModel);

            // Assert
            _model.RadioButtonList.Legend.ShouldBe("New Legend");
            _model.RadioButtonList.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            _model.RadioButtonList.Hint.ShouldBe("This is a hint");
            _model.RadioButtonList.Error.ShouldBe("This is an error");
            _model.RadioButtonList.Compact.ShouldBeTrue();
            _model.RadioButtonList.Inline.ShouldBeTrue();
        }

        [Test]
        public void MustCopyCheckBoxProperties()
        {
            // Arrange
            var postedModel = new RadioButtonListViewModel
            {
                SelectedValue = "2",
                RadioButtons = new List<RadioButtonViewModel>
                {
                    new() { Text = "New Text 1", Value = "1", Hint = "New Hint 1", Id = "NewId1" },
                    new() { Text = "New Text 2", Value = "2", Hint = "New Hint 2", Id = "NewId2" }
                }
            };

            var resetModel = new RadioButtonListViewModel
            {
                RadioButtons = new List<RadioButtonViewModel>
                {
                    new() { Text = "New Text 1", Value = "1", Hint = "New Hint 1", Id = "NewId1" },
                    new() { Text = "New Text 2", Value = "2", Hint = "New Hint 2", Id = "NewId2" }
                }
            };

            // Act
            _model.RadioButtonList = RadioButtonListViewModelExtension.PopulateRadioButtonListViewModel(postedModel, resetModel);

            // Assert
            _model.RadioButtonList.RadioButtons.Count().ShouldBe(2);
            _model.RadioButtonList.RadioButtons[0].Text.ShouldBe("New Text 1");
            _model.RadioButtonList.RadioButtons[0].Value.ShouldBe("1");
            _model.RadioButtonList.RadioButtons[0].Hint.ShouldBe("New Hint 1");
            _model.RadioButtonList.RadioButtons[0].Id.ShouldBe("NewId1");

            _model.RadioButtonList.RadioButtons[1].Text.ShouldBe("New Text 2");
            _model.RadioButtonList.RadioButtons[1].Value.ShouldBe("2");
            _model.RadioButtonList.RadioButtons[1].Hint.ShouldBe("New Hint 2");
            _model.RadioButtonList.RadioButtons[1].Id.ShouldBe("NewId2");
            _model.RadioButtonList.RadioButtons[1].Checked.ShouldBeTrue();
        }         

        private class TestRadioButtonListPopulationModel
        {
            public RadioButtonListViewModel RadioButtonList { get; set; }
        }
    }
}
