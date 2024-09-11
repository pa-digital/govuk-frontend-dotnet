namespace GDS.Components.ViewModels
{
    using GDS.Components.Models;
    public class SummaryListViewModel
    {
        public IList<SummaryListItemModel> Items { get; set; }
        public bool HideBorders { get; set; }
        public string TopLevelBorderClass { get { return HideBorders ? "govuk-summary-list govuk-summary-list--no-border" : "govuk-summary-list"; } }

        public SummaryListViewModel()
        {
            Items = new List<SummaryListItemModel>();
        }
    }
}
