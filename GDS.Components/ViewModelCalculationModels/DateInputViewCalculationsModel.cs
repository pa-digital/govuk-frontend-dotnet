namespace GDS.Components.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    public class DateInputViewCalculationsModel
    {
        public readonly string containerClass;
        public readonly string legendClass;
        public readonly bool showH1;
        public readonly bool isHint;
        public readonly bool isError;
        public readonly string describedByTag;
        public readonly bool showDescribedByTag;
        public readonly string dayInputClassName;
        public readonly string monthInputClassName;
        public readonly string yearInputClassName;

        public DateInputViewCalculationsModel(DateInputViewModel model, string baseId)
        {
            containerClass = "govuk-form-group";
            legendClass = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().LegendClass;
            showH1 = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().HasH1Wrapper;
            isHint = !string.IsNullOrEmpty(model.Hint);
            isError = !string.IsNullOrEmpty(model.Error);
            if (isHint)
            {
                describedByTag = $"{baseId}-hint";
                showDescribedByTag = true;
            }
            if (isError)
            {
                describedByTag = $"{baseId}-error {describedByTag}";
                showDescribedByTag = true;
                containerClass = $"{containerClass} govuk-form-group--error";
            }
            dayInputClassName = model.ErrorType.GetAttribute<DateInputErrorTypeExtensionsAttribute>().DayClassName;
            monthInputClassName = model.ErrorType.GetAttribute<DateInputErrorTypeExtensionsAttribute>().MonthClassName;
            yearInputClassName = model.ErrorType.GetAttribute<DateInputErrorTypeExtensionsAttribute>().YearClassName;
        }
    }
}
