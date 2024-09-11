namespace GDS.Components.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;
    public class SelectViewCalculationModel
    {
        public readonly string containerClass;
        public readonly string elementClass;
        public readonly string labelClass;
        public readonly bool showH1;
        public readonly bool isError;
        public readonly bool hasHint;
        public readonly bool hasAria;
        public readonly string ariaDescribedBy;
        public readonly bool showDescribedByTag;

        public SelectViewCalculationModel(SelectViewModel model, string baseId)
        {
            containerClass = "govuk-form-group";
            elementClass = "govuk-select";
            labelClass = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().LabelClass;
            showH1 = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().HasH1Wrapper;
            isError = !string.IsNullOrEmpty(model.Error);
            hasHint = !string.IsNullOrEmpty(model.Hint);
            hasAria = false;
            ariaDescribedBy = string.Empty;
            if (hasHint)
            {
                ariaDescribedBy = $"{baseId}-hint";
                hasAria = true;
            }
            if (isError)
            {
                containerClass = $"{containerClass} govuk-form-group--error";
                elementClass = $"{elementClass} govuk-input--error";
                ariaDescribedBy = $"{baseId}-error {ariaDescribedBy}";
                hasAria = true;
            }
            showDescribedByTag = !string.IsNullOrEmpty(ariaDescribedBy);
        }
    }
}
