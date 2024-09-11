namespace GDS.Components.Test.Enums
{
    using System;
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using Shouldly;

    [TestFixture]
    public class EnumExtensionMethodsTests
    {
        public class TestEnumTypeExtensionsAttribute : Attribute
        {
            public string FirstExtendedAttribute { get; set; }
            public string SecondExtendedAttribute { get; set; }
        }

        public enum TestEnumType
        {
            [TestEnumTypeExtensions(FirstExtendedAttribute = "Default first extended value", SecondExtendedAttribute = "Default second extended value")]
            Default,
            NonDecorated
        }

        [TestCaseSource(nameof(EnumAttributesTestData))]
        public void MustRetrieveAttributeFromEnum(Enum enumValue, Dictionary<string, object> expectedAttributeValues)
        {
            // Act
            var attribute = enumValue.GetType().GetField(enumValue.ToString())
                              .GetCustomAttributes(false)
                              .OfType<Attribute>()
                              .SingleOrDefault();

            // Assert
            attribute.ShouldNotBeNull();

            foreach (var expectedAttribute in expectedAttributeValues)
            {
                var actualValue = attribute.GetType().GetProperty(expectedAttribute.Key)?.GetValue(attribute);

                if (actualValue is bool)
                {
                    actualValue.ShouldBe((bool)expectedAttribute.Value);
                }
                else
                {
                    actualValue?.ToString().ShouldBe(expectedAttribute.Value.ToString());
                }
            }
        }

        [Test]
        public void MustReturnNullWhenNoAttributeIsApplied()
        {
            // Act
            var attribute = TestEnumType.NonDecorated.GetAttribute<TestEnumTypeExtensionsAttribute>();

            // Assert
            attribute.ShouldBeNull();
        }

        [Test]
        public void MustReturnNullIfAttributeTypeDoesNotExistOnEnumValue()
        {
            // Act
            var attribute = TestEnumType.Default.GetAttribute<ObsoleteAttribute>();

            // Assert
            attribute.ShouldBeNull();
        }


        public static IEnumerable<TestCaseData> EnumAttributesTestData()
        {
            yield return new TestCaseData(
                BreadcrumbType.Default,
                new Dictionary<string, object> { { "ClassName", "govuk-breadcrumbs" } }
            );

            yield return new TestCaseData(
                BreadcrumbType.Inverse,
                new Dictionary<string, object> { { "ClassName", "govuk-breadcrumbs govuk-breadcrumbs--inverse" } }
            );

            yield return new TestCaseData(
                ButtonAction.Button,
                new Dictionary<string, object> { { "ElementVerb", "button" } }
            );

            yield return new TestCaseData(
                ButtonAction.Submit,
                new Dictionary<string, object> { { "ElementVerb", "submit" } }
            );

            yield return new TestCaseData(
                ButtonType.Default,
                new Dictionary<string, object> { { "ClassName", "govuk-button" } }
            );

            yield return new TestCaseData(
                ButtonType.Secondary,
                new Dictionary<string, object> { { "ClassName", "govuk-button govuk-button--secondary" } }
            );

            yield return new TestCaseData(
                ButtonType.Warning,
                new Dictionary<string, object> { { "ClassName", "govuk-button govuk-button--warning" } }
            );

            yield return new TestCaseData(
                ButtonType.Inverse,
                new Dictionary<string, object> { { "ClassName", "govuk-button govuk-button--inverse" } }
            );

            yield return new TestCaseData(
                DateInputErrorType.None,
                new Dictionary<string, object>
                {
                    { "DayClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "MonthClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                }
            );

            yield return new TestCaseData(
                DateInputErrorType.DayOnly,
                new Dictionary<string, object>
                {
                    { "DayClassName", "govuk-input govuk-date-input__input govuk-input--width-2 govuk-input--error" },
                    { "MonthClassName", "govuk-input govuk-date-input__input govuk-input--width-2" },
                    { "YearClassName", "govuk-input govuk-date-input__input govuk-input--width-4" }
                }
            );

            yield return new TestCaseData(
                InputMultiQuestionType.Single,
                new Dictionary<string, object>
                {
                    { "LabelClass", "govuk-label govuk-label--l" },
                    { "LegendClass", "govuk-fieldset__legend govuk-fieldset__legend--l" },
                    { "HasH1Wrapper", true }
                }
            );

            yield return new TestCaseData(
                InputMultiQuestionType.Multiple,
                new Dictionary<string, object>
                {
                    { "LabelClass", "govuk-label" },
                    { "LegendClass", "govuk-fieldset__legend" },
                    { "HasH1Wrapper", false }
                }
            );

            yield return new TestCaseData(
               InputType.Text,
               new Dictionary<string, object> { { "ElementVerb", "text" } }
           );

            yield return new TestCaseData(
               InputType.Email,
               new Dictionary<string, object> { { "ElementVerb", "email" } }
           );

            yield return new TestCaseData(
               InputType.Number,
               new Dictionary<string, object> { { "ElementVerb", "number" } }
           );

            yield return new TestCaseData(
               InputType.Telephone,
               new Dictionary<string, object> { { "ElementVerb", "tel" } }
           );

            yield return new TestCaseData(
                NotificationOutcomeType.Alert,
                new Dictionary<string, object>
                {
                    { "ClassName", "govuk-notification-banner" },
                    { "AriaRole", "region" }
                }
            );

            yield return new TestCaseData(
                NotificationOutcomeType.Success,
                new Dictionary<string, object>
                {
                    { "ClassName", "govuk-notification-banner govuk-notification-banner--success" },
                    { "AriaRole", "alert" }
                }
            );

            yield return new TestCaseData(
                Regex.Name,
                new Dictionary<string, object>
                {
                    { "Pattern", @"^[a-zA-Z \-\']{2,}$" },
                    { "Error", "Your name must contain at least two characters and can include (A-Z) (a-z) a space, a hyphen and an apostrophe" }
                }
            );

            yield return new TestCaseData(
                Regex.Email,
                new Dictionary<string, object>
                {
                    { "Pattern", @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{1,}$" },
                    { "Error", "Please enter a valid email containing a username, an @ symbol a domain and top level domain" }
                }
            );

            yield return new TestCaseData(
                Regex.Password,
                new Dictionary<string, object>
                {
                    { "Pattern", @"^[a-zA-Z0-9\-]{8,}$" },
                    { "Error", "Your password must contain at least 8 characters from (A-Z)(a-z)(0-9) and a -" }
                }
            );

            yield return new TestCaseData(
                TableCellDataType.String,
                new Dictionary<string, object> { { "ClassName", "govuk-table__cell" } }
            );


            yield return new TestCaseData(
                TableCellDataType.Numeric,
                new Dictionary<string, object> { { "ClassName", "govuk-table__cell govuk-table__cell--numeric" } }
            );

            yield return new TestCaseData(
                TableHeaderCustomWidth.Standard,
                new Dictionary<string, object> { { "ClassName", string.Empty } }
            );

            yield return new TestCaseData(
                TableHeaderCustomWidth.Half,
                new Dictionary<string, object> { { "ClassName", " govuk-!-width-one-half" } }
            );

            yield return new TestCaseData(
                TableHeaderCustomWidth.Quarter,
                new Dictionary<string, object> { { "ClassName", " govuk-!-width-one-quarter" } }
            );

            yield return new TestCaseData(
                TableHeaderDataType.String,
                new Dictionary<string, object> { { "ClassName", "govuk-table__header" } }
            );

            yield return new TestCaseData(
                TableHeaderDataType.Numeric,
                new Dictionary<string, object> { { "ClassName", "govuk-table__header govuk-table__header--numeric" } }
            );

            yield return new TestCaseData(
                TagType.Default,
                new Dictionary<string, object> { { "ClassName", "govuk-tag" } }
            );

            yield return new TestCaseData(
                TagType.Grey,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--grey" } }
            );

            yield return new TestCaseData(
                TagType.Green,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--green" } }
            );

            yield return new TestCaseData(
                TagType.Turquoise,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--turquoise" } }
            );

            yield return new TestCaseData(
                TagType.Blue,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--blue" } }
            );

            yield return new TestCaseData(
                TagType.LightBlue,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--light-blue" } }
            );

            yield return new TestCaseData(
                TagType.Purple,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--purple" } }
            );

            yield return new TestCaseData(
                TagType.Pink,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--pink" } }
            );

            yield return new TestCaseData(
                TagType.Red,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--red" } }
            );

            yield return new TestCaseData(
                TagType.Orange,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--orange" } }
            );

            yield return new TestCaseData(
                TagType.Yellow,
                new Dictionary<string, object> { { "ClassName", "govuk-tag govuk-tag--yellow" } }
            );
        }
    }
}
