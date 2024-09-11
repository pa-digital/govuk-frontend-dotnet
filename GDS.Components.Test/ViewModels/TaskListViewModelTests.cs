namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class TaskListViewModelTests
    {
        [Test]
        public void TaskListViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.TaskListViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(1);
        }

        [Test]
        public void TaskListViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.TaskListViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var tasksProperty = model.GetProperty("Tasks");
            tasksProperty.ShouldNotBeNull();
            tasksProperty.PropertyType.Name.ShouldBe("IList`1");
            tasksProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("TaskModel");
        }

        [Test]
        public void TaskListViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new TaskListViewModel();

            //Assert
            model.Tasks.ShouldNotBeNull();
            model.Tasks.Count().ShouldBe(0);
        }

        [Test]
        public void TaskListViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TaskListViewModel();

            //Act
            model.Tasks = new List<TaskModel> { new() };

            //Assert
            model.Tasks.ShouldNotBeNull();
            model.Tasks.Count().ShouldBe(1);
        }
    }
}
