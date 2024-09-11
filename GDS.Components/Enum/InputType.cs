namespace GDS.Components.Enum
{

    public class InputTypeExtensionsAttribute : Attribute
    {
        public string ElementVerb { get; set; }
    }

    public enum InputType
    {
        [InputTypeExtensions(ElementVerb ="text")]
        Text,
        [InputTypeExtensions(ElementVerb = "email")]
        Email,
        [InputTypeExtensions(ElementVerb = "number")]
        Number,
        [InputTypeExtensions(ElementVerb = "tel")]
        Telephone
    }
}
