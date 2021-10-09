using BinaryMaze.Objects;
using BinaryMaze.Trackers;
using System;
using Xunit;

namespace UnitTests
{
    public class MazePointTests
    {
        [Theory]
        [InlineData(1, 1, "1")]
        [InlineData(1, 2, "0")]
        public void New_instance_sets_point_and_value(int x, int y, string value) {
            //Arrange
            Point point = new Point(x, y);

            //Act
            MazeCell sut = new MazeCell(point, value);

            //Assert
            Assert.Equal(x, sut.Point.X);
            Assert.Equal(y, sut.Point.Y);
            Assert.Equal(value, sut.Value);
        }

        [Fact]
        public void Maze_point_is_starting_cell() {
            //Arrange
            Point point = new Point(1, 1);

            //Act
            MazeCell sut = new MazeCell(point, "1");
            sut.WestCell = new MazeCell(point, "0");
            sut.SouthCell = new MazeCell(point, "0");
            sut.EastCell = new MazeCell(point, "0");

            //Assert
            Assert.NotNull(sut);
            Assert.True(sut.IsStartingPoint);
        }

        [Fact]
        public void Maze_point_is_ending_cell() {
            //Arrange
            Point point = new Point(1, 1);

            //Act
            MazeCell sut = new MazeCell(point, "1");
            sut.WestCell = new MazeCell(point, "0");
            sut.NorthCell = new MazeCell(point, "0");
            sut.EastCell = new MazeCell(point, "0");

            //Assert
            Assert.NotNull(sut);
            Assert.True(sut.IsEndingPoint);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        public void Maze_point_is_not_starting_cell(string value) {
            //Arrange
            Point point = new Point(1, 1);

            //Act
            MazeCell sut = new MazeCell(point, value);
            sut.NorthCell = new MazeCell(point, "0");

            //Assert
            Assert.NotNull(sut);
            Assert.False(sut.IsStartingPoint);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        public void Maze_point_is_not_ending_cell(string value) {
            //Arrange
            Point point = new Point(1, 1);

            //Act
            MazeCell sut = new MazeCell(point, value);
            sut.SouthCell = new MazeCell(point, "0");

            //Assert
            Assert.NotNull(sut);
            Assert.False(sut.IsEndingPoint);
        }

        [Theory]
        [InlineData(1, 1, "0", false)]
        [InlineData(1, 1, "1", true)]
        public void Maze_point_can_be_travelled(int x, int y, string value, bool expectedResult) {
            //Arrange
            Point point = new Point(x, y);

            //Act
            MazeCell sut = new MazeCell(point, value);

            //Assert
            Assert.NotNull(sut);
            Assert.Equal(expectedResult, sut.CanBeTravelled);
        }

        [Fact]
        public void Maze_point_find_path_sets_properties() {
            //Arrange
            Point point = new Point(1, 1);
            MazeCell sut = new MazeCell(point, "1");

            //Act
            bool result = sut.FindViablePath(new NullMazeTracker());

            //Assert
            Assert.True(result);
            Assert.True(sut.IsStartingPoint);
            Assert.True(sut.IsPath);
            Assert.True(sut.IsVisited);
            Assert.True(sut.CanBeTravelled);
        }

        [Fact]
        public void Find_path_goes_to_north_adjacent_cell() {
            //Arrange
            MazeCell sut = new MazeCell(new Point(2, 2), "1");
            sut.NorthCell = new MazeCell(new Point(1, 2), "1");
            sut.EastCell = new MazeCell(new Point(2, 3), "0");
            sut.SouthCell = new MazeCell(new Point(3, 2), "0");
            sut.WestCell = new MazeCell(new Point(2, 1), "0");

            //Act
            sut.FindViablePath(new NullMazeTracker());

            //Assert
            Assert.True(sut.NorthCell.IsVisited);
            Assert.False(sut.EastCell.IsVisited);
            Assert.False(sut.SouthCell.IsVisited);
            Assert.False(sut.WestCell.IsVisited);
        }

        [Fact]
        public void Find_path_goes_to_east_adjacent_cell() {
            //Arrange
            MazeCell sut = new MazeCell(new Point(2, 2), "1");
            sut.NorthCell = new MazeCell(new Point(1, 2), "0");
            sut.EastCell = new MazeCell(new Point(2, 3), "1");
            sut.SouthCell = new MazeCell(new Point(3, 2), "0");
            sut.WestCell = new MazeCell(new Point(2, 1), "0");

            //Act
            sut.FindViablePath(new NullMazeTracker());

            //Assert
            Assert.False(sut.NorthCell.IsVisited);
            Assert.True(sut.EastCell.IsVisited);
            Assert.False(sut.SouthCell.IsVisited);
            Assert.False(sut.WestCell.IsVisited);
        }

        [Fact]
        public void Find_path_goes_to_south_adjacent_cell() {
            //Arrange
            MazeCell sut = new MazeCell(new Point(2, 2), "1");
            sut.NorthCell = new MazeCell(new Point(1, 2), "0");
            sut.EastCell = new MazeCell(new Point(2, 3), "0");
            sut.SouthCell = new MazeCell(new Point(3, 2), "1");
            sut.WestCell = new MazeCell(new Point(2, 1), "0");

            //Act
            sut.FindViablePath(new NullMazeTracker());

            //Assert
            Assert.False(sut.NorthCell.IsVisited);
            Assert.False(sut.EastCell.IsVisited);
            Assert.True(sut.SouthCell.IsVisited);
            Assert.False(sut.WestCell.IsVisited);
        }

        [Fact]
        public void Find_path_goes_to_west_adjacent_cell() {
            //Arrange
            MazeCell sut = new MazeCell(new Point(2, 2), "1");
            sut.NorthCell = new MazeCell(new Point(1, 2), "0");
            sut.EastCell = new MazeCell(new Point(2, 3), "0");
            sut.SouthCell = new MazeCell(new Point(3, 2), "0");
            sut.WestCell = new MazeCell(new Point(2, 1), "1");

            //Act
            sut.FindViablePath(new NullMazeTracker());

            //Assert
            Assert.False(sut.NorthCell.IsVisited);
            Assert.False(sut.EastCell.IsVisited);
            Assert.False(sut.SouthCell.IsVisited);
            Assert.True(sut.WestCell.IsVisited);
        }

        [Fact]
        public void No_point_throws_null_argument_exception() {
            Assert.Throws<ArgumentNullException>(() => new MazeCell(null, "1"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void No_value_throws_null_argument_exception(string value) {
            Assert.Throws<ArgumentNullException>(() => new MazeCell(new Point(1, 1), value));
        }

        [Theory]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        [InlineData(-1, -1)]
        public void Negative_point_value_throws_exception(int x, int y) {
            Assert.Throws<Exception>(() => new MazeCell(new Point(x, y), "1"));
        }
    }
}