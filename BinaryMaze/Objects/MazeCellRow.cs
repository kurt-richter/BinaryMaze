using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryMaze.Objects
{
    public class MazeCellRow : List<MazeCell>
    {
        public int Index { get; private set; }

        public MazeCellRow(string data, int index) {
            Index = index;
            PopulateRow(data);
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++) {
                builder.Append($"{this[i]} ");
            }
            return builder.ToString().Trim();
        }

        private void PopulateRow(string data) {
            List<string> row = ParseRow(data);
            for (int j = 0; j < row.Count; j++) {
                Point point = new Point(Index + 1, j + 1);
                Add(new MazeCell(point, row[j]));
            }
        }

        private List<string> ParseRow(string rowData) => rowData.Split(' ').ToList();
    }
}