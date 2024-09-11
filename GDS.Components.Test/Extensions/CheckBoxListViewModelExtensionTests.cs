namespace GDS.Components.Test.Extensions
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class CheckBoxListViewModelExtensionTests
    {
        private TestCheckBoxPopulationModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new TestCheckBoxPopulationModel();
        }

        [Test]
        public void MustInitializePostedModelIfNull()
        {
            // Arrange
            CheckBoxListViewModel postedModel = null;
            var resetModel = new CheckBoxListViewModel
            {
                Legend = "Test Legend",
                CheckBoxes = new List<CheckBoxViewModel>
                {
                    new CheckBoxViewModel { Text = "Checkbox 1", Value = "1" },
                    new CheckBoxViewModel { Text = "Checkbox 2", Value = "2" }
                }
            };

            // Act
            _model.CheckBoxList = CheckBoxListViewModelExtension.PopulateCheckBoxListViewModel(postedModel, resetModel);

            // Assert
            _model.CheckBoxList.ShouldNotBeNull();
            _model.CheckBoxList.Legend.ShouldBe("Test Legend");
            _model.CheckBoxList.CheckBoxes.Count.ShouldBe(2);
        }

        [Test]
        public void MustCopyPropertiesFromResetModel()
        {
            // Arrange
            var postedModel = new CheckBoxListViewModel();
            var resetModel = new CheckBoxListViewModel
            {
                Legend = "New Legend",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "This is a hint",
                Compact = true,
                Error = "This is an error",
                CheckBoxes = new List<CheckBoxViewModel>
            {
                new CheckBoxViewModel { Text = "Checkbox 1", Value = "1", Hint = "Hint 1", Id = "chk1" },
                new CheckBoxViewModel { Text = "Checkbox 2", Value = "2", Hint = "Hint 2", Id = "chk2" }
            }
            };

            // Act
            _model.CheckBoxList = CheckBoxListViewModelExtension.PopulateCheckBoxListViewModel(postedModel, resetModel);

            // Assert
            _model.CheckBoxList.Legend.ShouldBe("New Legend");
            _model.CheckBoxList.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            _model.CheckBoxList.Hint.ShouldBe("This is a hint");
            _model.CheckBoxList.Error.ShouldBe("This is an error");
            _model.CheckBoxList.Compact.ShouldBeTrue();
        }

        [Test]
        public void MustCopyCheckBoxProperties()
        {
            // Arrange
            var postedModel = new CheckBoxListViewModel
            {
                CheckBoxes = new List<CheckBoxViewModel>
                {
                    new CheckBoxViewModel { Text = "New Text 1", Value = "1", Hint = "New Hint 1", Id = "NewId1" },
                    new CheckBoxViewModel { Text = "New Text 2", Value = "2", Hint = "New Hint 2", Id = "NewId2", Checked = true }
                }
            };

            var resetModel = new CheckBoxListViewModel
            {
                CheckBoxes = new List<CheckBoxViewModel>
                {
                    new CheckBoxViewModel { Text = "New Text 1", Value = "1", Hint = "New Hint 1", Id = "NewId1" },
                    new CheckBoxViewModel { Text = "New Text 2", Value = "2", Hint = "New Hint 2", Id = "NewId2" }
                }
            };

            // Act
            _model.CheckBoxList = CheckBoxListViewModelExtension.PopulateCheckBoxListViewModel(postedModel, resetModel);

            // Assert
            _model.CheckBoxList.CheckBoxes.Count.ShouldBe(2);
            _model.CheckBoxList.CheckBoxes[0].Text.ShouldBe("New Text 1");
            _model.CheckBoxList.CheckBoxes[0].Value.ShouldBe("1");
            _model.CheckBoxList.CheckBoxes[0].Hint.ShouldBe("New Hint 1");
            _model.CheckBoxList.CheckBoxes[0].Id.ShouldBe("NewId1");

            _model.CheckBoxList.CheckBoxes[1].Text.ShouldBe("New Text 2");
            _model.CheckBoxList.CheckBoxes[1].Value.ShouldBe("2");
            _model.CheckBoxList.CheckBoxes[1].Hint.ShouldBe("New Hint 2");
            _model.CheckBoxList.CheckBoxes[1].Id.ShouldBe("NewId2");
            _model.CheckBoxList.CheckBoxes[1].Checked.ShouldBeTrue();
        }

        private class TestCheckBoxPopulationModel
        {
            public CheckBoxListViewModel CheckBoxList { get; set; }
        }
    }
}
