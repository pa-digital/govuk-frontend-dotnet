namespace GDS.Components.Test.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using GDS.Components.ViewModelCalculationModels;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class TaskViewCalculationsModelTests
    {
        [Test]
        public void TaskViewCalculationsModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.TaskViewCalculationsModel, GDS.Components");

            // Assert
            model.ShouldNotBeNull();
            model.GetFields().Length.ShouldBe(5);
        }

        [Test]
        public void TaskViewCalculationsModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.TaskViewCalculationsModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var statusIdField = model.GetField("statusId");
            statusIdField.ShouldNotBeNull();
            statusIdField.FieldType.ShouldBe(typeof(string));

            var hintIdField = model.GetField("hintId");
            hintIdField.ShouldNotBeNull();
            hintIdField.FieldType.ShouldBe(typeof(string));

            var showTagField = model.GetField("showTag");
            showTagField.ShouldNotBeNull();
            showTagField.FieldType.ShouldBe(typeof(bool));

            var showHintField = model.GetField("showHint");
            showHintField.ShouldNotBeNull();
            showHintField.FieldType.ShouldBe(typeof(bool));

            var ariaTagField = model.GetField("ariaTag");
            ariaTagField.ShouldNotBeNull();
            ariaTagField.FieldType.ShouldBe(typeof(string));
        }

        [TestCaseSource(nameof(TaskViewCalculationsModelInitialisationData))]
        public void TaskViewCalculationsModelHasCorrectInitialisedValues(TaskModel sourceModel, string baseId, int iterator, Dictionary<string, object> expectedValues)
        {
            // Arrange/Act
            var model = new TaskViewCalculationsModel(sourceModel, baseId, iterator);

            //Assert
            model.statusId.ShouldBe(expectedValues["StatusId"]);
            model.hintId.ShouldBe(expectedValues["HintId"]);
            model.showTag.ShouldBe(expectedValues["ShowTag"]);
            model.showHint.ShouldBe(expectedValues["ShowHint"]);
            model.ariaTag.ShouldBe(expectedValues["AriaTag"]);
        }

        public static IEnumerable<TestCaseData> TaskViewCalculationsModelInitialisationData()
        {
            yield return new TestCaseData(new TaskModel(), null, 1, new Dictionary<string, object>{
                    { "StatusId", "-1-status" },
                    { "HintId", "-1-hint" },
                    { "ShowTag", false },
                    { "ShowHint", false },
                    { "AriaTag", "-1-status" }
                });
            yield return new TestCaseData(new TaskModel(), string.Empty, 2, new Dictionary<string, object>{
                    { "StatusId", "-2-status" },
                    { "HintId", "-2-hint" },
                    { "ShowTag", false },
                    { "ShowHint", false },
                    { "AriaTag", "-2-status" }
                });
            yield return new TestCaseData(new TaskModel { Tag = new TagViewModel() }, "baseId", 3, new Dictionary<string, object>{
                    { "StatusId", "baseId-3-status" },
                    { "HintId", "baseId-3-hint" },
                    { "ShowTag", true },
                    { "ShowHint", false },
                    { "AriaTag", "baseId-3-status" }
                });
            yield return new TestCaseData(new TaskModel { Hint = new HtmlString("hint") }, "baseId", 4, new Dictionary<string, object>{
                    { "StatusId", "baseId-4-status" },
                    { "HintId", "baseId-4-hint" },
                    { "ShowTag", false },
                    { "ShowHint", true },
                    { "AriaTag", "baseId-4-hint baseId-4-status" }
                });
        }
    }
}
