namespace GDS.Components.Test.Helpers
{
    using GDS.Components.Helpers;
    using Shouldly;

    [TestFixture]
    public class DataValidatorsTests
    {
        [TestCaseSource(nameof(ValidateNumericData))]
        public void ValidateNumericMustReturnCorrectResponse(string data, int maxVal, bool expectedIsEntryOk, string expectedResponse)
        {
            // Act
            var (isEntryOk, response) = DataValidators.ValidateNumeric(data, maxVal);

            // Assert
            isEntryOk.ShouldBe(expectedIsEntryOk);
            response.ShouldBe(expectedResponse);
        }

        [TestCaseSource(nameof(ValidateStringDateData))]
        public void ValidateStringDateMustReturnCorrectResponse(string day, string month, string year, bool expectedIsEntryOk, DateOnly? expectedResponse)
        {
            // Act
            var (isEntryOk, response) = DataValidators.ValidateStringDate(day, month, year);

            // Assert
            isEntryOk.ShouldBe(expectedIsEntryOk);
            response.ShouldBe(expectedResponse);
        }

        [TestCaseSource(nameof(ValidateDateData))]
        public void ValidateDateMustReturnCorrectResponse(int day, int month, int year, bool expectedIsEntryOk, DateOnly? expectedResponse)
        {
            // Act
            var (isEntryOk, response) = DataValidators.ValidateDate(day, month, year);

            // Assert
            isEntryOk.ShouldBe(expectedIsEntryOk);
            response.ShouldBe(expectedResponse);
        }

        public static IEnumerable<TestCaseData> ValidateNumericData()
        {
            yield return new TestCaseData(null, null, false, "numeric");
            yield return new TestCaseData(string.Empty, 10, false, "numeric");
            yield return new TestCaseData("x", 10, false, "numeric");
            yield return new TestCaseData("10", 4, false, "valid numeric");
            yield return new TestCaseData("1", 1, true, string.Empty);
            yield return new TestCaseData("4", 10, true, string.Empty);
        }

        public static IEnumerable<TestCaseData> ValidateStringDateData()
        {
            yield return new TestCaseData(null, null, null, false, null);
            yield return new TestCaseData(string.Empty, string.Empty, string.Empty, false, null);
            yield return new TestCaseData("1", string.Empty, string.Empty, false, null);
            yield return new TestCaseData(string.Empty, "1", string.Empty, false, null);
            yield return new TestCaseData(string.Empty, string.Empty, "1", false, null);
            yield return new TestCaseData("1", "1", string.Empty, false, null);
            yield return new TestCaseData(string.Empty, "1", "1", false, null);
            yield return new TestCaseData("1", string.Empty, "1", false, null);
            yield return new TestCaseData("x", string.Empty, string.Empty, false, null);
            yield return new TestCaseData(string.Empty, "x", string.Empty, false, null);
            yield return new TestCaseData(string.Empty, string.Empty, "x", false, null);
            yield return new TestCaseData("x", "x", string.Empty, false, null);
            yield return new TestCaseData(string.Empty, "x", "x", false, null);
            yield return new TestCaseData("x", string.Empty, "x", false, null);
            yield return new TestCaseData("x", "x", "x", false, null);


            yield return new TestCaseData("32", "1", "2023", false, null);
            yield return new TestCaseData("1", "13", "2023", false, null);
            yield return new TestCaseData("29", "2", "2023", false, null);
            yield return new TestCaseData("1", "1", "2023", true, new DateOnly(2023,1,1));
        }

        public static IEnumerable<TestCaseData> ValidateDateData()
        {  
            yield return new TestCaseData(32, 1, 2023, false, null);
            yield return new TestCaseData(1, 13, 2023, false, null);
            yield return new TestCaseData(29, 2, 2023, false, null);
            yield return new TestCaseData(1, 1, 2023, true, new DateOnly(2023, 1, 1));
        }
    }
}
