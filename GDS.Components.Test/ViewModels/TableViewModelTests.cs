namespace GDS.Components.Test.ViewModels
{
    using GDS.Components.Models;
    using GDS.Components.ViewModels;
    using Shouldly;

    [TestFixture]
    public class TableViewModelTests
    {
        [Test]
        public void TableViewModelHasCorrectNumberOfProperties()
        {
            // Arrange/Act
            var model = Type.GetType("GDS.Components.ViewModels.TableViewModel, GDS.Components");

            // Assert
            Assert.That(model, Is.Not.Null);
            model.GetProperties().Length.ShouldBe(3);
        }

        [Test]
        public void TableViewModelHasCorrectPropertyTypes()
        {
            // Arrange
            var model = Type.GetType("GDS.Components.ViewModels.TableViewModel, GDS.Components");

            // Act/Assert
            model.ShouldNotBeNull();

            var captionProperty = model.GetProperty("Caption");
            captionProperty.ShouldNotBeNull();
            captionProperty.PropertyType.ShouldBe(typeof(string));

            var headersProperty = model.GetProperty("Headers");
            headersProperty.ShouldNotBeNull();
            headersProperty.PropertyType.Name.ShouldBe("IList`1");
            headersProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("TableHeaderCellModel");

            var rowsProperty = model.GetProperty("Rows");
            rowsProperty.ShouldNotBeNull();
            rowsProperty.PropertyType.Name.ShouldBe("IList`1");
            rowsProperty.PropertyType.GetGenericArguments()[0].Name.ShouldBe("TableRowModel");
        }

        [Test]
        public void TableViewModelHasCorrectInitialisedValues()
        {
            // Arrange/Act
            var model = new TableViewModel();

            //Assert
            model.Caption.ShouldBeNull();
            model.Headers.Count().ShouldBe(0);
            model.Rows.Count().ShouldBe(0);
        }

        [Test]
        public void TableViewModelSetsPropertiesCorrectly()
        {
            // Arrange
            var model = new TableViewModel();

            //Act
            model.Caption = "Caption";
            model.Headers = new List<TableHeaderCellModel> { new TableHeaderCellModel() };
            model.Rows = new List<TableRowModel> { new TableRowModel() };

            //Assert
            model.Caption.ShouldBe("Caption");
            model.Headers.ShouldNotBeNull();
            model.Headers.Count().ShouldBe(1);
            model.Rows.ShouldNotBeNull();
            model.Rows.Count().ShouldBe(1);
        }
    }
}
