namespace GDS.Components.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;

    public class RadioButtonListViewCalculationModel
    {
        public readonly string containerClass;
        public readonly string radioButtonGroupClass;
        public readonly string legendClass;
        public readonly bool showH1;
        public readonly bool isError;
        public readonly bool hasHint;
        public readonly string describedByTag;
        public readonly bool showDescribedByTag;

        public RadioButtonListViewCalculationModel(RadioButtonListViewModel model, string baseId)
        {
            containerClass = "govuk-form-group";
            radioButtonGroupClass = "govuk-radios";
            if (model.Compact)
            {
                radioButtonGroupClass += " govuk-radios--small";
            }
            if (model.Inline)
            {
                radioButtonGroupClass += " govuk-radios--inline";
            }
            legendClass = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().LegendClass;
            showH1 = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().HasH1Wrapper;
            isError = !string.IsNullOrEmpty(model.Error);
            hasHint = !string.IsNullOrEmpty(model.Hint);
            if (hasHint) 
            {
                describedByTag = $"{baseId}-hint";
                showDescribedByTag = true;
                hasHint = true;
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
