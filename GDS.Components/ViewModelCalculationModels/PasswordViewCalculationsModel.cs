namespace GDS.Components.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.ViewModels;

    public class PasswordViewCalculationsModel
    {
        public readonly string containerClass;
        public readonly string elementClass;
        public readonly string labelClass;
        public readonly bool showH1;
        public readonly bool isError;
        public readonly bool hasHint;

        public PasswordViewCalculationsModel(PasswordViewModel model)
        {
            containerClass = "govuk-form-group govuk-password-input";
            elementClass = "govuk-input govuk-password-input__input govuk-js-password-input-input";
            labelClass = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().LabelClass;
            showH1 = model.QuestionType.GetAttribute<InputMultiQuestionExtensionsAttribute>().HasH1Wrapper;
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
