namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;

    public class RadioButtonViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; }
        public string Text { get; set; }
        public string Hint { get; set; }
        public RadioButtonType RadioButtonType { get; set; }
        public bool HasHint { get { return !string.IsNullOrEmpty(Hint); } }
    }
}
