namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class BreadcrumbsViewModelTests
    {
        [Test]
        public void BreadcrumbsViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.BreadcrumbsViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(4);
        }

        [Test]
        public void BreadcrumbsViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.BreadcrumbsViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var labelProperty = model.GetProperty("Label");
            labelProperty.ShouldNotBeNull();
            labelProperty.PropertyType.ShouldBe(typeof(string));

            var breadcrumbTypeProperty = model.GetProperty("BreadcrumbType");
            breadcrumbTypeProperty.ShouldNotBeNull();
            breadcrumbTypeProperty.PropertyType.ShouldBe(typeof(BreadcrumbType));

            var linksProperty = model.GetProperty("Links");
            linksProperty.ShouldNotBeNull();
            linksProperty.PropertyType.Name.ShouldBe("IList`1");
            linksProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("BaseUrlModel");

            var wrapperClassNameProperty = model.GetProperty("WrapperClassName");
            wrapperClassNameProperty.ShouldNotBeNull();
            wrapperClassNameProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void BreadcrumbsViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new BreadcrumbsViewModel();

            //Assert
            model.Label.ShouldBeNull();
            model.BreadcrumbType.ShouldBe(BreadcrumbType.Default);
            model.Links.ShouldNotBeNull();
            model.Links.Count().ShouldBe(0);
            model.WrapperClassName.ShouldBe("govuk-breadcrumbs");
        }

        [Test]
        public void BreadcrumbsViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new BreadcrumbsViewModel();

            //Act
            model.Label = "label";
            model.BreadcrumbType = BreadcrumbType.Inverse;
            model.Links = new List<BaseUrlModel> { new BaseUrlModel { Url = "Url", Text = "Text" } };

            //Assert
            model.Label.ShouldBe("label");
            model.BreadcrumbType.ShouldBe(BreadcrumbType.Inverse);
            model.Links.ShouldNotBeNull();
            model.Links.Count().ShouldBe(1);
            model.WrapperClassName.ShouldBe("govuk-breadcrumbs govuk-breadcrumbs--inverse");
        }
    }
}
