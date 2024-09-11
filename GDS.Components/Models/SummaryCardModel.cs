namespace GDS.Components.Models
{
    using GDS.Components.ViewModels;

    public class SummaryCardModel
    {
        public string Header { get; set; }
        public IList<SummaryListActionLinkModel> ActionLinks { get; set; }
        public SummaryListViewModel Content { get; set; }
        public SummaryCardModel()
        {
            ActionLinks = new List<SummaryListActionLinkModel>();
        }
    }
}
