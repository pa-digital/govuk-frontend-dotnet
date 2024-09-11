namespace GDS.Components.Test.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class TaskModelTests
    {
        [Test]
        public void TaskModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.TaskModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(4);
        }

        [Test]
        public void TaskModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.TaskModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var linkProperty = model.GetProperty("Link");
            linkProperty.ShouldNotBeNull();
            linkProperty.PropertyType.ShouldBe(typeof(BaseUrlModel));

            var hintProperty = model.GetProperty("Hint");
            hintProperty.ShouldNotBeNull();
            hintProperty.PropertyType.ShouldBe(typeof(IHtmlContent));

            var statusProperty = model.GetProperty("Status");
            statusProperty.ShouldNotBeNull();
            statusProperty.PropertyType.ShouldBe(typeof(string));

            var tagProperty = model.GetProperty("Tag");
            tagProperty.ShouldNotBeNull();
            tagProperty.PropertyType.ShouldBe(typeof(TagViewModel));
        }

        [Test]
        public void TaskModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new TaskModel();

            //Assert
            model.Link.ShouldBeNull();
            model.Hint.ShouldBeNull();
            model.Status.ShouldBeNull();
            model.Tag.ShouldBeNull();
        }

        [Test]
        public void TaskModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TaskModel();

            //Act
            model.Link = new BaseUrlModel
            {
                Text = "Text",
                Url = "Url"
            };
            model.Hint = new HtmlString("Hint");
            model.Status = "status";
            model.Tag = new TagViewModel
            {
                Text = "Tag Text",
                TagType = TagType.Grey
            };

            //Assert
            model.Link.ShouldNotBeNull();
            model.Link.Text.ShouldBe("Text");
            model.Link.Url.ShouldBe("Url");
            model.Hint.ToString().ShouldBe("Hint");
            model.Status.ShouldBe("status");
            model.Tag.ShouldNotBeNull();
            model.Tag.Text.ShouldBe("Tag Text");
            model.Tag.TagType.ShouldBe(TagType.Grey);
        }
    }
}
