namespace Hangman.BLL.WordRepository
{
    public interface IWordSource
    {
        bool UseConsole { get; }
        bool UseDictionary { get; }
        string GetWord(string wordChoice);
    }
}
