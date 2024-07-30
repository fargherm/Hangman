using Hangman.BLL.WordRepository;

namespace Hangman.BLL.PlayerRepository
{
    public class ComputerPlayerRepository : IPlayerRepository
    {
        public string PlayerName {  get; private set; }
        public bool IsHuman { get; private set; } = false;
        public IWordSource WordSource { get; private set; }
        public List<char> Characters { get; private set; }
        private Random _rnd = new Random();

        public ComputerPlayerRepository(string playerName)
        {
            PlayerName = playerName;
            WordSource = new DictionaryWordSource();
            Characters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 
                                            'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                                            's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        }

        public string Guess(string guess)
        {
            return Characters[_rnd.Next(Characters.Count)].ToString();
        }
    }
}
