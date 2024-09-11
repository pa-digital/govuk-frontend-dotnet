namespace GDS.Components.Test.Validators
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class RequiredRadioButtonTypeAttributeTests
    {
        private RequiredRadioButtonTypeAttribute _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new RequiredRadioButtonTypeAttribute { ErrorMessage = "The radio button field is required." };
        }

        [Test]
        public void ValidRadioButtonListViewModelMustReturnSuccess()
        {
            // Arrange
            var radioButtonListViewModel = new RadioButtonListViewModel { RadioButtons = new List<RadioButtonViewModel>() { new() { Text = "Radio Button 1", Value = "RB1" }, new() { Text = "Radio Button 2", Value = "RB2", Checked = true } } };
            var validationContext = new ValidationContext(radioButtonListViewModel);

            // Act
            var result = _validator.GetValidationResult(radioButtonListViewModel, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [Test]
        public void InvalidRadioButtonListViewModelMustReturnValidationError()
        {
            // Arrange
            var radioButtonListViewModel = new RadioButtonListViewModel { RadioButtons = new List<RadioButtonViewModel>() { new() { Text = "Radio Button 1", Value = "RB1" }, new() { Text = "Radio Button 2", Value = "RB2" } } };
            var validationContext = new ValidationContext(radioButtonListViewModel);

            // Act
            var result = _validator.GetValidationResult(radioButtonListViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The radio button field is required.");
            result.MemberNames.ShouldContain(".SelectedValue");
        }

        [Test]
        public void DefaultInvalidRadioButtonListViewModelMustReturnDefaultValidationError()
        {
            // Arrange
            _validator = new RequiredRadioButtonTypeAttribute();
            var radioButtonListViewModel = new RadioButtonListViewModel { RadioButtons = new List<RadioButtonViewModel>() { new() { Text = "Radio Button 1", Value = "RB1" }, new() { Text = "Radio Button 2", Value = "RB2" } } };
            var validationContext = new ValidationContext(radioButtonListViewModel);

            // Act
            var result = _validator.GetValidationResult(radioButtonListViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The field is required.");
            result.MemberNames.ShouldContain(".SelectedValue");
        }

        [Test]
        public void NonRequiredRadioButtonTypeMustReturnSuccess()
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
