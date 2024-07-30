using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Hangman.BLL.WordRepository
{
    public class ReadData
    {
        private const string _filePath = "Data\\dictionary.txt";

        public static List<string> ReadDataFromFile()
        {
            List<string> wordList = new List<string>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    wordList.Add(line);
                }
            }

            return wordList;
        }
    }
}
