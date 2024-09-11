namespace GDS.Components.Enum
{

    public class ButtonActionExtensionsAttribute : Attribute
    {
        public string ElementVerb { get; set; }
    }

    public enum ButtonAction
    {
        [ButtonActionExtensions(ElementVerb = "button")]
        Button,
        [ButtonActionExtensions(ElementVerb = "submit")]
        Submit,
        [ButtonActionExtensions(ElementVerb = "cancel")]
        Cancel
    }
}
