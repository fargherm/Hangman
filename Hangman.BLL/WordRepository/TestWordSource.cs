namespace Hangman.BLL.WordRepository
{
    public class TestWordSource : IWordSource
    {
        public bool UseConsole { get; private set; } = false;
        public bool UseDictionary { get; private set; } = true;

        public string GetWord(string wordChoice)
        {
            return "apple";
        }
    }
}
