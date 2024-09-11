namespace GDS.Components.Test.Validators
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class RequiredCheckBoxTypeAttributeTests
    {
        private RequiredCheckBoxTypeAttribute _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new RequiredCheckBoxTypeAttribute { ErrorMessage = "The checkbox field is required." };
        }

        [Test]
        public void ValidCheckBoxListViewModelMustReturnSuccess()
        {
            // Arrange
            var checkBoxListViewModel = new CheckBoxListViewModel { CheckBoxes = new List<CheckBoxViewModel>() { new() { Text = "Check Box 1", Value = "CB1" }, new() { Text = "Check Box 2", Value = "CB2", Checked = true } } };
            var validationContext = new ValidationContext(checkBoxListViewModel);

            // Act
            var result = _validator.GetValidationResult(checkBoxListViewModel, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [Test]
        public void InvalidCheckBoxListViewModelMustReturnValidationError()
        {
            // Arrange
            var checkBoxListViewModel = new CheckBoxListViewModel { CheckBoxes = new List<CheckBoxViewModel>() { new() { Text = "Check Box 1", Value = "CB1" }, new() { Text = "Check Box 2", Value = "CB2" } } };
            var validationContext = new ValidationContext(checkBoxListViewModel);

            // Act
            var result = _validator.GetValidationResult(checkBoxListViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The checkbox field is required.");
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void InvalidCheckBoxListViewModelMustReturnDefaultValidationErrorWhenErrorMessageNotSpecified()
        {
            // Arrange
            _validator = new RequiredCheckBoxTypeAttribute();
            var checkBoxListViewModel = new CheckBoxListViewModel { CheckBoxes = new List<CheckBoxViewModel>() { new() { Text = "Check Box 1", Value = "CB1" }, new() { Text = "Check Box 2", Value = "CB2" } } };
            var validationContext = new ValidationContext(checkBoxListViewModel);

            // Act
            var result = _validator.GetValidationResult(checkBoxListViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The field is required.");
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void NonRequiredCheckBoxTypeMustReturnSuccess()
        {
            // Arrange
            var simpleObject = new object();
            var validationContext = new ValidationContext(simpleObject);

            // Act
            var result = _validator.GetValidationResult(simpleObject, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }
    }
}
