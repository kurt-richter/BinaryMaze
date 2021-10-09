using BinaryMaze.Objects;
using BinaryMaze.Trackers;
using Xunit;

namespace UnitTests
{
    public class MazeTrackerTests
    {
        [Fact]
        public void New_instance_tostring_returns_empty_string() {
            //Arrange
            MazeTracker sut = new MazeTracker();

            //Act
            string result = sut.ToString();

            //Assert
            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData(-1, -1, "(-1,-1)")]
        [InlineData(0, 0, "(0,0)")]
        [InlineData(1, 1, "(1,1)")]
        public void AddPoint_adds_point(int x, int y, string expectedOutput) {
            //Arrange
            MazeTracker sut = new MazeTracker();

            //Act
            sut.AddPoint(new Point(x, y));

            //Assert
            Assert.Equal(expectedOutput, sut.ToString());
        }

        [Theory]
        [InlineData(-1, -1, "")]
        [InlineData(0, 0, "")]
        [InlineData(1, 1, "")]
        public void RemoveLastPoint_removes_last_point(int x, int y, string expectedOutput) {
            //Arrange
            MazeTracker sut = new MazeTracker();
            sut.AddPoint(new Point(x, y));

            //Act
            sut.RemoveLastPoint();

            //Assert
            Assert.Equal(expectedOutput, sut.ToString());
        }
    }
}