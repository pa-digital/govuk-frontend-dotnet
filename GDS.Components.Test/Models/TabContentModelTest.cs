namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class TabContentModelTest
    {
        [Test]
        public void TabContentModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.TabContentModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void TabContentModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.TabContentModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var headerProperty = model.GetProperty("TabHeader");
            headerProperty.ShouldNotBeNull();
            headerProperty.PropertyType.ShouldBe(typeof(string));

            var contentProperty = model.GetProperty("TabContent");
            contentProperty.ShouldNotBeNull();
            contentProperty.PropertyType.ShouldBe(typeof(IHtmlContent));
        }

        [Test]
        public void TabContentModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new TabContentModel();

            //Assert
            model.TabHeader.ShouldBeNull();
            model.TabContent.ShouldBeNull();
        }

        [Test]
        public void TabContentModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TabContentModel();

            //Act
            model.TabHeader = "header";
            model.TabContent = new HtmlString("content");

            //Assert
            model.TabHeader.ShouldBe("header");
            model.TabContent.ToString().ShouldBe("content");
        }
    }
}
