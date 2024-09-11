namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;
    using GDS.Components.Models;

    public class BreadcrumbsViewModel
    {
        public string Label { get; set; }
        public BreadcrumbType BreadcrumbType { get; set; }
        public IList<BaseUrlModel> Links { get; set; }
        public string WrapperClassName { get { return BreadcrumbType.GetAttribute<BreadcrumbTypeExtensionsAttribute>().ClassName; } }

        public BreadcrumbsViewModel()
        {
            Links = new List<BaseUrlModel>();
        }
    }
}
