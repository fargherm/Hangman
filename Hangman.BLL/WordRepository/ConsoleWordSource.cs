namespace Hangman.BLL.WordRepository
{
    public class ConsoleWordSource : IWordSource
    {
        public bool UseConsole { get; private set; } = true;
        public bool UseDictionary { get; private set; } = false;

        public string GetWord(string wordChoice)
        {
            return wordChoice;
        }
    }
}
