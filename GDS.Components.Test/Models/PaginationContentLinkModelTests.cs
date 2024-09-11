namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using Shouldly;

    [TestFixture]
    public class PaginationContentLinkModelTests
    {
        [Test]
        public void PaginationContentLinkModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.PaginationContentLinkModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void PaginationContentLinkModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.PaginationContentLinkModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var urlProperty = model.GetProperty("Url");
            urlProperty.ShouldNotBeNull();
            urlProperty.PropertyType.ShouldBe(typeof(string));

            var textProperty = model.GetProperty("Text");
            textProperty.ShouldNotBeNull();
            textProperty.PropertyType.ShouldBe(typeof(string));

            var labelProperty = model.GetProperty("Label");
            labelProperty.ShouldNotBeNull();
            labelProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void PaginationContentLinkModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new PaginationContentLinkModel();

            //Assert
            model.Url.ShouldBeNull();
            model.Text.ShouldBeNull();
            model.Label.ShouldBeNull();
        }

        [Test]
        public void PaginationContentLinkModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new PaginationContentLinkModel();

            //Act
            model.Url = "someurl";
            model.Text = "sometext";
            model.Label = "somelabel";

            //Assert
            model.Url.ShouldBe("someurl");
            model.Text.ShouldBe("sometext");
            model.Label.ShouldBe("somelabel");
        }
    }
}
