namespace GDS.Components.Enum
{
    public class InputMultiQuestionExtensionsAttribute : Attribute
    {
        public string LabelClass { get; set; }
        public string LegendClass { get; set; }
        public bool HasH1Wrapper { get; set; }
    }

    public enum InputMultiQuestionType
    {
        [InputMultiQuestionExtensions(LabelClass= "govuk-label govuk-label--l", LegendClass = "govuk-fieldset__legend govuk-fieldset__legend--l", HasH1Wrapper =true)]
        Single,
        [InputMultiQuestionExtensions(LabelClass = "govuk-label", LegendClass = "govuk-fieldset__legend", HasH1Wrapper = false)]
        Multiple
    }
}
