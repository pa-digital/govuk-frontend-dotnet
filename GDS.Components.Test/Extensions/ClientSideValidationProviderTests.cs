namespace GDS.Components.Test.Extensions
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Validators;
    using GDS.Components.ViewModels;
    using Shouldly;
    using System.Reflection;

    [TestFixture]
    public class ClientSideValidationProviderTests
    {

        [TestCaseSource(nameof(GenerateClientSideValidationScriptTests))]
        public void GenerateClientSideValidationScriptMustReturnExpectedScript(object model, string expectedScript)
        {
            // Act
            var result = ClientSideValidationProvider.GenerateClientSideValidationScript(model);

            // Assert
            result.ShouldBe(expectedScript);
        }

        [Test]
        public void GenerateClientSideValidationScriptMustUseDefaultErrorMessagesWhenNoneAreSupplied()
        {
            // Act
            var result = ClientSideValidationProvider.GenerateClientSideValidationScript(new TestModel4());
            var expectedScript = "addRequiredValidation(1,'Name.Value', 'This field is required.');\r\n" +
            "addDateInputRequiredValidation(2,'DateOfBirth.Value', 'This field is required.');\r\n" +
            "addDateInputPastValidation(3,'PastDate.Value', 'A past date is required.');\r\n" +
            "addDateInputFutureValidation(4,'FutureDate.Value', 'A future date is required.');\r\n" +
            "addRequiredValidation(5,'Gender.SelectedValue', 'This field is required.', true);\r\n" +
            "addRequiredValidation(6,'Agreed', 'This field is required.', true);\r\n" +
            "addRequiredValidation(7,'Country', 'This field is required.', true);\r\n" +
            "addRegexValidation(8,'NationalInsuranceNumber.Value', '^[A-Z]{2}[0-9]{6}[A-Z]{1}$', '');\r\n";

            // Assert
            result.ShouldBe(expectedScript);
        }

        private class TestModel1
        {
            [RequiredComplexType(ErrorMessage = "Name is required.")]
            public InputViewModel Name { get; set; }

            [RequiredDateInputType(ErrorMessage = "Date is required.")]
            public DateInputViewModel DateOfBirth { get; set; }
        }

        private class TestModel2
        {
            [PastDateType(ErrorMessage = "Date must be in the past.")]
            public DateInputViewModel PastDate { get; set; }

            [FutureDateType(ErrorMessage = "Date must be in the future.")]
            public DateInputViewModel FutureDate { get; set; }

            [RequiredRadioButtonType(ErrorMessage = "Selection is required.")]
            public InputViewModel Gender { get; set; }

            [RequiredCheckBoxType(ErrorMessage = "Agreement is required.")]
            public CheckBoxListViewModel Agreed { get; set; }

            [RequiredSelectType(ErrorMessage = "Selection is required.")]
            public SelectViewModel Country { get; set; }

            [CustomRegExType(Pattern = @"^[A-Z]{2}[0-9]{6}[A-Z]{1}$", ErrorMessage = "The value must be in the format XX000000X.")]
            public InputViewModel NationalInsuranceNumber { get; set; }

            [RegexFromEnum(Regex.Email)]
            public InputViewModel Email { get; set; }
        }

        private class TestModel3
        {
            public InputViewModel NoValidatedStringProperty { get; set; }

            public DateInputViewModel NoValidatedDateProperty { get; set; }
        }

        private class TestModel4 {
            [RequiredComplexType]
            public InputViewModel Name { get; set; }

            [RequiredDateInputType]
            public DateInputViewModel DateOfBirth { get; set; }

            [PastDateType]
            public DateInputViewModel PastDate { get; set; }

            [FutureDateType]
            public DateInputViewModel FutureDate { get; set; }

            [RequiredRadioButtonType]
            public InputViewModel Gender { get; set; }

            [RequiredCheckBoxType]
            public CheckBoxListViewModel Agreed { get; set; }

            [RequiredSelectType]
            public SelectViewModel Country { get; set; }

            [CustomRegExType(Pattern = @"^[A-Z]{2}[0-9]{6}[A-Z]{1}$")]
            public InputViewModel NationalInsuranceNumber { get; set; }
        }

        public static IEnumerable<TestCaseData> GenerateClientSideValidationScriptTests()
        {
            var script = "addRequiredValidation(1,'Name.Value', 'Name is required.');\r\naddDateInputRequiredValidation(2,'DateOfBirth.Value', 'Date is required.');\r\n";
            yield return new TestCaseData(new TestModel1(), script);

            script = "addDateInputPastValidation(1,'PastDate.Value', 'Date must be in the past.');\r\naddDateInputFutureValidation(2,'FutureDate.Value', 'Date must be in the future.');\r\n" +
                "addRequiredValidation(3,'Gender.SelectedValue', 'Selection is required.', true);\r\naddRequiredValidation(4,'Agreed', 'Agreement is required.', true);\r\n" +
                "addRequiredValidation(5,'Country', 'Selection is required.', true);\r\n" +
                "addRegexValidation(6,'NationalInsuranceNumber.Value', '^[A-Z]{2}[0-9]{6}[A-Z]{1}$', 'The value must be in the format XX000000X.');\r\n" +
                "addRegexValidation(7,'Email.Value', '^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{1,}$', 'Please enter a valid email containing a username, an @ symbol a domain and top level domain');\r\n";
            yield return new TestCaseData(new TestModel2(), script);
            yield return new TestCaseData(new TestModel3(), string.Empty);
        }

    }
}
