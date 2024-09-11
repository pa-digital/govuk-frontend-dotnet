namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class SummaryCardListViewModelTests
    {
        [Test]
        public void SummaryCardListViewModellHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.SummaryCardListViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(1);
        }

        [Test]
        public void SummaryCardListViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.SummaryCardListViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var cardsProperty = model.GetProperty("Cards");
            cardsProperty.ShouldNotBeNull();
            cardsProperty.PropertyType.Name.ShouldBe("IList`1");
            cardsProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("SummaryCardModel");

        }

        [Test]
        public void SummaryCardListViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new SummaryCardListViewModel();

            //Assert
            model.Cards.ShouldNotBeNull();
            model.Cards.Count().ShouldBe(0);
        }

        [Test]
        public void SummaryCardListViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new SummaryCardListViewModel();

            //Act
            model.Cards = new List<SummaryCardModel> { new SummaryCardModel { Header = "Header", Content = new() } };

            //Assert
            model.Cards.ShouldNotBeNull();
            model.Cards.Count().ShouldBe(1);
        }
    }
}
