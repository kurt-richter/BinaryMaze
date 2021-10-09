using BinaryMaze.Objects;
using Xunit;

namespace UnitTests
{
    public class MazeCellRowTests
    {
        [Fact]
        public void New_instance_sets_index() {
            //Arrange
            int expectedIndex = 1;

            //Act
            MazeCellRow row = new MazeCellRow("0 1 0", expectedIndex);

            //Assert
            Assert.Equal(expectedIndex, row.Index);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("0 1 0 0")]
        [InlineData("0 0 1 0")]
        [InlineData("1 1 1 1")]
        [InlineData("0 0 0 0")]
        public void ToString_returns_row(string rowData) {
            //Arrange
            MazeCellRow row = new MazeCellRow(rowData, 1);

            //Act
            string result = row.ToString();

            //Assert
            Assert.Equal(rowData, result);
        }
    }
}