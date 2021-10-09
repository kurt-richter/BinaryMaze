using BinaryMaze.Objects;
using BinaryMaze.Trackers;
using System;
using Xunit;

namespace UnitTests
{
    public class MazeGridTests
    {
        [Theory]
        [InlineData("0 0 0 1 0 0|" +
                    "0 1 0 1 0 0|" +
                    "0 1 1 1 1 0|" +
                    "0 0 1 0 0 0|" +
                    "0 0 1 0 0 0",
            "(1,4) (2,4) (3,4) (3,3) (4,3) (5,3)")]
        [InlineData("0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0|" +
                    "0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0|" +
                    "0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0|" +
                    "0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0|" +
                    "0 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0|" +
                    "0 1 0 0 0 1 1 1 1 1 1 1 1 1 1 0 1 0 1 0|" +
                    "0 1 0 0 0 1 0 0 0 0 0 0 0 0 1 0 1 0 1 0|" +
                    "0 1 0 0 0 1 0 0 1 0 0 0 0 0 1 1 1 0 1 0|" +
                    "0 1 0 1 1 1 0 0 1 1 1 1 1 0 1 0 1 0 1 0|" +
                    "0 1 0 0 0 1 0 0 0 0 0 0 1 0 1 0 1 0 1 0|" +
                    "0 1 0 0 0 1 1 1 1 1 1 1 1 0 0 0 1 1 1 0|" +
                    "0 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0|" +
                    "0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0|" +
                    "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0|" +
                    "0 0 0 0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0|" +
                    "0 0 0 0 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0",
            "(1,15) (2,15) (3,15) (4,15) (4,14) (4,13) (4,12) (4,11) (4,10) " +
            "(4,9) (4,8) (4,7) (4,6) (4,5) (4,4) (4,3) (4,2) (5,2) (6,2) (7,2) " +
            "(8,2) (9,2) (10,2) (11,2) (12,2) (13,2) (13,3) (13,4) (13,5) (13,6) " +
            "(13,7) (13,8) (13,9) (13,10) (13,11) (13,12) (13,13) (13,14) (13,15) (13,16) " +
            "(13,17) (13,18) (13,19) (14,19) (15,19) (15,18) (15,17) (15,16) (15,15) " +
            "(15,14) (15,13) (15,12) (15,11) (15,10) (15,9) (15,8) (15,7) (15,6) (15,5) " +
            "(16,5)")]
        public void Can_traverse_maze(string mazeData, string expectedPath) {
            //Arrange
            string[] mazeArray = mazeData.Split('|');
            ITrackable tracker = new MazeTracker();
            MazeGrid sut = new MazeGrid(mazeArray, tracker);

            //Act
            sut.Traverse();

            //Assert
            Assert.Equal(expectedPath, tracker.ToString());
        }

        [Theory]
        [InlineData("0 0 0 0 0 0|" +
                    "0 1 0 1 0 0|" +
                    "0 1 1 1 1 0|" +
                    "0 0 1 0 0 0|" +
                    "0 0 1 0 0 0")]
        public void Cannot_traverse_maze_no_entrance_throws_exception(string mazeData) {
            //Arrange
            string[] mazeArray = mazeData.Split('|');
            ITrackable tracker = new MazeTracker();
            MazeGrid sut = new MazeGrid(mazeArray, tracker);

            //Act & Assert
            Assert.Throws<Exception>(() => sut.Traverse());
        }

        [Theory]
        [InlineData("0 0 0 1 0 0|" +
                    "0 1 0 1 0 0|" +
                    "0 1 1 1 1 0|" +
                    "0 0 1 0 0 0|" +
                    "0 0 0 0 0 0")]
        public void Cannot_traverse_maze_no_exit(string mazeData) {
            //Arrange
            string[] mazeArray = mazeData.Split('|');
            ITrackable tracker = new MazeTracker();
            MazeGrid sut = new MazeGrid(mazeArray, tracker);

            //Act
            sut.Traverse();

            //Assert
            Assert.Equal(string.Empty, tracker.ToString());
        }

        [Theory]
        [InlineData("0 0 0 1 0 0|" +
                    "0 1 0 1 0 0|" +
                    "0 1 1 1 1 0|" +
                    "0 0 1 0 0 0|" +
                    "0 0 1 0 0 0")]
        [InlineData("0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0|" +
                    "0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0|" +
                    "0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0|" +
                    "0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0|" +
                    "0 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0|" +
                    "0 1 0 0 0 1 1 1 1 1 1 1 1 1 1 0 1 0 1 0|" +
                    "0 1 0 0 0 1 0 0 0 0 0 0 0 0 1 0 1 0 1 0|" +
                    "0 1 0 0 0 1 0 0 1 0 0 0 0 0 1 1 1 0 1 0|" +
                    "0 1 0 1 1 1 0 0 1 1 1 1 1 0 1 0 1 0 1 0|" +
                    "0 1 0 0 0 1 0 0 0 0 0 0 1 0 1 0 1 0 1 0|" +
                    "0 1 0 0 0 1 1 1 1 1 1 1 1 0 0 0 1 1 1 0|" +
                    "0 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0|" +
                    "0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0|" +
                    "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0|" +
                    "0 0 0 0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0|" +
                    "0 0 0 0 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0")]
        public void ToString_outputs_maze(string mazeData) {
            //Arrange
            string[] mazeArray = mazeData.Split('|');
            MazeGrid sut = new MazeGrid(mazeArray);

            //Act
            string result = sut.ToString();

            //Assert
            Assert.Equal(string.Join('\n', mazeArray), result);
        }
    }
}