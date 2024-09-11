namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class SummaryCardModelTests
    {
        [Test]
        public void SummaryCardModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.SummaryCardModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void SummaryCardModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.SummaryCardModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var headerProperty = model.GetProperty("Header");
            headerProperty.ShouldNotBeNull();
            headerProperty.PropertyType.ShouldBe(typeof(string));

            var actionLinksProperty = model.GetProperty("ActionLinks");
            actionLinksProperty.ShouldNotBeNull();
            actionLinksProperty.PropertyType.Name.ShouldBe("IList`1");
            actionLinksProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("SummaryListActionLinkModel");

            var contentProperty = model.GetProperty("Content");
            contentProperty.ShouldNotBeNull();
            contentProperty.PropertyType.ShouldBe(typeof(SummaryListViewModel));
        }

        [Test]
        public void SummaryCardModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new SummaryCardModel();

            //Assert
            model.Header.ShouldBeNull();
            model.ActionLinks.ShouldNotBeNull();
            model.ActionLinks.Count.ShouldBe(0);
            model.Content.ShouldBeNull();
        }

        [Test]
        public void SummaryCardModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new SummaryCardModel();

            //Act
            model.Header = "header";
            model.ActionLinks = new List<SummaryListActionLinkModel>()
            {
                new()
                {
                    Url = "someurl",
                    Text = "sometext",
                    ActionContext = "context"
                }
            };
            model.Content = new SummaryListViewModel
            {
                HideBorders = true,
                Items = new List<SummaryListItemModel>()
                {
                    new()
                    {
                        Label = "someitemlabel",
                        Text = new HtmlString("someitemtext"),
                        MissingItem = new BaseUrlModel
                        {
                            Text = "somemissingtext",
                            Url = "somemissingurl"
                        },
                        ActionLinks = new List<SummaryListActionLinkModel>()
                        {
                            new()
                            {
                                Url = "someactionlinkurl",
                                Text = "someactionlinktext",
                                ActionContext = "actionlinkcontext"
                            }
                        }
                    }
                }
            };

            //Assert
            model.Header.ShouldBe("header");
            model.ActionLinks.ShouldNotBeNull();
            model.ActionLinks.Count.ShouldBe(1);
            model.ActionLinks[0].Url.ShouldBe("someurl");
            model.ActionLinks[0].Text.ShouldBe("sometext");
            model.ActionLinks[0].ActionContext.ShouldBe("context");
            model.Content.ShouldNotBeNull();
            model.Content.HideBorders.ShouldBeTrue();
            model.Content.Items.ShouldNotBeNull();
            model.Content.Items.Count.ShouldBe(1);
            model.Content.Items[0].Label.ShouldBe("someitemlabel");
            model.Content.Items[0].Text.ToString().ShouldBe("someitemtext");
            model.Content.Items[0].MissingItem.ShouldNotBeNull();
            model.Content.Items[0].MissingItem.Text.ShouldBe("somemissingtext");
            model.Content.Items[0].MissingItem.Url.ShouldBe("somemissingurl");
            model.Content.Items[0].ActionLinks.ShouldNotBeNull();
            model.Content.Items[0].ActionLinks.Count.ShouldBe(1);
            model.Content.Items[0].ActionLinks[0].Text.ShouldBe("someactionlinktext");
            model.Content.Items[0].ActionLinks[0].Url.ShouldBe("someactionlinkurl");
            model.Content.Items[0].ActionLinks[0].ActionContext.ShouldBe("actionlinkcontext");
        }
    }
}
