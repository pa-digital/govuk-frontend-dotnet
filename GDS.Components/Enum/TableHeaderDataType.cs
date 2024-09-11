namespace GDS.Components.Enum
{
    public class TableHeaderDataTypeExtensionsAttribute : Attribute
    {
        public string ClassName { get; set; }
    }

    public enum TableHeaderDataType
    {
        [TableHeaderDataTypeExtensions(ClassName = "govuk-table__header")]
        String,
        [TableHeaderDataTypeExtensions(ClassName = "govuk-table__header govuk-table__header--numeric")]
        Numeric
    }
}
