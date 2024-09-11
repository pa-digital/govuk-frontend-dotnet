namespace GDS.Components.Models
{
    using Microsoft.AspNetCore.Html;

    public class TabContentModel
    {
        public string TabHeader { get; set; }
        public IHtmlContent TabContent { get; set; }
    }
}
