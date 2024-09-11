namespace GDS.Components.Test.Extensions
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class PasswordViewModelExtenstionTests
    {
        [Test]
        public void MustInitializePostedModelIfNull()
        {
            // Arrange
            PasswordViewModel postedModel = null;
            var resetModel = new PasswordViewModel
            {
                Label = "Test Label",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "Test Hint",
                Error = "Test Error"
            };

            // Act
            var result = PasswordViewModelExtenstion.PopulatePasswordViewModel(postedModel, resetModel);

            // Assert
            result.ShouldNotBeNull();
            result.Label.ShouldBe("Test Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            result.Hint.ShouldBe("Test Hint");
            result.Error.ShouldBe("Test Error");
        }

        [Test]
        public void MustCopyPropertiesFromResetModelToPostedModel()
        {
            // Arrange
            var postedModel = new PasswordViewModel
            {
                QuestionType = InputMultiQuestionType.Single,
            };
            var resetModel = new PasswordViewModel
            {
                Label = "Updated Label",
                QuestionType = InputMultiQuestionType.Multiple,
                Hint = "Updated Hint",
                Error = "Updated Error"
            };

            // Act
            var result = PasswordViewModelExtenstion.PopulatePasswordViewModel(postedModel, resetModel);

            // Assert
            result.Label.ShouldBe("Updated Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            result.Hint.ShouldBe("Updated Hint");
            result.Error.ShouldBe("Updated Error");
        }

        [Test]
        public void MustOverwritePostedModelPropertiesWithResetModelValues()
        {
            // Arrange
            var postedModel = new PasswordViewModel
            {
                Label = "Original Label",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "Original Hint",
                Error = "Original Error"
            };

            var resetModel = new PasswordViewModel
            {
                Label = "New Label",
                QuestionType = InputMultiQuestionType.Multiple,
                Hint = "New Hint",
                Error = "New Error"
            };

            // Act
            var result = PasswordViewModelExtenstion.PopulatePasswordViewModel(postedModel, resetModel);

            // Assert
            result.Label.ShouldBe("New Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            result.Hint.ShouldBe("New Hint");
            result.Error.ShouldBe("New Error");
        }
    }
 }
