namespace GDS.Components.Test.Enums
{
    using System;
    using System.Reflection;
    using GDS.Components.Enum;
    using Shouldly;

    [TestFixture]
    public class EnumTests
    {
        [TestCaseSource(nameof(EnumValuesTestData))]
        public void EnumMustHaveCorrectNumberOfEntriesAndAttributes(Type enumType, int expectedNumberOfEntries, IList<object> expectedEnumEntries, IList<(bool hasAttribute, Type attributeType)> attributeExpectations)
        {
            // Arrange/Act
            var enumValues = Enum.GetValues(enumType);
            enumValues.Length.ShouldBe(expectedNumberOfEntries);
            for (int i = 0; i < expectedEnumEntries.Count; i++)
            {
                enumValues.GetValue(i).ShouldBe(expectedEnumEntries[i]);
            }
            for (int i = 0; i < expectedEnumEntries.Count; i++)
            {
                var enumValue = expectedEnumEntries[i];
                var fieldInfo = enumType.GetField(enumValue.ToString());
                var (hasAttribute, attributeType) = attributeExpectations[i];

                if (hasAttribute && attributeType != null)
                {
                    var attribute = fieldInfo.GetCustomAttribute(attributeType);
                    attribute.ShouldNotBeNull();
                }
                else
                {
                    var attribute = fieldInfo.GetCustomAttributes(false).FirstOrDefault();
                    attribute.ShouldBeNull();
                }
            }
        }

        public static IEnumerable<TestCaseData> EnumValuesTestData()
        {
            yield return new TestCaseData(
                typeof(BreadcrumbType),
                2,
                new List<object> { BreadcrumbType.Default, BreadcrumbType.Inverse },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(BreadcrumbTypeExtensionsAttribute)),
                    (true, typeof(BreadcrumbTypeExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
                typeof(ButtonAction),
                3,
                new List<object> { ButtonAction.Button, ButtonAction.Submit, ButtonAction.Cancel },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(ButtonActionExtensionsAttribute)),
                    (true, typeof(ButtonActionExtensionsAttribute)),
                    (true, typeof(ButtonActionExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
                typeof(ButtonType),
                4,
                new List<object> { ButtonType.Default, ButtonType.Secondary, ButtonType.Warning, ButtonType.Inverse },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(ButtonTypeExtensionsAttribute)),
                    (true, typeof(ButtonTypeExtensionsAttribute)),
                    (true, typeof(ButtonTypeExtensionsAttribute)),
                    (true, typeof(ButtonTypeExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
                typeof(CheckBoxType),
                2,
                new List<object> { CheckBoxType.CheckBox, CheckBoxType.Divider },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (false, null),
                    (false, null)
                }
            );

            yield return new TestCaseData(
                typeof(DateInputErrorType),
                8,
                new List<object>
                {
                    DateInputErrorType.None,
                    DateInputErrorType.DayOnly,
                    DateInputErrorType.MonthOnly,
                    DateInputErrorType.YearOnly,
                    DateInputErrorType.DayMonth,
                    DateInputErrorType.DayYear,
                    DateInputErrorType.MonthYear,
                    DateInputErrorType.All
                },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(DateInputErrorTypeExtensionsAttribute)),
                    (true, typeof(DateInputErrorTypeExtensionsAttribute)),
                    (true, typeof(DateInputErrorTypeExtensionsAttribute)),
                    (true, typeof(DateInputErrorTypeExtensionsAttribute)),
                    (true, typeof(DateInputErrorTypeExtensionsAttribute)),
                    (true, typeof(DateInputErrorTypeExtensionsAttribute)),
                    (true, typeof(DateInputErrorTypeExtensionsAttribute)),
                    (true, typeof(DateInputErrorTypeExtensionsAttribute))
                }
             );

            yield return new TestCaseData(
                typeof(InputMultiQuestionType),
                2,
                new List<object> { InputMultiQuestionType.Single, InputMultiQuestionType.Multiple },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(InputMultiQuestionExtensionsAttribute)),
                    (true, typeof(InputMultiQuestionExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
               typeof(InputType),
               4,
               new List<object> { InputType.Text, InputType.Email, InputType.Number, InputType.Telephone },
               new List<(bool hasAttribute, Type attributeType)>
               {
                    (true, typeof(InputTypeExtensionsAttribute)),
                    (true, typeof(InputTypeExtensionsAttribute)),
                    (true, typeof(InputTypeExtensionsAttribute)),
                    (true, typeof(InputTypeExtensionsAttribute))
               }
           );

            yield return new TestCaseData(
                typeof(NotificationOutcomeType),
                2,
                new List<object> { NotificationOutcomeType.Alert, NotificationOutcomeType.Success },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(NotificationOutcomeTypeExtensionsAttribute)),
                    (true, typeof(NotificationOutcomeTypeExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
                typeof(PaginationType),
                2,
                new List<object> { PaginationType.Numeric, PaginationType.Content },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (false, null),
                    (false, null)
                }
            );

            yield return new TestCaseData(
                typeof(RadioButtonType),
                2,
                new List<object> { RadioButtonType.RadioButton, RadioButtonType.Divider },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (false, null),
                    (false, null)
                }
            );

            yield return new TestCaseData(
                typeof(Regex),
                3,
                new List<object> { Regex.Name, Regex.Email, Regex.Password },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(RegexValidatorExtensionsAttribute)),
                    (true, typeof(RegexValidatorExtensionsAttribute)),
                    (true, typeof(RegexValidatorExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
                typeof(TableCellDataType),
                2,
                new List<object> { TableCellDataType.String, TableCellDataType.Numeric },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(TableCellDataTypeExtensionsAttribute)),
                    (true, typeof(TableCellDataTypeExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
                typeof(TableHeaderCustomWidth),
                3,
                new List<object> { TableHeaderCustomWidth.Standard, TableHeaderCustomWidth.Half, TableHeaderCustomWidth.Quarter },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(TableHeaderCustomWidthExtensionsAttribute)),
                    (true, typeof(TableHeaderCustomWidthExtensionsAttribute)),
                    (true, typeof(TableHeaderCustomWidthExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
                typeof(TableHeaderDataType),
                2,
                new List<object> { TableHeaderDataType.String, TableHeaderDataType.Numeric },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(TableHeaderDataTypeExtensionsAttribute)),
                    (true, typeof(TableHeaderDataTypeExtensionsAttribute))
                }
            );

            yield return new TestCaseData(
                typeof(TagType),
                11,
                new List<object> { TagType.Default, TagType.Grey, TagType.Green, TagType.Turquoise, TagType.Blue, TagType.LightBlue, TagType.Purple, TagType.Pink, TagType.Red, TagType.Orange, TagType.Yellow },
                new List<(bool hasAttribute, Type attributeType)>
                {
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute)),
                    (true, typeof(TagTypeExtensionsAttribute))
                }
            );
        }
    }
}
