namespace GDS.Components.ViewModels
{
    using GDS.Components.Models;

    public class TabViewModel
    {
        public string Title { get; set; }
        public IList<TabContentModel> Tabs { get; set; }

        public TabViewModel()
        {
            Tabs = new List<TabContentModel>();
        }
    }
}
