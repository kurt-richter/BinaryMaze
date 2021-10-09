using BinaryMaze.Trackers;
using System;
using System.Collections.Generic;

namespace BinaryMaze.Objects
{
    public class MazeCell
    {
        #region Properties

        public Point Point { get; private set; }
        public string Value { get; private set; }
        public bool IsVisited { get; private set; }
        public bool CanBeTravelled => Value == "1";
        public bool IsPath { get; private set; }
        public bool IsStartingPoint => NorthCell == null && CanBeTravelled;
        public bool IsEndingPoint => SouthCell == null && CanBeTravelled;

        public MazeCell NorthCell { get; set; } = null;
        public MazeCell SouthCell { get; set; } = null;
        public MazeCell WestCell { get; set; } = null;
        public MazeCell EastCell { get; set; } = null;

        #endregion

        #region Constructor

        public MazeCell(Point point, string value) {
            Point = point;
            Value = value;
            Validate();
        }

        #endregion

        #region Public Methods

        public override string ToString() => Value;

        public bool FindViablePath(ITrackable tracker) {
            IsVisited = true;
            IsPath = true;
            tracker.AddPoint(Point);

            if (IsEndingPoint) { return true; }

            foreach (MazeCell mazePoint in GetAdjacentCells()) {
                if (mazePoint == null) { continue; }
                if (mazePoint.IsVisited) { continue; }
                if (!mazePoint.CanBeTravelled) { continue; }
                if (mazePoint.FindViablePath(tracker)) { return true; }
                tracker.RemoveLastPoint();
                IsPath = false;
            }

            if (IsStartingPoint) { tracker.RemoveLastPoint(); }

            return false;
        }

        #endregion

        #region Private Methods

        private void Validate() {
            if (Point == null) { throw new ArgumentNullException("point"); }
            if (string.IsNullOrEmpty(Value)) { throw new ArgumentNullException("value"); }
            if (Point.X < 0 || Point.Y < 0) { throw new Exception("Point property cannot contain negative X or Y values."); }
            if (Value != "0" && Value != "1") { throw new Exception("Value cannot be any other value other than 0 or 1."); }
        }

        private List<MazeCell> GetAdjacentCells()
            => new List<MazeCell>() { NorthCell, EastCell, SouthCell, WestCell };

        #endregion
    }
}