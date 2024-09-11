namespace GDS.Components.Test.Extensions
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class DateInputViewModelExtensionTests
    {
        [Test]
        public void MustInitializePostedModelIfNull()
        {
            // Arrange
            DateInputViewModel postedModel = null;
            var resetModel = new DateInputViewModel
            {
                Legend = "Test Label",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "Test Hint",
                Error = "Test Error",
                Day = "1",
                Month = "3",
                Year = "2023"
            };

            // Act
            var result = DateInputViewModelExtension.PopulateDateInputViewModel(postedModel, resetModel);

            // Assert
            result.ShouldNotBeNull();
            result.Legend.ShouldBe("Test Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Single);
            result.Hint.ShouldBe("Test Hint");
            result.Error.ShouldBe("Test Error");
            result.Day.ShouldBeNull();
            result.Month.ShouldBeNull();
            result.Year.ShouldBeNull();
        }

        [Test]
        public void MustCopyPropertiesFromResetModelToPostedModel()
        {
            // Arrange
            var postedModel = new DateInputViewModel
            {
                QuestionType = InputMultiQuestionType.Single,
            };
            var resetModel = new DateInputViewModel
            {
                Legend = "Updated Label",
                QuestionType = InputMultiQuestionType.Multiple,
                Hint = "Updated Hint",
                Error = "Updated Error",
                Day = "1",
                Month = "3",
                Year = "2023"
            };

            // Act
            var result = DateInputViewModelExtension.PopulateDateInputViewModel(postedModel, resetModel);

            // Assert
            result.Legend.ShouldBe("Updated Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            result.Hint.ShouldBe("Updated Hint");
            result.Error.ShouldBe("Updated Error");
            result.Day = "1";
            result.Month = "3";
            result.Year = "2023";
        }

        [Test]
        public void MustOverwritePostedModelPropertiesWithResetModelValues()
        {
            // Arrange
            var postedModel = new DateInputViewModel
            {
                Legend = "Original Label",
                QuestionType = InputMultiQuestionType.Single,
                Hint = "Original Hint",
                Error = "Original Error",
                Day = "1",
                Month = "3",
                Year = "2023"
            };

            var resetModel = new DateInputViewModel
            {
                Legend = "New Label",
                QuestionType = InputMultiQuestionType.Multiple,
                Hint = "New Hint",
                Error = "New Error",
                Day = "8",
                Month = "4",
                Year = "2025"
            };

            // Act
            var result = DateInputViewModelExtension.PopulateDateInputViewModel(postedModel, resetModel);

            // Assert
            result.Legend.ShouldBe("New Label");
            result.QuestionType.ShouldBe(InputMultiQuestionType.Multiple);
            result.Hint.ShouldBe("New Hint");
            result.Error.ShouldBe("New Error");
            result.Day.ShouldBe("1");
            result.Month.ShouldBe("3");
            result.Year.ShouldBe("2023");
        }
    }
}
