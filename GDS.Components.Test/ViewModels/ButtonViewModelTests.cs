

namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class ButtonViewModelTests
    {
        [Test]
        public void ButtonViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.ButtonViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(5);
        }

        [Test]
        public void ButtonViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.ButtonViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var textProperty = model.GetProperty("Text");
            textProperty.ShouldNotBeNull();
            textProperty.PropertyType.ShouldBe(typeof(string));

            var buttonTypeProperty = model.GetProperty("ButtonType");
            buttonTypeProperty.ShouldNotBeNull();
            buttonTypeProperty.PropertyType.ShouldBe(typeof(ButtonType));

            var buttonActionProperty = model.GetProperty("ButtonAction");
            buttonActionProperty.ShouldNotBeNull();
            buttonActionProperty.PropertyType.ShouldBe(typeof(ButtonAction));

            var buttonVerbProperty = model.GetProperty("ButtonVerb");
            buttonVerbProperty.ShouldNotBeNull();
            buttonVerbProperty.PropertyType.ShouldBe(typeof(string));

            var buttonClassProperty = model.GetProperty("ButtonClass");
            buttonClassProperty.ShouldNotBeNull();
            buttonClassProperty.PropertyType.ShouldBe(typeof(string));
        }

        [Test]
        public void ButtonViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new ButtonViewModel();

            //Assert
            model.Text.ShouldBeNull();
            model.ButtonType.ShouldBe(ButtonType.Default);
            model.ButtonAction.ShouldBe(ButtonAction.Button);
            model.ButtonVerb.ShouldBe("button");
            model.ButtonClass.ShouldBe("govuk-button");
        }

        [Test]
        public void ButtonViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new ButtonViewModel();

            //Act
            model.Text = "text";
            model.ButtonType = ButtonType.Warning;
            model.ButtonAction = ButtonAction.Submit;

            //Assert
            model.Text.ShouldBe("text");
            model.ButtonType.ShouldBe(ButtonType.Warning);
            model.ButtonAction.ShouldBe(ButtonAction.Submit);
            model.ButtonVerb.ShouldBe("submit");
            model.ButtonClass.ShouldBe("govuk-button govuk-button--warning");
        }
    }
}
