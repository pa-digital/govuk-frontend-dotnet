namespace GDS.Components.ViewModels
{
    using Microsoft.AspNetCore.Html;
    public class DetailsViewModel
    {
        public string Header { get; set; }
        public IHtmlContent ContentHtml { get; set; }
    }
}
