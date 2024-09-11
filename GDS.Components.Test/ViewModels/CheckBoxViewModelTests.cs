using GDS.Components.Enum;
using GDS.Components.ViewModels;
using Shouldly;

namespace GDS.Components.Test.ViewModels
{
    [TestFixture]
    public class CheckBoxViewModelTests
    {
        [Test]
        public void CheckBoxViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.CheckBoxViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(8);
        }

        [Test]
        public void CheckBoxViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.CheckBoxViewModel, GDS.Components");

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

            var checkBoxTypeProperty = model.GetProperty("CheckBoxType");
            checkBoxTypeProperty.ShouldNotBeNull();
            checkBoxTypeProperty.PropertyType.ShouldBe(typeof(CheckBoxType));

            var exclusiveProperty = model.GetProperty("Exclusive");
            exclusiveProperty.ShouldNotBeNull();
            exclusiveProperty.PropertyType.ShouldBe(typeof(bool));
        }

        [Test]
        public void CheckBoxViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new CheckBoxViewModel();

            //Assert
            model.Id.ShouldBeNull();
            model.Name.ShouldBeNull();
            model.Value.ShouldBeNull();
            model.Checked.ShouldBeFalse();
            model.Text.ShouldBeNull();
            model.CheckBoxType.ShouldBe(CheckBoxType.CheckBox);
            model.Hint.ShouldBeNull();
            model.Exclusive.ShouldBeFalse();
        }

        [Test]
        public void CheckBoxViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new CheckBoxViewModel();

            //Act
            model.Id = "Id";
            model.Name = "Name";
            model.Value = "Value";
            model.Checked = true;
            model.Text = "Text";
            model.CheckBoxType = CheckBoxType.Divider;
            model.Hint = "Hint";
            model.Exclusive = true;

            //Assert
            model.Id.ShouldBe("Id");
            model.Name.ShouldBe("Name");
            model.Value.ShouldBe("Value");
            model.Checked.ShouldBeTrue();
            model.Text.ShouldBe("Text");
            model.CheckBoxType.ShouldBe(CheckBoxType.Divider);
            model.Hint.ShouldBe("Hint");
            model.Exclusive.ShouldBeTrue();
        }
    }
}
