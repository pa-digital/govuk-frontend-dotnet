namespace GDS.Components.Test.Validators
{
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.ComponentModel.DataAnnotations;

    [TestFixture]
    public class RequiredSelectTypeAttributeTest
    {
        private RequiredSelectTypeAttribute _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new RequiredSelectTypeAttribute { ErrorMessage = "The select field is required." };
        }

        [Test]
        public void ValidSelectViewModelMustReturnSuccess()
        {
            // Arrange
            var selectViewModel = new SelectViewModel { Value = "SomeValue" };
            var validationContext = new ValidationContext(selectViewModel);

            // Act
            var result = _validator.GetValidationResult(selectViewModel, validationContext);

            // Assert
            result.ShouldBe(ValidationResult.Success);
        }

        [Test]
        public void InvalidSelectViewModelMustReturnValidationError()
        {
            // Arrange
            var selectViewModel = new SelectViewModel { Value = "" };
            var validationContext = new ValidationContext(selectViewModel);

            // Act
            var result = _validator.GetValidationResult(selectViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The select field is required.");
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void DefaultInvalidSelectViewModelMustReturnDefaultValidationError()
        {
            // Arrange
            _validator = new RequiredSelectTypeAttribute();
            var selectViewModel = new SelectViewModel { Value = "" };
            var validationContext = new ValidationContext(selectViewModel);

            // Act
            var result = _validator.GetValidationResult(selectViewModel, validationContext);

            // Assert
            result.ShouldNotBeNull();
            result.ErrorMessage.ShouldBe("The field is required.");
            result.MemberNames.ShouldContain(".Value");
        }

        [Test]
        public void NonRequiredSelectTypeMustReturnSuccess()
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
