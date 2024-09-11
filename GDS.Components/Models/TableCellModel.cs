namespace GDS.Components.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;

    public class TableCellModel
    {
        public string Data { get; set; }
        public TableCellDataType DataType { get; set; }
        public string TableCellClassName { get { return DataType.GetAttribute<TableCellDataTypeExtensionsAttribute>().ClassName; } }
    }
}
