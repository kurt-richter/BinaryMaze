using BinaryMaze.Objects;
using BinaryMaze.Printers;
using BinaryMaze.Readers;
using BinaryMaze.Trackers;
using BinaryMaze.UI;
using System;

namespace BinaryMaze
{
    internal class Program
    {
        private static void Main(string[] args) {
            try {
                string filePath = UserPrompter.PromptUserForInputFile();
                string[] fileLines = new FileReader(filePath).GetAllLines();

                MazeTracker tracker = new MazeTracker();
                MazeGrid maze = new MazeGrid(fileLines, tracker);
                maze.Traverse();

                IPrintable printer = new MazeConsolePrinter(tracker, maze);
                printer.Print();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}