namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class PhaseBannerLinkModelTests
    {
        [Test]
        public void PhaseBannerLinkModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.PhaseBannerLinkModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void PhaseBannerLinkModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.PhaseBannerLinkModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var urlProperty = model.GetProperty("Url");
            urlProperty.ShouldNotBeNull();
            urlProperty.PropertyType.ShouldBe(typeof(string));

            var textProperty = model.GetProperty("Text");
            textProperty.ShouldNotBeNull();
            textProperty.PropertyType.ShouldBe(typeof(string));

            var contentProperty = model.GetProperty("ContextText");
            contentProperty.ShouldNotBeNull();
            contentProperty.PropertyType.ShouldBe(typeof(IHtmlContent));
        }

        [Test]
        public void PhaseBannerLinkModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new PhaseBannerLinkModel();

            //Assert
            model.Url.ShouldBeNull();
            model.Text.ShouldBeNull();
            model.ContextText.ShouldBeNull();
        }

        [Test]
        public void PhaseBannerLinkModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new PhaseBannerLinkModel();

            //Act
            model.Url = "someurl";
            model.Text = "sometext";
            model.ContextText = new HtmlString("context");

            //Assert
            model.Url.ShouldBe("someurl");
            model.Text.ShouldBe("sometext");
            model.ContextText.ToString().ShouldBe("context");
        }
    }
}
