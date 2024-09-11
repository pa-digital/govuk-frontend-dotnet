namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class AccordionListViewModelTests
    {
        [Test]
        public void AccordionListViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.AccordionListViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(5);
        }

        [Test]
        public void AccordionListViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.AccordionListViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var idProperty = model.GetProperty("Id");
            idProperty.ShouldNotBeNull();
            idProperty.PropertyType.ShouldBe(typeof(string));

            var elementsProperty = model.GetProperty("Elements");
            elementsProperty.ShouldNotBeNull();
            elementsProperty.PropertyType.Name.ShouldBe("IList`1");
            elementsProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("AccordionElementViewModel");

            var headerShowAllTextProperty = model.GetProperty("HeaderShowAllText");
            headerShowAllTextProperty.ShouldNotBeNull();
            headerShowAllTextProperty.PropertyType.ShouldBe(typeof(string));

            var headerHideAllTextProperty = model.GetProperty("HeaderHideAllText");
            headerHideAllTextProperty.ShouldNotBeNull();
            headerHideAllTextProperty.PropertyType.ShouldBe(typeof(string));

            var showAllByDefaultProperty = model.GetProperty("ShowAllByDefault");
            showAllByDefaultProperty.ShouldNotBeNull();
            showAllByDefaultProperty.PropertyType.ShouldBe(typeof(bool));
        }

        [Test]
        public void AccordionListViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new AccordionListViewModel();

            //Assert
            model.Id.ShouldBeNull();
            model.Elements.ShouldNotBeNull();
            model.Elements.Count().ShouldBe(0);
            model.HeaderShowAllText.ShouldBeNull();
            model.HeaderHideAllText.ShouldBeNull();
            model.ShowAllByDefault.ShouldBeFalse();
        }

        [Test]
        public void AccordionListViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new AccordionListViewModel();

            //Act
            model.Id = "Id";
            model.Elements = new List<AccordionElementViewModel> { new AccordionElementViewModel { ShowByDefault = true, Header = "Header", Content = "Content" } };
            model.HeaderShowAllText = "show header";
            model.HeaderHideAllText = "hide header";
            model.ShowAllByDefault = true;

            //Assert
            model.Id.ShouldBe("Id");
            model.Elements.ShouldNotBeNull();
            model.Elements.Count().ShouldBe(1);
            model.HeaderShowAllText.ShouldBe("show header");
            model.HeaderHideAllText.ShouldBe("hide header");
            model.ShowAllByDefault.ShouldBeTrue();
        }
    }
}
