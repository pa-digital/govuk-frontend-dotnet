namespace GDS.Components.Test.ViewModelCalculationModels
{
    using GDS.Components.Enum;
    using GDS.Components.ViewModelCalculationModels;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class PaginationViewCalculationsModelTests
    {
        [Test]
        public void PaginationViewCalculationsModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.PaginationViewCalculationsModel, GDS.Components");

            // Assert
            model.ShouldNotBeNull();
            model.GetFields().Length.ShouldBe(13);
        }

        [Test]
        public void PaginationViewCalculationsModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModelCalculationModels.PaginationViewCalculationsModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var showPreviousField = model.GetField("showPrevious");
            showPreviousField.ShouldNotBeNull();
            showPreviousField.FieldType.ShouldBe(typeof(bool));

            var previousLinkField = model.GetField("previousLink");
            previousLinkField.ShouldNotBeNull();
            previousLinkField.FieldType.ShouldBe(typeof(string));

            var showNextField = model.GetField("showNext");
            showNextField.ShouldNotBeNull();
            showNextField.FieldType.ShouldBe(typeof(bool));

            var nextLinkField = model.GetField("nextLink");
            nextLinkField.ShouldNotBeNull();
            nextLinkField.FieldType.ShouldBe(typeof(string));

            var showPrevElipsesField = model.GetField("showPrevElipses");
            showPrevElipsesField.ShouldNotBeNull();
            showPrevElipsesField.FieldType.ShouldBe(typeof(bool));

            var showNextElipsesField = model.GetField("showNextElipses");
            showNextElipsesField.ShouldNotBeNull();
            showNextElipsesField.FieldType.ShouldBe(typeof(bool));

            var firstPageUrlField = model.GetField("firstPageUrl");
            firstPageUrlField.ShouldNotBeNull();
            firstPageUrlField.FieldType.ShouldBe(typeof(string));

            var lastPageUrlField = model.GetField("lastPageUrl");
            lastPageUrlField.ShouldNotBeNull();
            lastPageUrlField.FieldType.ShouldBe(typeof(string));

            var iteratorMinField = model.GetField("iteratorMin");
            iteratorMinField.ShouldNotBeNull();
            iteratorMinField.FieldType.ShouldBe(typeof(int));

            var iteratorMaxField = model.GetField("iteratorMax");
            iteratorMaxField.ShouldNotBeNull();
            iteratorMaxField.FieldType.ShouldBe(typeof(int));

            var firstPageClassField = model.GetField("firstPageClass");
            firstPageClassField.ShouldNotBeNull();
            firstPageClassField.FieldType.ShouldBe(typeof(string));

            var lastPageClassField = model.GetField("lastPageClass");
            lastPageClassField.ShouldNotBeNull();
            lastPageClassField.FieldType.ShouldBe(typeof(string));

            var numericModeField = model.GetField("numericMode");
            numericModeField.ShouldNotBeNull();
            numericModeField.FieldType.ShouldBe(typeof(bool));
        }

        [TestCaseSource(nameof(PaginationViewCalculationsModelInitialisationData))]
        public void PaginationViewCalculationsModelHasCorrectInitialisedValues(PaginationViewModel sourceModel, Dictionary<string, object> expectedValues)
        {
            // Arrange/Act
            var model = new PaginationViewCalculationsModel(sourceModel);

            //Assert
            model.showPrevious.ShouldBe(expectedValues["ShowPrevious"]);
            model.previousLink.ShouldBe(expectedValues["PreviousLink"]);
            model.showNext.ShouldBe(expectedValues["ShowNext"]);
            model.nextLink.ShouldBe(expectedValues["NextLink"]);
            model.showPrevElipses.ShouldBe(expectedValues["ShowPrevElipses"]);
            model.showNextElipses.ShouldBe(expectedValues["ShowNextElipses"]);
            model.firstPageUrl.ShouldBe(expectedValues["FirstPageUrl"]);
            model.lastPageUrl.ShouldBe(expectedValues["LastPageUrl"]);
            model.iteratorMin.ShouldBe(expectedValues["IteratorMin"]);
            model.iteratorMax.ShouldBe(expectedValues["IteratorMax"]);
            model.firstPageClass.ShouldBe(expectedValues["FirstPageClass"]);
            model.lastPageClass.ShouldBe(expectedValues["LastPageClass"]);
            model.numericMode.ShouldBe(expectedValues["NumericMode"]);

        }

        public static IEnumerable<TestCaseData> PaginationViewCalculationsModelInitialisationData()
        {
            yield return new TestCaseData(new PaginationViewModel(), new Dictionary<string, object>{
                    { "ShowPrevious", false },
                    { "PreviousLink", null},
                    { "ShowNext", false },
                    { "NextLink", null },
                    { "ShowPrevElipses", false },
                    { "ShowNextElipses", false },
                    { "FirstPageUrl", "1" },
                    { "LastPageUrl", "0" },
                    { "IteratorMin", 2 },
                    { "IteratorMax", -1 },
                    { "FirstPageClass", "govuk-pagination__item" },
                    { "LastPageClass", "govuk-pagination__item govuk-pagination__item--current" },
                    { "NumericMode", true }
                });
            yield return new TestCaseData(new PaginationViewModel
            {
                RootUrl = "rooturl?page=",
                MaxPage = 3,
                CurrentPage = 1
            }, new Dictionary<string, object>{
                    { "ShowPrevious", false },
                    { "PreviousLink", null },
                    { "ShowNext", true },
                    { "NextLink", "rooturl?page=2" },
                    { "ShowPrevElipses", false },
                    { "ShowNextElipses", false },
                    { "FirstPageUrl", "rooturl?page=1" },
                    { "LastPageUrl", "rooturl?page=3" },
                    { "IteratorMin", 2 },
                    { "IteratorMax", 2 },
                    { "FirstPageClass", "govuk-pagination__item govuk-pagination__item--current" },
                    { "LastPageClass", "govuk-pagination__item" },
                    { "NumericMode", true }
                });
            yield return new TestCaseData(new PaginationViewModel
            {
                RootUrl = "rooturl?page=",
                MaxPage = 3,
                CurrentPage = 2
            }, new Dictionary<string, object>{
                    { "ShowPrevious", true },
                    { "PreviousLink", "rooturl?page=1" },
                    { "ShowNext", true },
                    { "NextLink", "rooturl?page=3" },
                    { "ShowPrevElipses", false },
                    { "ShowNextElipses", false },
                    { "FirstPageUrl", "rooturl?page=1" },
                    { "LastPageUrl", "rooturl?page=3" },
                    { "IteratorMin", 2 },
                    { "IteratorMax", 2 },
                    { "FirstPageClass", "govuk-pagination__item" },
                    { "LastPageClass", "govuk-pagination__item" },
                    { "NumericMode", true }
                });
            yield return new TestCaseData(new PaginationViewModel
            {
                RootUrl = "rooturl?page=",
                MaxPage = 3,
                CurrentPage = 3
            }, new Dictionary<string, object>{
                    { "ShowPrevious", true },
                    { "PreviousLink", "rooturl?page=2" },
                    { "ShowNext", false },
                    { "NextLink", null },
                    { "ShowPrevElipses", false },
                    { "ShowNextElipses", false },
                    { "FirstPageUrl", "rooturl?page=1" },
                    { "LastPageUrl", "rooturl?page=3" },
                    { "IteratorMin", 2 },
                    { "IteratorMax", 2 },
                    { "FirstPageClass", "govuk-pagination__item" },
                    { "LastPageClass", "govuk-pagination__item govuk-pagination__item--current" },
                    { "NumericMode", true }
                });
            yield return new TestCaseData(new PaginationViewModel
            {
                RootUrl = "rooturl?page=",
                MaxPage = 10,
                CurrentPage = 1
            }, new Dictionary<string, object>{
                    { "ShowPrevious", false },
                    { "PreviousLink", null },
                    { "ShowNext", true },
                    { "NextLink", "rooturl?page=2" },
                    { "ShowPrevElipses", false },
                    { "ShowNextElipses", true },
                    { "FirstPageUrl", "rooturl?page=1" },
                    { "LastPageUrl", "rooturl?page=10" },
                    { "IteratorMin", 2 },
                    { "IteratorMax", 2 },
                    { "FirstPageClass", "govuk-pagination__item govuk-pagination__item--current" },
                    { "LastPageClass", "govuk-pagination__item" },
                    { "NumericMode", true }
                });
            yield return new TestCaseData(new PaginationViewModel
            {
                RootUrl = "rooturl?page=",
                MaxPage = 10,
                CurrentPage = 3
            }, new Dictionary<string, object>{
                    { "ShowPrevious", true },
                    { "PreviousLink", "rooturl?page=2" },
                    { "ShowNext", true },
                    { "NextLink", "rooturl?page=4" },
                    { "ShowPrevElipses", false },
                    { "ShowNextElipses", true },
                    { "FirstPageUrl", "rooturl?page=1" },
                    { "LastPageUrl", "rooturl?page=10" },
                    { "IteratorMin", 2 },
                    { "IteratorMax", 4 },
                    { "FirstPageClass", "govuk-pagination__item" },
                    { "LastPageClass", "govuk-pagination__item" },
                    { "NumericMode", true }
                });
            yield return new TestCaseData(new PaginationViewModel
            {
                RootUrl = "rooturl?page=",
                MaxPage = 10,
                CurrentPage = 5
            }, new Dictionary<string, object>{
                    { "ShowPrevious", true },
                    { "PreviousLink", "rooturl?page=4" },
                    { "ShowNext", true },
                    { "NextLink", "rooturl?page=6" },
                    { "ShowPrevElipses", true },
                    { "ShowNextElipses", true },
                    { "FirstPageUrl", "rooturl?page=1" },
                    { "LastPageUrl", "rooturl?page=10" },
                    { "IteratorMin", 4 },
                    { "IteratorMax", 6 },
                    { "FirstPageClass", "govuk-pagination__item" },
                    { "LastPageClass", "govuk-pagination__item" },
                    { "NumericMode", true }
                });
            yield return new TestCaseData(new PaginationViewModel
            {
                RootUrl = "rooturl?page=",
                MaxPage = 10,
                CurrentPage = 8
            }, new Dictionary<string, object>{
                    { "ShowPrevious", true },
                    { "PreviousLink", "rooturl?page=7" },
                    { "ShowNext", true },
                    { "NextLink", "rooturl?page=9" },
                    { "ShowPrevElipses", true },
                    { "ShowNextElipses", false },
                    { "FirstPageUrl", "rooturl?page=1" },
                    { "LastPageUrl", "rooturl?page=10" },
                    { "IteratorMin", 7 },
                    { "IteratorMax", 9 },
                    { "FirstPageClass", "govuk-pagination__item" },
                    { "LastPageClass", "govuk-pagination__item" },
                    { "NumericMode", true }
                });
            yield return new TestCaseData(new PaginationViewModel
            {
                RootUrl = "rooturl?page=",
                MaxPage = 10,
                CurrentPage = 10
            }, new Dictionary<string, object>{
                    { "ShowPrevious", true },
                    { "PreviousLink", "rooturl?page=9" },
                    { "ShowNext", false },
                    { "NextLink", null },
                    { "ShowPrevElipses", true },
                    { "ShowNextElipses", false },
                    { "FirstPageUrl", "rooturl?page=1" },
                    { "LastPageUrl", "rooturl?page=10" },
                    { "IteratorMin", 9 },
                    { "IteratorMax", 9 },
                    { "FirstPageClass", "govuk-pagination__item" },
                    { "LastPageClass", "govuk-pagination__item govuk-pagination__item--current" },
                    { "NumericMode", true }
                });
        }
    }
}
