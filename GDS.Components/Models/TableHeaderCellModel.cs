namespace GDS.Components.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;

    public class TableHeaderCellModel
    {
        public string Data { get; set; }
        public TableHeaderDataType DataType { get; set; }
        public TableHeaderCustomWidth CustomWidth { get; set; }
        public string HeaderCellClassName { get { return DataType.GetAttribute<TableHeaderDataTypeExtensionsAttribute>().ClassName; } }
        public string HeaderCellCustomWidthClassName { get { return CustomWidth.GetAttribute<TableHeaderCustomWidthExtensionsAttribute>().ClassName; } }
    }
}
