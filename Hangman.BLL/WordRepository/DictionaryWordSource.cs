namespace Hangman.BLL.WordRepository
{
    public class DictionaryWordSource : IWordSource
    {
        public bool UseConsole { get; private set; } = false;
        public bool UseDictionary { get; private set; } = true;
        private Random _rnd = new Random();
        private List<string> _wordChoices; 

        public DictionaryWordSource()
        {
            _wordChoices = ReadData.ReadDataFromFile();
        }

        public string GetWord(string word)
        {
            int randomInt = _rnd.Next(_wordChoices.Count);
            return _wordChoices[randomInt];
        }
    }
}
