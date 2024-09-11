namespace GDS.Components.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;

    public class CheckBoxListViewCalculationsModel
    {
        public readonly string containerClass;
        public readonly string checkBoxGroupClass;
        public readonly string legendClass;
        public readonly bool showH1;
        public readonly bool isHint;
        public readonly bool isError;
        public readonly string describedByTag;
        public readonly bool showDescribedByTag;

        public CheckBoxListViewCalculationsModel(CheckBoxListViewModel model, string baseId)
        {
            containerClass = "govuk-form-group";
            checkBoxGroupClass = "govuk-checkboxes";
            if (model.Compact)
            {
                checkBoxGroupClass += " govuk-checkboxes--small";
            }
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
                containerClass = $"{containerClass} govuk-form-group--error";
                showDescribedByTag = true;
            }
        }
    }
}
