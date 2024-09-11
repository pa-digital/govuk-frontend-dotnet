namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class PhaseBannerViewModelTests
    {
        [Test]
        public void PhaseBannerViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.PhaseBannerViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void PhaseBannerViewModelModeHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.PhaseBannerViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var phaseProperty = model.GetProperty("Phase");
            phaseProperty.ShouldNotBeNull();
            phaseProperty.PropertyType.ShouldBe(typeof(string));

            var bannerContentProperty = model.GetProperty("BannerContent");
            bannerContentProperty.ShouldNotBeNull();
            bannerContentProperty.PropertyType.ShouldBe(typeof(PhaseBannerLinkModel));
        }

        [Test]
        public void PhaseBannerViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new PhaseBannerViewModel();

            //Assert
            model.Phase.ShouldBeNull();
            model.BannerContent.ShouldBeNull();
        }

        [Test]
        public void PhaseBannerViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new PhaseBannerViewModel();

            //Act
            model.Phase = "Phase";
            model.BannerContent = new() { ContextText = new HtmlString("Context"), Url="Url", Text="Text"};

            //Assert
            model.Phase.ShouldBe("Phase");
            model.BannerContent.ShouldNotBeNull();
        }
    }
}
