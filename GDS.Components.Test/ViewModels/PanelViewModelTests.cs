namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class PanelViewModelTests
    {
        [Test]
        public void PanelViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.PanelViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void PanelViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.PanelViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var headerProperty = model.GetProperty("Header");
            headerProperty.ShouldNotBeNull();
            headerProperty.PropertyType.ShouldBe(typeof(IHtmlContent));

            var contentProperty = model.GetProperty("Content");
            contentProperty.ShouldNotBeNull();
            contentProperty.PropertyType.ShouldBe(typeof(IHtmlContent));
        }

        [Test]
        public void PanelViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new PanelViewModel();

            //Assert
            model.Header.ShouldBeNull();
            model.Content.ShouldBeNull();
        }

        [Test]
        public void PanelViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new PanelViewModel();

            //Act
            model.Header = new HtmlString("Header");
            model.Content = new HtmlString("Content");

            //Assert
            model.Header.ToString().ShouldBe("Header");
            model.Content.ToString().ShouldBe("Content");
        }
    }
}
