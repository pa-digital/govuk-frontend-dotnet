namespace GDS.Components.Enum
{
    public class TableCellDataTypeExtensionsAttribute : Attribute
    {
        public string ClassName { get; set; }
    }

    public enum TableCellDataType
    {
        [TableCellDataTypeExtensions(ClassName = "govuk-table__cell")]
        String,
        [TableCellDataTypeExtensions(ClassName = "govuk-table__cell govuk-table__cell--numeric")]
        Numeric
    }
}
