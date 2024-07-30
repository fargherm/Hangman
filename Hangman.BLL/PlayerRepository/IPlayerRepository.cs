using Hangman.BLL.WordRepository;

namespace Hangman.BLL.PlayerRepository
{
    public interface IPlayerRepository
    {
        string PlayerName { get; }
        bool IsHuman { get; }
        IWordSource WordSource { get; }
        string Guess(string guess);
    }
}
