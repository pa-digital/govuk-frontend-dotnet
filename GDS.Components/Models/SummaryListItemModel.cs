namespace GDS.Components.Models
{
    using Microsoft.AspNetCore.Html;

    public class SummaryListItemModel
    {
        public string Label { get; set; }
        public IHtmlContent Text { get; set; }
        public BaseUrlModel MissingItem { get; set; }
        public IList<SummaryListActionLinkModel> ActionLinks { get; set; }
        public int ActionItemCount { get { return ActionLinks.Count(); } }
        public string RowClass { get { return ActionItemCount == 0 ? "govuk-summary-list__row govuk-summary-list__row--no-actions" : "govuk-summary-list__row"; } }

        public SummaryListItemModel()
        {
            ActionLinks = new List<SummaryListActionLinkModel>();
        }
    }
}
