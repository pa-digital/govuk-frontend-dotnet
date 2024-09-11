namespace GDS.Components.ViewModels
{
    public class AccordionListViewModel
    {
        public string Id { get; set; }
        public IList<AccordionElementViewModel> Elements { get; set; }
        public string HeaderShowAllText { get; set; }
        public string HeaderHideAllText { get; set; }
        public bool ShowAllByDefault { get; set; }

        public AccordionListViewModel()
        {
            Elements = new List<AccordionElementViewModel>();
        }
    }
}
