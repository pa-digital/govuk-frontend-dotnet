namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using Shouldly;

    [TestFixture]
    public class BaseUrlModelTest
    {
        [Test]
        public void BaseUrlModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.BaseUrlModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void BaseUrlModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.BaseUrlModel, GDS.Components");

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
        public void BaseUrlModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new BaseUrlModel();
           
            //Assert
            model.Url.ShouldBeNull();
            model.Text.ShouldBeNull();
        }

        [Test]
        public void BaseUrlModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new BaseUrlModel();

            //Act
            model.Url = "someurl";
            model.Text = "sometext";

            //Assert
            model.Url.ShouldBe("someurl");
            model.Text.ShouldBe("sometext");
        }
    }
}
