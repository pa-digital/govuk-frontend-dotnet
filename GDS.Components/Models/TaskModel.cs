namespace GDS.Components.Models
{
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;

    public class TaskModel
    {
        public BaseUrlModel Link { get; set; }
        public IHtmlContent Hint { get; set; }
        public string Status { get; set; }
        public TagViewModel Tag { get; set; }
    }
}
