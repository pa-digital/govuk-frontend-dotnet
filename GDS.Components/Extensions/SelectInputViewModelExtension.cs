namespace GDS.Components.Extensions
{
    using GDS.Components.ViewModels;
    public static class SelectInputViewModelExtension
    {
        public static SelectViewModel PopulateSelectViewModel(SelectViewModel postedModel, SelectViewModel resetModel)
        {
            if (postedModel == null)
            {
                postedModel = new SelectViewModel();
            }

            postedModel.Label = resetModel.Label;
            postedModel.QuestionType = resetModel.QuestionType;
            postedModel.Hint = resetModel.Hint;
            postedModel.Options = resetModel.Options;

            var selectedOption = postedModel.Options.FirstOrDefault(option => option.Value == postedModel.Value);
            if (selectedOption != null)
            {
                selectedOption.Selected = true;
            }

            return postedModel;
        }
    }
}
