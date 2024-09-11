namespace GDS.Components.Infrastructure
{
    public interface BaseViewModel
    {
    }

    public interface BaseSingleViewModel : BaseViewModel
    {
        string GetValue();
    }

    public interface BaseOptionViewModel : BaseViewModel
    {
        string GetValue();
        string GetDisplayValue();
    }

    public interface BaseOptionsViewModel : BaseViewModel
    {
        IList<string> GetValues();
        IList<string> GetDisplayValues();
    }

}
