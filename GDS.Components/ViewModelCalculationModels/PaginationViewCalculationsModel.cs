namespace GDS.Components.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;

    public class PaginationViewCalculationsModel
    {
        public readonly bool showPrevious;
        public readonly string previousLink;
        public readonly bool showNext;
        public readonly string nextLink;
        public readonly bool showPrevElipses;
        public readonly bool showNextElipses;
        public readonly string firstPageUrl;
        public readonly string lastPageUrl;
        public readonly int iteratorMin;
        public readonly int iteratorMax;
        public readonly string firstPageClass;
        public readonly string lastPageClass;
        public readonly bool numericMode;

        public PaginationViewCalculationsModel(PaginationViewModel model)
        {
            showPrevious = model.CurrentPage > 1;
            previousLink = $"{model.RootUrl}{model.CurrentPage - 1}";
            showNext = model.CurrentPage < model.MaxPage;
            nextLink = $"{model.RootUrl}{model.CurrentPage + 1}";
            showPrevElipses = false;
            showNextElipses = false;
            firstPageUrl = $"{model.RootUrl}1";
            lastPageUrl = $"{model.RootUrl}{model.MaxPage}";
            iteratorMin = 2;
            iteratorMax = model.CurrentPage + 1;
            firstPageClass = model.CurrentPage == 1 ? "govuk-pagination__item govuk-pagination__item--current" : "govuk-pagination__item";
            lastPageClass = model.CurrentPage == model.MaxPage ? "govuk-pagination__item govuk-pagination__item--current" : "govuk-pagination__item";
            numericMode = model.PaginationType == PaginationType.Numeric;
            if (model.CurrentPage >= 5)
            {
                showPrevElipses = true;
                iteratorMin = model.CurrentPage - 1;
            }
            if (model.MaxPage > model.CurrentPage + 2)
            {
                showNextElipses = true;
            }
            if (model.CurrentPage >= model.MaxPage - 5 && model.MaxPage > 5)
            {
                showNextElipses = model.MaxPage - model.CurrentPage > 2;
                iteratorMin = model.CurrentPage - 1;
                iteratorMax = model.CurrentPage + (model.MaxPage - model.CurrentPage) - 1;
                if (showNextElipses) iteratorMax = model.CurrentPage + 1;
            }
            if (model.CurrentPage == model.MaxPage && model.MaxPage > 5)
            {
                showNextElipses = false;
                showPrevElipses = true;
                iteratorMin = model.CurrentPage - 1;
                iteratorMax = model.CurrentPage - 1;
            }
            if (iteratorMax >= model.MaxPage)
            {
                iteratorMax = model.MaxPage - 1;
            }
            if (model.MaxPage <= model.CurrentPage)
            {
                showNext = false;
                nextLink = null;
            }
            if (!showPrevious)
            {
                showPrevious = false;
                previousLink = null;
            }
        }
    }
}
