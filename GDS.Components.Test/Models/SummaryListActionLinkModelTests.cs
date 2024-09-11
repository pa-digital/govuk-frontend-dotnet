namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using Shouldly;

    [TestFixture]
    public class SummaryListActionLinkModelTests
    {
        [Test]
        public void SummaryListActionLinkModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.SummaryListActionLinkModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void SummaryListActionLinkModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.SummaryListActionLinkModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var urlProperty = model.GetProperty("Url");
            urlProperty.ShouldNotBeNull();
            urlProperty.PropertyType.ShouldBe(typeof(string));

            var textProperty = model.GetProperty("Text");
            textProperty.ShouldNotBeNull();
            textProperty.PropertyType.ShouldBe(typeof(string));

            var actionContextProperty = model.GetProperty("ActionContext");
            actionContextProperty.ShouldNotBeNull();
            actionContextProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void SummaryListActionLinkModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new SummaryListActionLinkModel();

            //Assert
            model.Url.ShouldBeNull();
            model.Text.ShouldBeNull();
            model.ActionContext.ShouldBeNull();
        }

        [Test]
        public void SummaryListActionLinkModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new SummaryListActionLinkModel();

            //Act
            model.Url = "someurl";
            model.Text = "sometext";
            model.ActionContext = "context";

            //Assert
            model.Url.ShouldBe("someurl");
            model.Text.ShouldBe("sometext");
            model.ActionContext.ShouldBe("context");
        }
    }
}
