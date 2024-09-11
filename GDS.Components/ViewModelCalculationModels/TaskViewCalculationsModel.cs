namespace GDS.Components.ViewModelCalculationModels
{
    using GDS.Components.Models;
    public class TaskViewCalculationsModel
    {
        public readonly string statusId;
        public readonly string hintId;
        public readonly bool showTag;
        public readonly bool showHint;
        public readonly string ariaTag;

        public TaskViewCalculationsModel(TaskModel model, string baseId, int iterator)
        {
            statusId = $"{baseId}-{iterator}-status";
            hintId = $"{baseId}-{iterator}-hint";
            showTag = model.Tag != null;
            showHint = model.Hint != null;
            ariaTag = statusId;
            if (showHint)
            {
                ariaTag = $"{hintId} {ariaTag}";
            }
        }
    }
}
