namespace GDS.Components.ViewModels
{
    using GDS.Components.Models;

    public class ErrorSummaryViewModel
    {
        public string Title { get; set; }
        public IList<BaseUrlModel> Errors { get; set; }
        public ErrorSummaryViewModel()
        {
            Errors = new List<BaseUrlModel>();
        }
    }
}
