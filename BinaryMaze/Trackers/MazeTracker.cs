using BinaryMaze.Objects;
using System.Collections.Generic;
using System.Text;

namespace BinaryMaze.Trackers
{
    public class MazeTracker : ITrackable
    {
        private readonly List<Point> Points;

        public MazeTracker() => Points = new List<Point>();

        public void AddPoint(Point point) => Points.Add(point);

        public void RemoveLastPoint() => Points.RemoveAt(Points.Count - 1);

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            foreach (Point point in Points) {
                builder.Append($"{point} ");
            }
            return builder.ToString().Trim();
        }
    }
}