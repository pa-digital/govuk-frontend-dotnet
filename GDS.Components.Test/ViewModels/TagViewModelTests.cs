namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class TagViewModelTests
    {
        [Test]
        public void TagViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.TagViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void TagViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.TagViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var tagTypeProperty = model.GetProperty("TagType");
            tagTypeProperty.ShouldNotBeNull();
            tagTypeProperty.PropertyType.ShouldBe(typeof(TagType));

            var tabsProperty = model.GetProperty("Text");
            tabsProperty.ShouldNotBeNull();
            tabsProperty.PropertyType.ShouldBe(typeof(string));

            var tagClassNameProperty = model.GetProperty("TagClassName");
            tagClassNameProperty.ShouldNotBeNull();
            tagClassNameProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void TagViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new TagViewModel();

            //Assert
            model.TagType.ShouldBe(TagType.Default);
            model.Text.ShouldBeNull();
            model.TagClassName.ShouldBe("govuk-tag");
        }

        [Test]
        public void TagViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TagViewModel();

            //Act
            model.TagType = TagType.Green;
            model.Text = "Text";

            //Assert
            model.TagType.ShouldBe(TagType.Green);
            model.Text.ShouldBe("Text");
            model.TagClassName.ShouldBe("govuk-tag govuk-tag--green");
        }
    }
}
