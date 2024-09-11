namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.ViewModels;
    using Shouldly;
    [TestFixture]
    public class AccordionElementViewModelTests
    {

        [Test]
        public void AccordionElementViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.AccordionElementViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void AccordionElementViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.AccordionElementViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var showByDefaultProperty = model.GetProperty("ShowByDefault");
            showByDefaultProperty.ShouldNotBeNull();
            showByDefaultProperty.PropertyType.ShouldBe(typeof(bool));

            var headerProperty = model.GetProperty("Header");
            headerProperty.ShouldNotBeNull();
            headerProperty.PropertyType.ShouldBe(typeof(string));

            var contentProperty = model.GetProperty("Content");
            contentProperty.ShouldNotBeNull();
            contentProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void AccordionElementViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new AccordionElementViewModel();

            //Assert
            model.ShowByDefault.ShouldBeFalse();
            model.Header.ShouldBeNull();
            model.Content.ShouldBeNull();
        }

        [Test]
        public void AccordionElementViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new AccordionElementViewModel();

            //Act
            model.ShowByDefault = true;
            model.Header = "some header";
            model.Content = "some content";

            //Assert
            model.ShowByDefault.ShouldBeTrue();
            model.Header.ShouldBe("some header");
            model.Content.ShouldBe("some content");
        }
    }
}
