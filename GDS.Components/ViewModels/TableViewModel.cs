namespace GDS.Components.ViewModels
{
    using GDS.Components.Models;

    public class TableViewModel
    {
        public string Caption { get; set; }
        public IList<TableHeaderCellModel> Headers { get; set; }
        public IList<TableRowModel> Rows { get; set; }

        public TableViewModel()
        {
            Headers = new List<TableHeaderCellModel>();
            Rows = new List<TableRowModel>();
        }
    }
}
