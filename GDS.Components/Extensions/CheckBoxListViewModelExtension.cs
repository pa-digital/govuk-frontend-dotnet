namespace GDS.Components.Extensions
{
    using GDS.Components.ViewModels;

    public static class CheckBoxListViewModelExtension
    {
        public static CheckBoxListViewModel PopulateCheckBoxListViewModel(CheckBoxListViewModel postedModel, CheckBoxListViewModel resetModel)
        {
            if (postedModel == null)
            {
                postedModel = new CheckBoxListViewModel();
            }

            postedModel.Legend = resetModel.Legend;
            postedModel.QuestionType = resetModel.QuestionType;
            postedModel.Hint = resetModel.Hint;
            postedModel.Compact = resetModel.Compact;
            postedModel.Error = resetModel.Error;
            for (int i = 0; i < resetModel.CheckBoxes.Count; i++)
            {
                var resetCheckBox = resetModel.CheckBoxes[i];
                var locatedCheckBox = postedModel.CheckBoxes.Where(x => x.Text == resetCheckBox.Text).FirstOrDefault();
                if(locatedCheckBox != null)
                {
                    locatedCheckBox.Text = resetCheckBox.Text;
                    locatedCheckBox.Value = resetCheckBox.Value;
                    locatedCheckBox.Hint = resetCheckBox.Hint;
                    locatedCheckBox.Id = resetCheckBox.Id;
                    locatedCheckBox.Name = resetCheckBox.Name;
                    locatedCheckBox.CheckBoxType = resetCheckBox.CheckBoxType;
                    locatedCheckBox.Exclusive = resetCheckBox.Exclusive;
                } else
                {
                    postedModel.CheckBoxes.Add(new()
                    {
                        Text = resetCheckBox.Text,
                        Value = resetCheckBox.Value,
                        Hint = resetCheckBox.Hint,
                        Id = resetCheckBox.Id,
                        Name = resetCheckBox.Name,
                        CheckBoxType = resetCheckBox.CheckBoxType,
                        Exclusive = resetCheckBox.Exclusive,
                        Checked = resetCheckBox.Checked,
                    });                    
                } 
            }

            return postedModel;
        }
    }
}
