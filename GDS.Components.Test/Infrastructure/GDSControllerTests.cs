namespace GDS.Components.Test.Infrastructure
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Infrastructure;
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class GDSControllerTests
    {
        [Test]
        public void ValidateModelMustThrowExceptionWhenModelIsNull()
        {
            // Arrange
            var controller = new GDSController();
            var nullModel = new TestModel();
            nullModel = null;

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => controller.ValidateModel(nullModel));

            // Verify the exception message
            ex.Message.ShouldBe("Model cannot be null (Parameter 'model')");
        }

        [Test]
        public void ValidateModelMustClearModelStateWhenModelIsValidWithNoValidators()
        {
            // Arrange
            var controller = new GDSController();
            var validModel = new TestModel();

            // Act
            controller.ValidateModel(validModel);

            // Assert
            controller.ModelState.IsValid.ShouldBeTrue();
            controller.ModelState.Keys.Count().ShouldBe(0);
        }

        [Test]
        public void ValidateModelMustClearModelStateWhenModelIsValidWithRequiredValidators()
        {
            // Arrange
            var controller = new GDSController();
            var validModel = new RequiredTestModel { Name = new InputViewModel() { Value = "Name" }, Email = new InputViewModel() { Value = "Email" } };

            // Act
            controller.ValidateModel(validModel);

            // Assert
            controller.ModelState.IsValid.ShouldBeTrue();
            controller.ModelState.Keys.Count().ShouldBe(0);
        }

        [Test]
        public void ValidateModelMustClearModelStateWhenModelIsValidWithRegexValidators()
        {
            // Arrange
            var controller = new GDSController();
            var validModel = new RegexTestModel { Name = new InputViewModel() { Value = "Data" }, Email = new InputViewModel() { Value = "user@domain.com" } };

            // Act
            controller.ValidateModel(validModel);

            // Assert
            controller.ModelState.IsValid.ShouldBeTrue();
            controller.ModelState.Keys.Count().ShouldBe(0);
        }

        [TestCaseSource(nameof(InvalidRequiredTestModelData))]
        public void ValidateModelMustAddModelStateErrorWhenModelIsInvalidWithRequiredValidators(RequiredTestModel model, string modelStateNameKey, string modelStateEmailKey)
        {
            // Arrange
            var controller = new GDSController();

            // Act
            controller.ValidateModel(model);

            // Assert
            controller.ModelState.IsValid.ShouldBeFalse();
            controller.ModelState.Keys.Count().ShouldBe(2);
            controller.ModelState[modelStateNameKey].Errors.Count.ShouldBe(1);
            controller.ModelState[modelStateNameKey].Errors[0].ErrorMessage.ShouldBe("Name is required.");
            controller.ModelState[modelStateEmailKey].Errors.Count.ShouldBe(1);
            controller.ModelState[modelStateEmailKey].Errors[0].ErrorMessage.ShouldBe("Email is required.");
        }

        [TestCaseSource(nameof(InvalidRegexTestModelData))]
        public void ValidateModelMustAddModelStateErrorWhenModelIsInvalidWithRegexValidators(RegexTestModel model, string modelStateNameKey, string modelStateEmailKey)
        {
            // Arrange
            var controller = new GDSController();

            // Act
            controller.ValidateModel(model);

            // Assert
            controller.ModelState.IsValid.ShouldBeFalse();
            controller.ModelState.Keys.Count().ShouldBe(2);
            controller.ModelState[modelStateNameKey].Errors.Count.ShouldBe(1);
            controller.ModelState[modelStateNameKey].Errors[0].ErrorMessage.ShouldBe("Name is required.");
            controller.ModelState[modelStateEmailKey].Errors.Count.ShouldBe(1);
            controller.ModelState[modelStateEmailKey].Errors[0].ErrorMessage.ShouldBe("Email is required.");
        }

        [Test]
        public void ValidateModelMustAddModelStateErrorWhenModelIsInvalidWithListControlAttribute()
        {
            // Arrange
            var controller = new GDSController();
            var invalidModel = new TestModelWithListControl()
            {
                Options = new RadioButtonListViewModel()
            };

            // Act
            controller.ValidateModel(invalidModel);

            // Assert
            controller.ModelState.IsValid.ShouldBeFalse();
            controller.ModelState.Keys.Count().ShouldBe(1);
            controller.ModelState["Options.SelectedValue"].Errors.Count.ShouldBe(1);
            controller.ModelState["Options.SelectedValue"].Errors[0].ErrorMessage.ShouldBe("You must select an option.");
        }

        [Test]
        public void ValidateModelMustSetErrorPropertyForInnerModels()
        {
            // Arrange
            var controller = new GDSController();
            var model = new RequiredTestModel
            {
                Name = new InputViewModel(),
                Email = new InputViewModel()
            };

            // Act
            controller.ValidateModel(model);

            // Assert
            model.Name.Error.ShouldBe("Name is required.");
            model.Email.Error.ShouldBe("Email is required.");

            controller.ModelState.IsValid.ShouldBeFalse();
        }

        [Test]
        public void ValidateModelMustSetErrorTypePropertyForModelsWithCustomDateValidationResultProperties()
        {
            // Arrange
            var controller = new GDSController();
            var model = new CustomDateValidationModel
            {
                DateInput = new DateInputViewModel(),
                DOB = new DateInputViewModel(),
                PassportExpiry = new DateInputViewModel()
            };

            // Act
            controller.ValidateModel(model);

            // Assert
            model.DateInput.ErrorType.ShouldBe(DateInputErrorType.All);
            model.DOB.ErrorType.ShouldBe(DateInputErrorType.All);
            model.DOB.ErrorType.ShouldBe(DateInputErrorType.All);

            controller.ModelState.IsValid.ShouldBeFalse();
        }

        [Test]
        public void MapErrorsMustMapStateErrorsCorrectlyWhenPropertyDoesNotHaveListControlAttribute()
        {
            // Arrange
            var controller = new GDSController();
            controller.ModelState.AddModelError("Name", "Name is required.");
            controller.ModelState.AddModelError("Email", "Email is required.");

            // Act
            var result = controller.MapErrors<RequiredTestModel>();

            // Assert
            result.Count().ShouldBe(2);
            result[0].Text.ShouldBe("Name is required.");
            result[0].Url.ShouldBe("#name");
            result[1].Text.ShouldBe("Email is required.");
            result[1].Url.ShouldBe("#email");
        }

        [Test]
        public void MapErrorsMustAppendZeroWhenPropertyHasListControlAttribute()
        {
            // Arrange
            var controller = new GDSController();
            controller.ModelState.AddModelError("Options", "You must select an option.");

            // Act
            var result = controller.MapErrors<TestModelWithListControl>();

            // Assert
            result.ShouldHaveSingleItem();
            result[0].Text.ShouldBe("You must select an option.");
            result[0].Url.ShouldBe("#options-0");
        }

        public class TestModel
        {
            public InputViewModel Name { get; set; }
            public InputViewModel Email { get; set; }
            public int Age { get; set; }
            public string Error { get; set; }
        }

        public class RequiredTestModel
        {
            [RequiredComplexType(ErrorMessage = "Name is required.")]
            public InputViewModel Name { get; set; }

            [RequiredComplexType(ErrorMessage = "Email is required.")]
            public InputViewModel Email { get; set; }

            public int Age { get; set; }
            public string Error { get; set; }
        }

        public class RegexTestModel
        {
            [RegexFromEnum(Regex.Name)]
            [RequiredComplexType(ErrorMessage = "Name is required.")]
            public InputViewModel Name { get; set; }

            [RegexFromEnum(Regex.Email)]
            [RequiredComplexType(ErrorMessage = "Email is required.")]
            public InputViewModel Email { get; set; }

            public int Age { get; set; }
            public string Error { get; set; }
        }

        private class TestModelWithListControl
        {
            [ListControl]
            [RequiredRadioButtonType(ErrorMessage = "You must select an option.")]
            public RadioButtonListViewModel Options { get; set; }
            public string Error { get; set; }
        }

        private class CustomDateValidationModel
        {

            [RequiredDateInputType(ErrorMessage = "This date is required.")]
            public DateInputViewModel DateInput { get; set; }

            [PastDateType(ErrorMessage = "Your date of birth must be in the past.")]
            [RequiredDateInputType(ErrorMessage = "Date of birth is required.")]
            public DateInputViewModel DOB { get; set; }

            [FutureDateType(ErrorMessage = "Passport expiry date must be in the future.")]
            [RequiredDateInputType(ErrorMessage = "Passport expiry date is required.")]
            public DateInputViewModel PassportExpiry { get; set; }
        }

        public static IEnumerable<TestCaseData> InvalidRequiredTestModelData()
        {
            yield return new TestCaseData(new RequiredTestModel(), "Name", "Email");
            yield return new TestCaseData(new RequiredTestModel() { Name = new InputViewModel() }, "Name.Value", "Email");
            yield return new TestCaseData(new RequiredTestModel() { Email = new InputViewModel() }, "Name", "Email.Value");
            yield return new TestCaseData(new RequiredTestModel() { Name = new InputViewModel(), Email = new InputViewModel() }, "Name.Value", "Email.Value");
        }

        public static IEnumerable<TestCaseData> InvalidRegexTestModelData()
        {
            yield return new TestCaseData(new RegexTestModel(), "Name", "Email");
            yield return new TestCaseData(new RegexTestModel() { Name = new InputViewModel() }, "Name.Value", "Email");
            yield return new TestCaseData(new RegexTestModel() { Email = new InputViewModel() }, "Name", "Email.Value");
            yield return new TestCaseData(new RegexTestModel() { Name = new InputViewModel(), Email = new InputViewModel() }, "Name.Value", "Email.Value");
        }
    }
}
