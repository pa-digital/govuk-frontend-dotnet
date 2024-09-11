namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class RadioButtonViewModelTests
    {
        [Test]
        public void RadioButtonViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.RadioButtonViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(8);
        }

        [Test]
        public void RadioButtonViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.RadioButtonViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var idProperty = model.GetProperty("Id");
            idProperty.ShouldNotBeNull();
            idProperty.PropertyType.ShouldBe(typeof(string));

            var nameProperty = model.GetProperty("Name");
            nameProperty.ShouldNotBeNull();
            nameProperty.PropertyType.ShouldBe(typeof(string));

            var valueProperty = model.GetProperty("Value");
            valueProperty.ShouldNotBeNull();
            valueProperty.PropertyType.ShouldBe(typeof(string));

            var checkedProperty = model.GetProperty("Checked");
            checkedProperty.ShouldNotBeNull();
            checkedProperty.PropertyType.ShouldBe(typeof(bool));

            var textProperty = model.GetProperty("Text");
            textProperty.ShouldNotBeNull();
            textProperty.PropertyType.ShouldBe(typeof(string));

            var hintProperty = model.GetProperty("Hint");
            hintProperty.ShouldNotBeNull();
            hintProperty.PropertyType.ShouldBe(typeof(string));

            var radioButtonTypeProperty = model.GetProperty("RadioButtonType");
            radioButtonTypeProperty.ShouldNotBeNull();
            radioButtonTypeProperty.PropertyType.ShouldBe(typeof(RadioButtonType));

            var hasHintProperty = model.GetProperty("HasHint");
            hasHintProperty.ShouldNotBeNull();
            hasHintProperty.PropertyType.ShouldBe(typeof(bool));
        }

        [Test]
        public void RadioButtonViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new RadioButtonViewModel();

            //Assert
            model.Id.ShouldBeNull();
            model.Name.ShouldBeNull();
            model.Value.ShouldBeNull();
            model.Checked.ShouldBeFalse();
            model.Text.ShouldBeNull();
            model.RadioButtonType.ShouldBe(RadioButtonType.RadioButton);
            model.Hint.ShouldBeNull();
            model.HasHint.ShouldBeFalse();
        }

        [Test]
        public void RadioButtonViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new RadioButtonViewModel();

            //Act
            model.Id = "Id";
            model.Name = "Name";
            model.Value = "Value";
            model.Checked = true;
            model.Text = "Text";
            model.RadioButtonType = RadioButtonType.Divider;
            model.Hint = "Hint";

            //Assert
            model.Id.ShouldBe("Id");
            model.Name.ShouldBe("Name");
            model.Value.ShouldBe("Value");
            model.Checked.ShouldBeTrue();
            model.Text.ShouldBe("Text");
            model.RadioButtonType.ShouldBe(RadioButtonType.Divider);
            model.Hint.ShouldBe("Hint");
            model.HasHint.ShouldBeTrue();
        }
    }
}
