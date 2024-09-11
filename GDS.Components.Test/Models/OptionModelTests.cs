namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using Shouldly;

    [TestFixture]
    public class OptionModelTests
    {
        [Test]
        public void OptionModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.OptionModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void OptionModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.OptionModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var valueProperty = model.GetProperty("Value");
            valueProperty.ShouldNotBeNull();
            valueProperty.PropertyType.ShouldBe(typeof(string));

            var textProperty = model.GetProperty("Text");
            textProperty.ShouldNotBeNull();
            textProperty.PropertyType.ShouldBe(typeof(string));

            var selectedtProperty = model.GetProperty("Selected");
            selectedtProperty.ShouldNotBeNull();
            selectedtProperty.PropertyType.ShouldBe(typeof(bool));
        }

        [Test]
        public void OptionModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new OptionModel();

            //Assert
            model.Value.ShouldBeNull();
            model.Text.ShouldBeNull();
            model.Selected.ShouldBeFalse();
        }
    }
}
