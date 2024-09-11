namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class BackLinkViewModelTests
    {
        [Test]
        public void BackLinkViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.BackLinkViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void BackLinkViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.BackLinkViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var urlProperty = model.GetProperty("Url");
            urlProperty.ShouldNotBeNull();
            urlProperty.PropertyType.ShouldBe(typeof(string));

            var textProperty = model.GetProperty("Text");
            textProperty.ShouldNotBeNull();
            textProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void BackLinkViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new BackLinkViewModel();

            //Assert
            model.Url.ShouldBeNull();
            model.Text.ShouldBeNull();
        }

        [Test]
        public void BackLinkViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new BackLinkViewModel();

            //Act
            model.Url = "some url";
            model.Text = "some text";

            //Assert
            model.Url.ShouldBe("some url");
            model.Text.ShouldBe("some text");
        }
    }
}
