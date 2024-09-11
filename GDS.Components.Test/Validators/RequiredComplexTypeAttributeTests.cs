namespace GDS.Components.Test.Validators
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class RequiredComplexTypeAttributeTests
    {
    
        [Test]
        public void ValidInputViewModelMustReturnSuccess()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute { ErrorMessage = "The input field is required." };
            var inputViewModel = new InputViewModel { Value = "SomeValue" };
            var validationContext = new ValidationContext(inputViewModel);

            // Act
            var result = validator.GetValidationResult(inputViewModel, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [Test]
        public void NullInputViewModelThrowsCorrectError()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute { ErrorMessage = "The input field is required." };
            var inputViewModel = new InputViewModel { Value = "SomeValue" };
            var validationContext = new ValidationContext(inputViewModel);

            // Act
            var result = validator.GetValidationResult(null, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The input field is required.");
         }

        [Test]
        public void InvalidInputViewModelMustReturnValidationError()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute { ErrorMessage = "The input field is required." };
            var inputViewModel = new InputViewModel { Value = "" };
            var validationContext = new ValidationContext(inputViewModel);

            // Act
            var result = validator.GetValidationResult(inputViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The input field is required.");
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void DefaultInvalidInputViewModelMustReturnDefaultValidationError()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute();
            var inputViewModel = new InputViewModel { Value = "" };
            var validationContext = new ValidationContext(inputViewModel);

            // Act
            var result = validator.GetValidationResult(inputViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The field is required.");
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void NullInvalidInputViewModelMustReturnDefaultValidationError()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute();
            var inputViewModel = new InputViewModel { Value = "SomeValue" };
            var validationContext = new ValidationContext(inputViewModel);

            // Act
            var result = validator.GetValidationResult(null, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The field is required.");
        }

        [Test]
        public void ValidPasswordViewModelMustReturnSuccess()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute { ErrorMessage = "The password field is required." };
            var passwordViewModel = new PasswordViewModel { Value = "SomePassword" };
            var validationContext = new ValidationContext(passwordViewModel);

            // Act
            var result = validator.GetValidationResult(passwordViewModel, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [Test]
        public void InvalidPasswordViewModelMustReturnValidationError()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute { ErrorMessage = "The password field is required." };
            var passwordViewModel = new PasswordViewModel { Value = "" };
            var validationContext = new ValidationContext(passwordViewModel);

            // Act
            var result = validator.GetValidationResult(passwordViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The password field is required.");
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void DefaultInvalidPasswordViewModelMustReturnDefaultValidationError()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute();
            var passwordViewModel = new PasswordViewModel { Value = "" };
            var validationContext = new ValidationContext(passwordViewModel);

            // Act
            var result = validator.GetValidationResult(passwordViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The field is required.");
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void NonComplexTypeMustReturnSuccess()
        {
            // Arrange
            var validator = new RequiredComplexTypeAttribute();
            var simpleObject = new object();
            var validationContext = new ValidationContext(simpleObject);

            // Act
            var result = validator.GetValidationResult(simpleObject, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }
    }
}
