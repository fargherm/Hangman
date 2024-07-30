using Hangman.BLL.WordRepository;

namespace Hangman.BLL.PlayerRepository
{
    public class HumanPlayerRepository : IPlayerRepository
    {
        public string PlayerName { get; private set; }
        public bool IsHuman { get; private set; } = true;
        public IWordSource WordSource { get; set; }

        public HumanPlayerRepository(string playerName)
        {
            PlayerName = playerName;
        }

        public string Guess(string guess)
        {
            return guess;
        }
    }
}
