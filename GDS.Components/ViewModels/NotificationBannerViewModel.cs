namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Models;
    using Microsoft.AspNetCore.Html;

    public class NotificationBannerViewModel
    {
        public string Header { get; set; }
        public string SubHeader { get; set; }
        public IHtmlContent PreLinkContent { get; set; }
        public BaseUrlModel Link { get; set; }
        public IHtmlContent PostLinkContent { get; set; }
        public NotificationOutcomeType Outcome { get; set; }
        public string WrapperClassName { get { return Outcome.GetAttribute<NotificationOutcomeTypeExtensionsAttribute>().ClassName; } }
        public string WrapperAriaRole { get { return Outcome.GetAttribute<NotificationOutcomeTypeExtensionsAttribute>().AriaRole; } }
        public bool ShowSubHeader { get { return !string.IsNullOrEmpty(Header); } }
        public bool ShowAlert { get { return Outcome == NotificationOutcomeType.Alert; } }

    }
}
