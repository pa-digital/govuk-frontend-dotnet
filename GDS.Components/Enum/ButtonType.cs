namespace GDS.Components.Enum
{

    public class ButtonTypeExtensionsAttribute : Attribute
    {
        public string ClassName { get; set; }
    }

    public enum ButtonType
    {
        [ButtonTypeExtensions(ClassName = "govuk-button")]
        Default,
        [ButtonTypeExtensions(ClassName = "govuk-button govuk-button--secondary")]
        Secondary,
        [ButtonTypeExtensions(ClassName = "govuk-button govuk-button--warning")]
        Warning,
        [ButtonTypeExtensions(ClassName = "govuk-button govuk-button--inverse")]
        Inverse
    }
}
