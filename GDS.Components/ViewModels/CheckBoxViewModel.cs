namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    public class CheckBoxViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; }
        public string Text { get; set; }
        public string Hint { get; set; }
        public CheckBoxType CheckBoxType { get; set; }
        public bool Exclusive { get; set; }
    }
}
