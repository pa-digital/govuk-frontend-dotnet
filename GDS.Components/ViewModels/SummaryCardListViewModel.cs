namespace GDS.Components.ViewModels
{
    using GDS.Components.Models;

    public class SummaryCardListViewModel
    {
        public IList<SummaryCardModel> Cards { get; set; }
        public SummaryCardListViewModel()
        {
            Cards = new List<SummaryCardModel>();
        }
    }
}
