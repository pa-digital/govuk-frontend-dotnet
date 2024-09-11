namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Infrastructure;

    public class CheckBoxListViewModel : BaseOptionsViewModel
    {
        public string Legend { get; set; }
        public IList<CheckBoxViewModel> CheckBoxes { get; set; }
        public InputMultiQuestionType QuestionType { get; set; }
        public string Hint { get; set; }
        public string Error { get; set; }
        public bool Compact { get; set; }

        public CheckBoxListViewModel()
        {
            CheckBoxes = new List<CheckBoxViewModel>();
        }

        public IList<string> GetValues()
        {
            return CheckBoxes.Where(cb => cb.Checked).Select(cb => cb.Value).ToList();
        }

        public IList<string> GetDisplayValues()
        {
            return CheckBoxes.Where(cb => cb.Checked).Select(cb => cb.Text).ToList();
        }
    }
}
