using System.IO;

namespace BinaryMaze.Readers
{
    public class FileReader
    {
        public string FilePath { get; private set; }

        public FileReader(string filePath) => FilePath = filePath;

        public string[] GetAllLines() {
            if (string.IsNullOrEmpty(FilePath)) { return new string[] { }; }
            if (!File.Exists(FilePath)) { return new string[] { }; }
            return File.ReadAllLines(FilePath);
        }
    }
}