using System.IO;

namespace DAxZE.Extension
{
    internal static class FileHelper
    {
        /// <summary>
        /// Read text file
        /// </summary>
        /// <param name="filePath">File path</param>
        public static string ReadText(string filePath)
        {
            string content = string.Empty;
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            using (StreamReader fileReader = new StreamReader(stream))
            {
                content = fileReader.ReadToEnd();
            }
            return content;
        }

    }
}
