namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;

    public class TagViewModel
    {
        public TagType TagType { get; set; }
        public string Text { get; set; }
        public string TagClassName { get { return TagType.GetAttribute<TagTypeExtensionsAttribute>().ClassName; } } 
    }
}
