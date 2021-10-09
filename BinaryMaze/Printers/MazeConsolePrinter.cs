using BinaryMaze.Objects;
using BinaryMaze.Trackers;
using System;

namespace BinaryMaze.Printers
{
    public class MazeConsolePrinter : IPrintable
    {
        private MazeTracker tracker;
        private MazeGrid maze;

        public MazeConsolePrinter(MazeTracker mazeTracker, MazeGrid maze) {
            tracker = mazeTracker;
            this.maze = maze;
        }

        public void Print() {
            Console.WriteLine(string.Empty);
            Console.WriteLine(tracker.ToString());
            Console.WriteLine(string.Empty);
            Console.WriteLine(maze.ToString());
        }
    }
}