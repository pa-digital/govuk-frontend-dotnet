namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Infrastructure;
    using GDS.Components.Models;

    public class SelectViewModel : BaseOptionViewModel
    {
        public string Label { get; set; }
        public InputMultiQuestionType QuestionType { get; set; }
        public string Hint { get; set; }
        public IList<OptionModel> Options { get; set; }
        public string Error { get; set; }
        public string Value { get; set; }
        public string GetValue()
        {
            return Options?.FirstOrDefault(op => op.Selected)?.Value ?? Value;
        }

        public string GetDisplayValue()
        {
            return Options?.FirstOrDefault(op => op.Selected)?.Text ?? "";
        }

        public SelectViewModel()
        {
            Options = new List<OptionModel>();
        }

    }
}
