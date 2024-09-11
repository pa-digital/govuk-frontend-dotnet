namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Extensions;

    public class ButtonViewModel
    {
        public string Text { get; set; }
        public ButtonType ButtonType { get; set; }
        public ButtonAction ButtonAction { get; set; }
        public string ButtonVerb { get { return ButtonAction.GetAttribute<ButtonActionExtensionsAttribute>().ElementVerb; } }
        public string ButtonClass { get { return ButtonType.GetAttribute<ButtonTypeExtensionsAttribute>().ClassName; } }
    }
}
