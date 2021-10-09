using System;
using System.IO;

namespace BinaryMaze.UI
{
    public class UserPrompter
    {
        public static string PromptUserForInputFile() {
            bool isFileValid;
            string filePath;

            do {
                Console.WriteLine("Enter the file path:");
                filePath = Console.ReadLine();

                if (string.IsNullOrEmpty(filePath)) {
                    isFileValid = false;
                    continue;
                }

                if (!File.Exists(filePath)) {
                    isFileValid = false;
                    Console.WriteLine("File does not exist.");
                }
                else { isFileValid = true; }
            } while (!isFileValid);

            return filePath;
        }
    }
}