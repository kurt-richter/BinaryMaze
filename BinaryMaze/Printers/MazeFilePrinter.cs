using BinaryMaze.Objects;
using BinaryMaze.Trackers;

namespace BinaryMaze.Printers
{
    public class MazeFilePrinter : IPrintable
    {
        private MazeTracker tracker;
        private MazeGrid maze;

        public MazeFilePrinter(MazeTracker mazeTracker, MazeGrid maze) {
            tracker = mazeTracker;
            this.maze = maze;
        }

        public void Print() {
            //Print results to a file
        }
    }
}