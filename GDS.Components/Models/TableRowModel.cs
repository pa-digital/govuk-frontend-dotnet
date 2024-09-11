namespace GDS.Components.Models
{
    public class TableRowModel
    {
        public string HeaderColumn { get; set; }
        public IList<TableCellModel> DataColumns { get; set; }

        public TableRowModel()
        {
            DataColumns = new List<TableCellModel>();
        }
    }
}
