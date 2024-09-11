namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class WarningViewModelTests
    {
        [Test]
        public void WarningViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.WarningViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(1);
        }

        [Test]
        public void WarningViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.WarningViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var contentProperty = model.GetProperty("Content");
            contentProperty.ShouldNotBeNull();
            contentProperty.PropertyType.ShouldBe(typeof(IHtmlContent));
        }

        [Test]
        public void WarningViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new WarningViewModel();

            //Assert
            model.Content.ShouldBeNull();
        }

        [Test]
        public void WarningViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new WarningViewModel();

            //Act
            model.Content = new HtmlString("Content");

            //Assert
            model.Content.ToString().ShouldBe("Content");
        }
    }
}
