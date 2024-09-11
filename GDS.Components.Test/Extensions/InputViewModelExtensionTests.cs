namespace GDS.Components.Test.Extensions
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class InputViewModelExtensionTests
    {
        [Test]
        public void MustInitializePostedModelIfNull()
        {
            // Arrange
            InputViewModel postedModel = null;
            var resetModel = new InputViewModel
            {
                Label = "Test Label",
                QuestionType = InputMultiQuestionType.Single,
                InputType = InputType.Email,
                Hint = "Test Hint",
                Error = "Test Error"
            };

            // Act
            var result = InputViewModelExtension.PopulateInputViewModel(postedModel, resetModel);

            // Assert
            result.ShouldNotBeNull();
            result.Label.ShouldBe("Test Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            result.InputType.ShouldBe(InputType.Email);
            result.Hint.ShouldBe("Test Hint");
            result.Error.ShouldBe("Test Error");
        }

        [Test]
        public void MustCopyPropertiesFromResetModelToPostedModel()
        {
            // Arrange
            var postedModel = new InputViewModel
            {
                QuestionType = InputMultiQuestionType.Single,
                InputType = InputType.Email,
            };
            var resetModel = new InputViewModel
            {
                Label = "Updated Label",
                QuestionType = InputMultiQuestionType.Multiple,
                InputType = InputType.Telephone,
                Hint = "Updated Hint",
                Error = "Updated Error"
            };

            // Act
            var result = InputViewModelExtension.PopulateInputViewModel(postedModel, resetModel);

            // Assert
            result.Label.ShouldBe("Updated Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            result.InputType.ShouldBe(InputType.Telephone);
            result.Hint.ShouldBe("Updated Hint");
            result.Error.ShouldBe("Updated Error");
        }

        [Test]
        public void MustOverwritePostedModelPropertiesWithResetModelValues()
        {
            // Arrange
            var postedModel = new InputViewModel
            {
                Label = "Original Label",
                QuestionType = InputMultiQuestionType.Single,
                InputType = InputType.Email,
                Hint = "Original Hint",
                Error = "Original Error"
            };

            var resetModel = new InputViewModel
            {
                Label = "New Label",
                QuestionType = InputMultiQuestionType.Multiple,
                InputType = InputType.Number,
                Hint = "New Hint",
                Error = "New Error"
            };

            // Act
            var result = InputViewModelExtension.PopulateInputViewModel(postedModel, resetModel);

            // Assert
            result.Label.ShouldBe("New Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            result.InputType.ShouldBe(InputType.Number);
            result.Hint.ShouldBe("New Hint");
            result.Error.ShouldBe("New Error");
        }        
    }
}
