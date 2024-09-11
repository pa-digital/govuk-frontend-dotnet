namespace GDS.Components.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;

    public class InputViewCalculationsModel
    {
        public readonly string containerClass;
        public readonly string elementClass;
        public readonly string labelClass;
        public readonly bool showH1;
        public string inputType;
        public readonly bool isError;
        public readonly bool hasHint;

        public InputViewCalculationsModel(InputViewModel model)
        {
            containerClass = "govuk-form-group";
            elementClass = "govuk-input";
            labelClass = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().LabelClass;
            showH1 = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().HasH1Wrapper;
            inputType = model.InputType.GetAttribute<InputTypeExtensionsAttribute>().ElementVerb;
            isError = !string.IsNullOrEmpty(model.Error);
            hasHint = !string.IsNullOrEmpty(model.Hint);
            if (isError)
            {
                containerClass = $"{containerClass} govuk-form-group--error";
                elementClass = $"{elementClass} govuk-input--error";
            }
        }
    }
}
