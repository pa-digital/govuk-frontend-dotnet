namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class DetailsViewModelTests
    {
        [Test]
        public void DetailsViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.DetailsViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void DetailsViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.DetailsViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var headerProperty = model.GetProperty("Header");
            headerProperty.ShouldNotBeNull();
            headerProperty.PropertyType.ShouldBe(typeof(string));

            var contentHtmlProperty = model.GetProperty("ContentHtml");
            contentHtmlProperty.ShouldNotBeNull();
            contentHtmlProperty.PropertyType.ShouldBe(typeof(IHtmlContent));
        }

        [Test]
        public void DetailsViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new DetailsViewModel();

            //Assert
            model.Header.ShouldBeNull();
            model.ContentHtml.ShouldBeNull();
        }

        [Test]
        public void DetailsViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new DetailsViewModel();

            //Act
            model.Header = "Header";
            model.ContentHtml = new HtmlString("Content");

            //Assert
            model.Header.ShouldBe("Header");
            model.ContentHtml.ToString().ShouldBe("Content");
        }
    }
}
