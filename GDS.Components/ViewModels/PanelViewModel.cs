namespace GDS.Components.ViewModels
{
    using Microsoft.AspNetCore.Html;

    public class PanelViewModel
    {
        public IHtmlContent Header { get; set; }
        public IHtmlContent Content { get; set; }
    }
}
