namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Infrastructure;

    public class RadioButtonListViewModel : BaseOptionViewModel
    {
        public string Legend { get; set; }
        public IList<RadioButtonViewModel> RadioButtons { get; set; }
        public string SelectedValue { get; set; }
        public InputMultiQuestionType QuestionType { get; set; }
        public string Hint { get; set; }
        public string Error { get; set; }
        public bool Compact { get; set; }
        public bool Inline { get; set; }

        public RadioButtonListViewModel()
        {
            RadioButtons = new List<RadioButtonViewModel>();
        }

        public string GetValue()
        {
            return RadioButtons.Where(cb => cb.Checked).FirstOrDefault(rb => rb.Checked)?.Value ?? string.Empty;
        }

        public string GetDisplayValue()
        {
            return RadioButtons.Where(cb => cb.Checked).FirstOrDefault(rb => rb.Checked)?.Text ?? string.Empty;
        }
    }
}
