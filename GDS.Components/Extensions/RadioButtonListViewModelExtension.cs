namespace GDS.Components.Extensions
{
    using GDS.Components.ViewModels;
    public static class RadioButtonListViewModelExtension
    {
        public static RadioButtonListViewModel PopulateRadioButtonListViewModel(RadioButtonListViewModel? postedModel, RadioButtonListViewModel resetModel)
        {
            if (postedModel == null)
            {
                postedModel = new RadioButtonListViewModel();
            }

            postedModel.Legend = resetModel.Legend;
            postedModel.QuestionType = resetModel.QuestionType;
            postedModel.Hint = resetModel.Hint;
            postedModel.Compact = resetModel.Compact;
            postedModel.Inline = resetModel.Inline;
            postedModel.Error = resetModel.Error;
            postedModel.RadioButtons.Clear();

            var selectedRadioButton = resetModel.RadioButtons.Where(x => x.Value == postedModel.SelectedValue).FirstOrDefault();
            for (int i = 0; i < resetModel.RadioButtons.Count; i++)
            {
                var resetRadioButton = resetModel.RadioButtons[i];
                if (selectedRadioButton != null && selectedRadioButton.Value == resetRadioButton.Value)
                {
                    var checkedRadioButton = new RadioButtonViewModel
                    {
                        Text = resetRadioButton.Text,
                        Value = resetRadioButton.Value,
                        Hint = resetRadioButton.Hint,
                        Id = resetRadioButton.Id,
                        Name = resetRadioButton.Name,
                        Checked = true,
                    };
                    postedModel.RadioButtons.Insert(i, checkedRadioButton);
                }
                else
                {
                    postedModel.RadioButtons.Add(new()
                    {
                        Text = resetRadioButton.Text,
                        Value = resetRadioButton.Value,
                        Hint = resetRadioButton.Hint,
                        Id = resetRadioButton.Id,
                        Name = resetRadioButton.Name,
                        Checked = resetRadioButton.Checked,
                    });
                }
            }

            return postedModel;
        }
    }
}
