namespace GDS.Components.Test.Models
{
    using GDS.Components.Enum;
    using GDS.Components.Models;
    using Shouldly;

    [TestFixture]
    public class TableRowModelTests
    {
        [Test]
        public void TableRowModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.Models.TableRowModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(2);
        }

        [Test]
        public void TableRowModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.Models.TableRowModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var headerProperty = model.GetProperty("HeaderColumn");
            headerProperty.ShouldNotBeNull();
            headerProperty.PropertyType.ShouldBe(typeof(string));

            var actionLinksProperty = model.GetProperty("DataColumns");
            actionLinksProperty.ShouldNotBeNull();
            actionLinksProperty.PropertyType.Name.ShouldBe("IList`1");
            actionLinksProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("TableCellModel");

        }

        [Test]
        public void TableRowModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new TableRowModel();

            //Assert
            model.HeaderColumn.ShouldBeNull();
            model.DataColumns.ShouldNotBeNull();
            model.DataColumns.Count.ShouldBe(0);
        }


        [Test]
        public void TableRowModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TableRowModel();

            //Act
            model.HeaderColumn = "header";
            model.DataColumns = new List<TableCellModel>()
            {
                new()
                {
                    Data = "data",
                    DataType = TableCellDataType.Numeric
                }
            };

            //Assert
            model.HeaderColumn.ShouldBe("header");
            model.DataColumns.ShouldNotBeNull();
            model.DataColumns.Count.ShouldBe(1);
            model.DataColumns[0].Data.ShouldBe("data");
            model.DataColumns[0].DataType.ShouldBe(TableCellDataType.Numeric);
        }
    }
}
