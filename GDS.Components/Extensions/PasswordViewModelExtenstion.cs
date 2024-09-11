namespace GDS.Components.Extensions
{
    using GDS.Components.ViewModels;

    public static class PasswordViewModelExtenstion
    {
        public static PasswordViewModel PopulatePasswordViewModel(PasswordViewModel postedModel, PasswordViewModel resetModel)
        {
            if (postedModel == null)
            {
                postedModel = new PasswordViewModel();
            }

            postedModel.Label = resetModel.Label;
            postedModel.QuestionType = resetModel.QuestionType;
            postedModel.Hint = resetModel.Hint;
            postedModel.Error = resetModel.Error;

            return postedModel;
        }
    }
}
