namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class TabViewModelTests
    {
        [Test]
        public void TabViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.TabViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void TabViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.TabViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var titleProperty = model.GetProperty("Title");
            titleProperty.ShouldNotBeNull();
            titleProperty.PropertyType.ShouldBe(typeof(string));

            var tabsProperty = model.GetProperty("Tabs");
            tabsProperty.ShouldNotBeNull();
            tabsProperty.PropertyType.Name.ShouldBe("IList`1");
            tabsProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("TabContentModel");
        }

        [Test]
        public void TabViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new TabViewModel();

            //Assert
            model.Title.ShouldBeNull();
            model.Tabs.Count().ShouldBe(0);
        }

        [Test]
        public void TabViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TabViewModel();

            //Act
            model.Title = "Title";
            model.Tabs = new List<TabContentModel> { new TabContentModel() };

            //Assert
            model.Title.ShouldBe("Title");
            model.Tabs.ShouldNotBeNull();
            model.Tabs.Count().ShouldBe(1);
        }
    }
}
