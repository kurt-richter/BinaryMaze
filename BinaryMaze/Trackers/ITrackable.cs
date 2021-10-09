using BinaryMaze.Objects;

namespace BinaryMaze.Trackers
{
    public interface ITrackable
    {
        void AddPoint(Point point);

        void RemoveLastPoint();
    }
}