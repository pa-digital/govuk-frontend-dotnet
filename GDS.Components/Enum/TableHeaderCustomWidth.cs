namespace GDS.Components.Enum
{
    public class TableHeaderCustomWidthExtensionsAttribute : Attribute
    {
        public string ClassName { get; set; }
    }

    public enum TableHeaderCustomWidth
    {
        [TableHeaderCustomWidthExtensions(ClassName = "")]
        Standard,
        [TableHeaderCustomWidthExtensions(ClassName = " govuk-!-width-one-half")]
        Half,
        [TableHeaderCustomWidthExtensions(ClassName = " govuk-!-width-one-quarter")]
        Quarter
    }
}
