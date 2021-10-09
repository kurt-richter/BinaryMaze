using BinaryMaze.Objects;
using Xunit;

namespace UnitTests
{
    public class PointTests
    {
        [Theory]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void New_point_sets_x_and_y(int x, int y) {
            //Act
            Point sut = new Point(x, y);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(x, sut.X);
            Assert.Equal(y, sut.Y);
        }

        [Theory]
        [InlineData(-1, -1, "(-1,-1)")]
        [InlineData(0, 0, "(0,0)")]
        [InlineData(1, 1, "(1,1)")]
        public void Point_outputs_x_and_y_as_string(int x, int y, string expectedOutput) {
            //Arrange
            Point sut = new Point(x, y);

            //Act
            string output = sut.ToString();

            //Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}