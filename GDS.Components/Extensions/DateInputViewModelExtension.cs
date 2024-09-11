namespace GDS.Components.Extensions
{
    using GDS.Components.ViewModels;

    public static class DateInputViewModelExtension
    {
        public static DateInputViewModel PopulateDateInputViewModel(DateInputViewModel postedModel, DateInputViewModel resetModel)
        {
            if (postedModel == null)
            {
                postedModel = new DateInputViewModel();
            }

            postedModel.Legend = resetModel.Legend;
            postedModel.QuestionType = resetModel.QuestionType;
            postedModel.Hint = resetModel.Hint;
            postedModel.Error = resetModel.Error;

            return postedModel;
        }
    }
}
