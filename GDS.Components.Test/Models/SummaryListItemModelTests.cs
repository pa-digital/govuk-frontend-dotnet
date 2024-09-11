namespace GDS.Components.Test.Models
{
    using GDS.Components.Models;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    [TestFixture]
    public class SummaryListItemModelTests
    {
        [Test]
        public void SummaryListItemModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.SummaryListItemModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(6);
        }

        [Test]
        public void SummaryListItemModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.SummaryListItemModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var labelProperty = model.GetProperty("Label");
            labelProperty.ShouldNotBeNull();
            labelProperty.PropertyType.ShouldBe(typeof(string));

            var textProperty = model.GetProperty("Text");
            textProperty.ShouldNotBeNull();
            textProperty.PropertyType.ShouldBe(typeof(IHtmlContent));

            var missingItemProperty = model.GetProperty("MissingItem");
            missingItemProperty.ShouldNotBeNull();
            missingItemProperty.PropertyType.ShouldBe(typeof(BaseUrlModel));

            var actionLinksProperty = model.GetProperty("ActionLinks");
            actionLinksProperty.ShouldNotBeNull();
            actionLinksProperty.PropertyType.Name.ShouldBe("IList`1");
            actionLinksProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("SummaryListActionLinkModel");

            var actionItemCountProperty = model.GetProperty("ActionItemCount");
            actionItemCountProperty.ShouldNotBeNull();
            actionItemCountProperty.PropertyType.ShouldBe(typeof(int));

            var rowClassProperty = model.GetProperty("RowClass");
            rowClassProperty.ShouldNotBeNull();
            rowClassProperty.PropertyType.ShouldBe(typeof(string));
        }

        [TestCaseSource(typeof(SummaryListItemModelTests), nameof(SummaryListItemModelInitialisationData))]
        public void SummaryListItemModelHasCorrectInitialisedValues(List<SummaryListActionLinkModel> actions, int actionCount, string rowClass)
        {
            // Arrange
            var model = new SummaryListItemModel();

            //Act
            model.ActionLinks = actions;

            //Assert
            model.Label.ShouldBeNull();
            model.Text.ShouldBeNull();
            model.MissingItem.ShouldBeNull();
            model.ActionLinks.Count().ShouldBe(actionCount);
            model.RowClass.ShouldBe(rowClass);
        }

        public static IEnumerable<TestCaseData> SummaryListItemModelInitialisationData()
        {
            yield return new TestCaseData(new List<SummaryListActionLinkModel>(), 0, "govuk-summary-list__row govuk-summary-list__row--no-actions");
            yield return new TestCaseData(new List<SummaryListActionLinkModel>{new()}, 1, "govuk-summary-list__row");
            yield return new TestCaseData(new List<SummaryListActionLinkModel> { new(), new() }, 2, "govuk-summary-list__row");
        }
    }
}
