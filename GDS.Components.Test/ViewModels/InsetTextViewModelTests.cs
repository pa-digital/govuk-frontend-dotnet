namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class InsetTextViewModelTests
    {
        [Test]
        public void InsetTextViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.InsetTextViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(1);
        }

        [Test]
        public void InsetTextViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.InsetTextViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var contentProperty = model.GetProperty("Content");
            contentProperty.ShouldNotBeNull();
            contentProperty.PropertyType.ShouldBe(typeof(IHtmlContent));
        }

        [Test]
        public void InsetTextViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new InsetTextViewModel();

            //Assert
            model.Content.ShouldBeNull();
        }

        [Test]
        public void InsetTextViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new InsetTextViewModel();

            //Act
            model.Content = new HtmlString("some content");

            //Assert
            model.Content.ToString().ShouldBe("some content");
        }
    }
}
