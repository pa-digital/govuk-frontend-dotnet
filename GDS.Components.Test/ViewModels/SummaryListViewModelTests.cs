namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class SummaryListViewModelTests
    {
        [Test]
        public void SummaryListViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.SummaryListViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void SummaryListViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.SummaryListViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var itemsProperty = model.GetProperty("Items");
            itemsProperty.ShouldNotBeNull();
            itemsProperty.PropertyType.Name.ShouldBe("IList`1");
            itemsProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("SummaryListItemModel");

            var hideBordersProperty = model.GetProperty("HideBorders");
            hideBordersProperty.ShouldNotBeNull();
            hideBordersProperty.PropertyType.ShouldBe(typeof(bool));

            var topLevelBorderClassProperty = model.GetProperty("TopLevelBorderClass");
            topLevelBorderClassProperty.ShouldNotBeNull();
            topLevelBorderClassProperty.PropertyType.ShouldBe(typeof(string));

        }

        [Test]
        public void SummaryListViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new SummaryListViewModel();

            //Assert
            model.Items.ShouldNotBeNull();
            model.Items.Count().ShouldBe(0);
            model.HideBorders.ShouldBeFalse();
            model.TopLevelBorderClass.ShouldBe("govuk-summary-list");
        }

        [Test]
        public void SummaryListViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new SummaryListViewModel();

            //Act
            model.Items = new List<SummaryListItemModel> { new SummaryListItemModel() };
            model.HideBorders = true;

            //Assert
            model.Items.ShouldNotBeNull();
            model.Items.Count().ShouldBe(1);
            model.HideBorders.ShouldBeTrue();
            model.TopLevelBorderClass.ShouldBe("govuk-summary-list govuk-summary-list--no-border");
        }
    }
}
