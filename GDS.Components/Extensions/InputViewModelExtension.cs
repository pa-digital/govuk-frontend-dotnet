namespace GDS.Components.Extensions
{
    using GDS.Components.ViewModels;

    public static class InputViewModelExtension
    {
        public static InputViewModel PopulateInputViewModel(InputViewModel postedModel, InputViewModel resetModel)
        {
            if (postedModel == null)
            {
                postedModel = new InputViewModel();
            }

            postedModel.Label = resetModel.Label;
            postedModel.QuestionType = resetModel.QuestionType;
            postedModel.InputType = resetModel.InputType;
            postedModel.Hint = resetModel.Hint;
            postedModel.Error = resetModel.Error;

            return postedModel;
        }

    }
}
