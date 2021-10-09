using BinaryMaze.Objects;

namespace BinaryMaze.Trackers
{
    public class NullMazeTracker : ITrackable
    {
        public void AddPoint(Point point) { }

        public void RemoveLastPoint() { }
    }
}