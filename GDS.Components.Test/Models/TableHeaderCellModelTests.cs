namespace GDS.Components.Test.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using Shouldly;

    [TestFixture]
    public class TableHeaderCellModelTests
    {
        [Test]
        public void TableHeaderCellModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.TableHeaderCellModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(5);
        }

        [Test]
        public void TableHeaderCellModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.TableHeaderCellModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var dataProperty = model.GetProperty("Data");
            dataProperty.ShouldNotBeNull();
            dataProperty.PropertyType.ShouldBe(typeof(string));

            var dataTypeProperty = model.GetProperty("DataType");
            dataTypeProperty.ShouldNotBeNull();
            dataTypeProperty.PropertyType.ShouldBe(typeof(TableHeaderDataType));

            var customWidthProperty = model.GetProperty("CustomWidth");
            customWidthProperty.ShouldNotBeNull();
            customWidthProperty.PropertyType.ShouldBe(typeof(TableHeaderCustomWidth));

            var headerCellClassNameProperty = model.GetProperty("HeaderCellClassName");
            headerCellClassNameProperty.ShouldNotBeNull();
            headerCellClassNameProperty.PropertyType.ShouldBe(typeof(string));

            var headerCellCustomWidthClassNameProperty = model.GetProperty("HeaderCellCustomWidthClassName");
            headerCellCustomWidthClassNameProperty.ShouldNotBeNull();
            headerCellCustomWidthClassNameProperty.PropertyType.ShouldBe(typeof(string));
        }

        [TestCaseSource(typeof(TableHeaderCellModelTests), nameof(TableHeaderCellModelInitialisationData))]
        public void TableHeaderCellModelHasCorrectInitialisedValues(TableHeaderDataType dataType, string tableHeaderClassName, TableHeaderCustomWidth customWidth, string tableHeaderWidthClassName)
        {
            // Arrange
            var model = new TableHeaderCellModel();

            //Act
            model.DataType = dataType;
            model.CustomWidth = customWidth;

            //Assert
            model.Data.ShouldBeNull();
            model.DataType.ShouldBe(dataType);
            model.HeaderCellClassName.ShouldBe(tableHeaderClassName);
            model.HeaderCellCustomWidthClassName.ShouldBe(tableHeaderWidthClassName);
        }

        [Test]
        public void TableHeaderCellModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TableHeaderCellModel();

            //Act
            model.Data = "data";
            model.DataType = TableHeaderDataType.Numeric;


            //Assert
            model.Data.ShouldBe("data");
            model.DataType.ShouldBe(TableHeaderDataType.Numeric);
        }

        public static IEnumerable<TestCaseData> TableHeaderCellModelInitialisationData()
        {
            yield return new TestCaseData(TableHeaderDataType.String, "govuk-table__header", TableHeaderCustomWidth.Standard, "");
            yield return new TestCaseData(TableHeaderDataType.Numeric, "govuk-table__header govuk-table__header--numeric", TableHeaderCustomWidth.Standard, "");
            yield return new TestCaseData(TableHeaderDataType.String, "govuk-table__header", TableHeaderCustomWidth.Quarter, " govuk-!-width-one-quarter");
            yield return new TestCaseData(TableHeaderDataType.Numeric, "govuk-table__header govuk-table__header--numeric", TableHeaderCustomWidth.Quarter, " govuk-!-width-one-quarter");
            yield return new TestCaseData(TableHeaderDataType.String, "govuk-table__header", TableHeaderCustomWidth.Half, " govuk-!-width-one-half");
            yield return new TestCaseData(TableHeaderDataType.Numeric, "govuk-table__header govuk-table__header--numeric", TableHeaderCustomWidth.Half, " govuk-!-width-one-half");
        }
    }
}
