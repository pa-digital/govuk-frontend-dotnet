namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Infrastructure;

    public class InputViewModel : BaseSingleViewModel
    {
        public string Label { get; set; }
        public InputMultiQuestionType QuestionType { get; set; }
        public InputType InputType { get; set; }
        public string Hint { get; set; }
        public string Value { get; set; }
        public string Error { get; set; }

        public string GetValue()
        {
            return Value ?? "";
        }
    }
}
