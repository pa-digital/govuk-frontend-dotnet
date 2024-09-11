namespace GDS.Components.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Models;

    public class PaginationViewModel
    {
        public string RootUrl { get; set; }
        public string PreviousText { get; set; }
        public PaginationContentLinkModel PreviousLink { get; set; }
        public string NextText { get; set; }
        public PaginationContentLinkModel NextLink { get; set; }
        public PaginationType PaginationType { get; set; }
        public int MaxPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
