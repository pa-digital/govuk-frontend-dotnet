namespace GDS.Components.Enum
{
    public class BreadcrumbTypeExtensionsAttribute : Attribute
    {
        public string ClassName { get; set; }
    }

    public enum BreadcrumbType
    {
        [BreadcrumbTypeExtensions(ClassName = "govuk-breadcrumbs")]
        Default,
        [BreadcrumbTypeExtensions(ClassName = "govuk-breadcrumbs govuk-breadcrumbs--inverse")]
        Inverse,
    }
}
