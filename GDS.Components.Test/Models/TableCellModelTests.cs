namespace GDS.Components.Test.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using Microsoft.AspNetCore.Html;
    using Shouldly;

    public class TableCellModelTests
    {
        [Test]
        public void TableCellModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.TableCellModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void TableCellModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.TableCellModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var dataProperty = model.GetProperty("Data");
            dataProperty.ShouldNotBeNull();
            dataProperty.PropertyType.ShouldBe(typeof(string));

            var dataTypeProperty = model.GetProperty("DataType");
            dataTypeProperty.ShouldNotBeNull();
            dataTypeProperty.PropertyType.ShouldBe(typeof(TableCellDataType));

            var tableCellClassNameProperty = model.GetProperty("TableCellClassName");
            tableCellClassNameProperty.ShouldNotBeNull();
            tableCellClassNameProperty.PropertyType.ShouldBe(typeof(string));
        }

        [TestCaseSource(typeof(TableCellModelTests), nameof(TableCellModelInitialisationData))]
        public void TableCellModelHasCorrectInitialisedValues(TableCellDataType dataType, string tableCellClassName)
        {
            // Arrange
            var model = new TableCellModel();

            //Act
            model.DataType = dataType;

            //Assert
            model.Data.ShouldBeNull();
            model.DataType.ShouldBe(dataType);
            model.TableCellClassName.ShouldBe(tableCellClassName);
        }

        public void TableCellModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TableCellModel();

            //Act
            model.Data = "data";
            model.DataType = TableCellDataType.Numeric;


            //Assert
            model.Data.ShouldBe("data");
            model.DataType.ShouldBe(TableCellDataType.Numeric);
        }

        public static IEnumerable<TestCaseData> TableCellModelInitialisationData()
        {
            yield return new TestCaseData(TableCellDataType.String, "govuk-table__cell");
            yield return new TestCaseData(TableCellDataType.Numeric, "govuk-table__cell govuk-table__cell--numeric");
        }
    }
}
