using BinaryMaze.Trackers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryMaze.Objects
{
    public class MazeGrid
    {
        #region Properties

        private List<MazeCellRow> grid;
        private ITrackable tracker;

        #endregion

        #region Constructors

        public MazeGrid(string[] mazeData) : this(mazeData, new NullMazeTracker()) { }

        public MazeGrid(string[] mazeData, ITrackable tracker) {
            grid = new List<MazeCellRow>();
            this.tracker = tracker;
            Initialize(mazeData);
        }

        #endregion

        #region Public Methods

        public void Traverse() {
            MazeCell entryPoint = FindMazeEntrance();
            entryPoint.FindViablePath(tracker);
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < grid.Count; i++) {
                builder.Append(grid[i].ToString());
                builder.Append("\n");
            }
            return builder.ToString().Trim();
        }

        #endregion

        #region Private Methods

        private void Initialize(string[] mazeData) {
            ConvertDataToGrid(mazeData);
            CreateRelationshipsBetweenCells();
        }

        private void ConvertDataToGrid(string[] mazeData) {
            for (int i = 0; i < mazeData.Length; i++) {
                MazeCellRow row = new MazeCellRow(mazeData[i], i);
                grid.Add(row);
            }
        }

        private void CreateRelationshipsBetweenCells() {
            for (int i = 0; i < grid.Count; i++) {
                for (int j = 0; j < grid[i].Count; j++) {
                    //Northern cell
                    if (i > 0) { grid[i][j].NorthCell = grid[i - 1][j]; }

                    //Eastern cell
                    if (j < grid[i].Count - 1) { grid[i][j].EastCell = grid[i][j + 1]; }

                    //Southern cell
                    if (i < grid.Count - 1) { grid[i][j].SouthCell = grid[i + 1][j]; }

                    //Western cell
                    if (j > 0) { grid[i][j].WestCell = grid[i][j - 1]; }
                }
            }
        }

        private MazeCell FindMazeEntrance() {
            MazeCell cell = grid[0].Find(x => x.IsStartingPoint);
            return cell ?? throw new Exception("The maze does not have an entrance.");
        }

        #endregion
    }
}