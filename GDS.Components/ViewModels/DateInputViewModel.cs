namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Models;

    public class DateInputViewModel
    {
        public string Legend { get; set; }
        public InputMultiQuestionType QuestionType { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Hint { get; set; }
        public string Error { get; set; }
        public DateInputErrorType ErrorType { get; set; }

        public DateConstructorModel GetValues()
        {
            return new DateConstructorModel(Day, Month, Year);
        }
    }
}
