namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class NotificationBannerViewModelTests
    {
        [Test]
        public void NotificationBannerViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.NotificationBannerViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(10);
        }

        [Test]
        public void NotificationBannerViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.NotificationBannerViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var headerProperty = model.GetProperty("Header");
            headerProperty.ShouldNotBeNull();
            headerProperty.PropertyType.ShouldBe(typeof(string));

            var subHeaderProperty = model.GetProperty("SubHeader");
            subHeaderProperty.ShouldNotBeNull();
            subHeaderProperty.PropertyType.ShouldBe(typeof(string));

            var preLinkContentProperty = model.GetProperty("PreLinkContent");
            preLinkContentProperty.ShouldNotBeNull();
            preLinkContentProperty.PropertyType.ShouldBe(typeof(IHtmlContent));

            var linkProperty = model.GetProperty("Link");
            linkProperty.ShouldNotBeNull();
            linkProperty.PropertyType.ShouldBe(typeof(BaseUrlModel));

            var postLinkContentProperty = model.GetProperty("PostLinkContent");
            postLinkContentProperty.ShouldNotBeNull();
            postLinkContentProperty.PropertyType.ShouldBe(typeof(IHtmlContent));

            var outcomeProperty = model.GetProperty("Outcome");
            outcomeProperty.ShouldNotBeNull();
            outcomeProperty.PropertyType.ShouldBe(typeof(NotificationOutcomeType));

            var wrapperClassNameProperty = model.GetProperty("WrapperClassName");
            wrapperClassNameProperty.ShouldNotBeNull();
            wrapperClassNameProperty.PropertyType.ShouldBe(typeof(string));

            var wrapperAriaRoleProperty = model.GetProperty("WrapperAriaRole");
            wrapperAriaRoleProperty.ShouldNotBeNull();
            wrapperAriaRoleProperty.PropertyType.ShouldBe(typeof(string));

            var showSubHeaderProperty = model.GetProperty("ShowSubHeader");
            showSubHeaderProperty.ShouldNotBeNull();
            showSubHeaderProperty.PropertyType.ShouldBe(typeof(bool));

            var showAlertProperty = model.GetProperty("ShowAlert");
            showAlertProperty.ShouldNotBeNull();
            showAlertProperty.PropertyType.ShouldBe(typeof(bool));

        }

        [Test]
        public void NotificationBannerViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new NotificationBannerViewModel();

            //Assert
            model.Header.ShouldBeNull();
            model.SubHeader.ShouldBeNull();
            model.PreLinkContent.ShouldBeNull();
            model.Link.ShouldBeNull();
            model.PostLinkContent.ShouldBeNull();
            model.Outcome.ShouldBe(NotificationOutcomeType.Alert);
            model.WrapperClassName.ShouldBe("govuk-notification-banner");
            model.WrapperAriaRole.ShouldBe("region");
            model.ShowSubHeader.ShouldBeFalse();
            model.ShowAlert.ShouldBeTrue();
        }

        [Test]
        public void NotificationBannerViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new NotificationBannerViewModel();

            //Act
            model.Header = "Header";
            model.SubHeader = "Sub Header";
            model.PreLinkContent = new HtmlString("Pre Link Content");
            model.Link = new BaseUrlModel { Url = "Url", Text = "Text" };
            model.PostLinkContent = new HtmlString("Post Link Content");
            model.Outcome = NotificationOutcomeType.Success;

            //Assert
            model.Header.ShouldBe("Header");
            model.SubHeader.ShouldBe("Sub Header");
            model.PreLinkContent.ToString().ShouldBe("Pre Link Content");
            model.Link.ShouldNotBeNull();
            model.PostLinkContent.ToString().ShouldBe("Post Link Content");
            model.Outcome = NotificationOutcomeType.Success;
            model.WrapperClassName.ShouldBe("govuk-notification-banner govuk-notification-banner--success");
            model.WrapperAriaRole.ShouldBe("alert");
            model.ShowSubHeader.ShouldBeTrue();
            model.ShowAlert.ShouldBeFalse();
        }
    }
}
