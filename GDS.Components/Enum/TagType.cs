namespace GDS.Components.Enum
{
    public class TagTypeExtensionsAttribute : Attribute
    {
        public string ClassName { get; set; }
    }

    public enum TagType
    {
        [TagTypeExtensions(ClassName = "govuk-tag")]
        Default,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--grey")]
        Grey,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--green")]
        Green,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--turquoise")]
        Turquoise,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--blue")]
        Blue,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--light-blue")]
        LightBlue,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--purple")]
        Purple,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--pink")]
        Pink,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--red")]
        Red,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--orange")]
        Orange,
        [TagTypeExtensions(ClassName = "govuk-tag govuk-tag--yellow")]
        Yellow
    }
}
