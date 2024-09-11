namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class ErrorSummaryViewModelTests
    {
        [Test]
        public void ErrorSummaryViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.ErrorSummaryViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void ErrorSummaryViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.ErrorSummaryViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var titleProperty = model.GetProperty("Title");
            titleProperty.ShouldNotBeNull();
            titleProperty.PropertyType.ShouldBe(typeof(string));

            var errorsProperty = model.GetProperty("Errors");
            errorsProperty.ShouldNotBeNull();
            errorsProperty.PropertyType.Name.ShouldBe("IList`1");
            errorsProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("BaseUrlModel");
        }

        [Test]
        public void ErrorSummaryViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new ErrorSummaryViewModel();

            //Assert
            model.Title.ShouldBeNull();
            model.Errors.ShouldNotBeNull();
            model.Errors.Count().ShouldBe(0);
        }

        [Test]
        public void ErrorSummaryViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new ErrorSummaryViewModel();

            //Act
            model.Title = "Title";
            model.Errors = new List<BaseUrlModel> { new BaseUrlModel { Url = "url", Text = "Text" } };

            //Assert
            model.Title.ShouldBe("Title");
            model.Errors.ShouldNotBeNull();
            model.Errors.Count().ShouldBe(1);
        }
    }
}
