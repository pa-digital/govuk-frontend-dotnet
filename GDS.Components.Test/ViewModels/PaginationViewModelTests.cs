namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class PaginationViewModelTests
    {
        [Test]
        public void PaginationViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.PaginationViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(8);
        }

        [Test]
        public void PaginationViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.PaginationViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var rootUrlProperty = model.GetProperty("RootUrl");
            rootUrlProperty.ShouldNotBeNull();
            rootUrlProperty.PropertyType.ShouldBe(typeof(string));

            var previousTextProperty = model.GetProperty("PreviousText");
            previousTextProperty.ShouldNotBeNull();
            previousTextProperty.PropertyType.ShouldBe(typeof(string));

            var previousLinkProperty = model.GetProperty("PreviousLink");
            previousLinkProperty.ShouldNotBeNull();
            previousLinkProperty.PropertyType.ShouldBe(typeof(PaginationContentLinkModel));

            var nextTextProperty = model.GetProperty("NextText");
            nextTextProperty.ShouldNotBeNull();
            nextTextProperty.PropertyType.ShouldBe(typeof(string));

            var nextLinkProperty = model.GetProperty("NextLink");
            nextLinkProperty.ShouldNotBeNull();
            nextLinkProperty.PropertyType.ShouldBe(typeof(PaginationContentLinkModel));

            var paginationTypeProperty = model.GetProperty("PaginationType");
            paginationTypeProperty.ShouldNotBeNull();
            paginationTypeProperty.PropertyType.ShouldBe(typeof(PaginationType));

            var maxPageProperty = model.GetProperty("MaxPage");
            maxPageProperty.ShouldNotBeNull();
            maxPageProperty.PropertyType.ShouldBe(typeof(int));

            var currentPageProperty = model.GetProperty("CurrentPage");
            currentPageProperty.ShouldNotBeNull();
            currentPageProperty.PropertyType.ShouldBe(typeof(int));
        }

        [Test]
        public void PaginationViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new PaginationViewModel();

            //Assert
            model.RootUrl.ShouldBeNull();
            model.PreviousText.ShouldBeNull();
            model.PreviousLink.ShouldBeNull();
            model.NextText.ShouldBeNull();
            model.NextLink.ShouldBeNull();
            model.PaginationType.ShouldBe(PaginationType.Numeric);
            model.MaxPage.ShouldBe(0);
            model.CurrentPage.ShouldBe(0);
        }

        [Test]
        public void PaginationViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new PaginationViewModel();

            //Act
            model.RootUrl = "RootUrl";
            model.PreviousText = "Previous";
            model.PreviousLink = new PaginationContentLinkModel { Url = "Url", Text = "Text", Label="Label" };
            model.NextText = "Next";
            model.NextLink = new PaginationContentLinkModel
            {
                Url = "Url",
                Text = "Text",
                Label = "Label"
            };
            model.PaginationType = PaginationType.Content;
            model.MaxPage = 10;
            model.CurrentPage = 3;

            //Assert
            model.RootUrl.ShouldBe("RootUrl");
            model.PreviousText.ShouldBe("Previous");
            model.PreviousLink.ShouldNotBeNull();
            model.NextText.ShouldBe("Next");
            model.NextLink.ShouldNotBeNull();
            model.MaxPage.ShouldBe(10);
            model.CurrentPage.ShouldBe(3);
        }
    }
}
