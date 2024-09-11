namespace GDS.Components.Test.Extensions
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class SelectInputViewModelExtensionTests
    {
        [Test]
        public void MustInitializePostedModelIfNull()
        {
            // Arrange
            SelectViewModel postedModel = null;
            var resetModel = new SelectViewModel
            {
                Label = "Test Label",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "Test Hint",
                Options = new List<OptionModel>
                {
                    new() { Text = "Option 1", Value = "1" },
                    new() { Text = "Option 2", Value = "2" }
                }
            };

            // Act
            var result = SelectInputViewModelExtension.PopulateSelectViewModel(postedModel, resetModel);

            // Assert
            result.ShouldNotBeNull();
            result.Label.ShouldBe("Test Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            result.Hint.ShouldBe("Test Hint");
            result.Options.Count.ShouldBe(2);
            result.Options[0].Text.ShouldBe("Option 1");
            result.Options[1].Text.ShouldBe("Option 2");
        }

        [Test]
        public void MustCopyPropertiesFromResetModelToPostedModel()
        {
            // Arrange
            var postedModel = new SelectViewModel
            {
                QuestionType = InputMultiQuestionType.Single,
            };
            var resetModel = new SelectViewModel
            {
                Label = "Updated Label",
                QuestionType = InputMultiQuestionType.Multiple,
                Hint = "Updated Hint",
                Options = new List<OptionModel>
                {
                    new() { Text = "Option 1", Value = "1" },
                    new() { Text = "Option 2", Value = "2" }
                }
            };

            // Act
            var result = SelectInputViewModelExtension.PopulateSelectViewModel(postedModel, resetModel);

            // Assert
            result.Label.ShouldBe("Updated Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            result.Hint.ShouldBe("Updated Hint");
            result.Options.Count.ShouldBe(2);
            result.Options[0].Text.ShouldBe("Option 1");
            result.Options[1].Text.ShouldBe("Option 2");
        }

        [Test]
        public void MustMarkSelectedOptionCorrectly()
        {
            // Arrange
            var postedModel = new SelectViewModel
            {
                Value = "2"
            };
            var resetModel = new SelectViewModel
            {
                Label = "Test Label",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "Test Hint",
                Options = new List<OptionModel>
                {
                    new() { Text = "Option 1", Value = "1" },
                    new() { Text = "Option 2", Value = "2" }
                }
            };

            // Act
            var result = SelectInputViewModelExtension.PopulateSelectViewModel(postedModel, resetModel);

            // Assert
            result.Options[0].Selected.ShouldBeFalse();
            result.Options[1].Selected.ShouldBeTrue();
        }

        [Test]
        public void MustHandleNoMatchingOption()
        {
            // Arrange
            var postedModel = new SelectViewModel
            {
                Value = "3"
            };
            var resetModel = new SelectViewModel
            {
                Label = "Test Label",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "Test Hint",
                Options = new List<OptionModel>
                {
                    new() { Text = "Option 1", Value = "1" },
                    new() { Text = "Option 2", Value = "2" }
                }
            };

            // Act
            var result = SelectInputViewModelExtension.PopulateSelectViewModel(postedModel, resetModel);

            // Assert
            result.Options[0].Selected.ShouldBeFalse();
            result.Options[1].Selected.ShouldBeFalse();
        }

        [Test]
        public void MustHandleEmptyOptionsList()
        {
            // Arrange
            var postedModel = new SelectViewModel
            {
                Value = "1"
            };
            var resetModel = new SelectViewModel
            {
                Label = "Test Label",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "Test Hint",
                Options = new List<OptionModel>()
            };

            // Act
            var result = SelectInputViewModelExtension.PopulateSelectViewModel(postedModel, resetModel);

            // Assert
            result.Options.ShouldBeEmpty();
        }
    }
}
