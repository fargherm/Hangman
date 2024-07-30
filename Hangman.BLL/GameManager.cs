namespace Hangman.BLL
{
    public class GameManager
    {
        public int GuessesRemaining { get; private set; } = 5;
        public List<char> PreviousGuesses { get; private set; }
        public string Word { get; private set; }

        public GameManager(string word)
        {
            PreviousGuesses = new List<char>();
            Word = word;
        }

        public int? MakeGuess(string guess)
        {
            int count = 0;
            guess = guess.ToLower();
            List<char> checkWinList = new(PreviousGuesses);

            if (guess.Length > 1)
            {
                foreach (char item in guess)
                {
                    if (Word.Contains(item) && !PreviousGuesses.Contains(item))
                    {
                        checkWinList.Add(item);
                    }
                }

                if (!WonGame(checkWinList))
                {
                    GuessesRemaining--;
                    return null;
                }
                else
                {
                    foreach (char item in guess)
                    {
                        if (!PreviousGuesses.Contains(item))
                        {
                            PreviousGuesses.Add(item);
                            GuessesRemaining--;
                        }
                    }
                    return null;
                }
            } 
            else
            {
                if (!PreviousGuesses.Contains(char.Parse(guess)))
                {
                    PreviousGuesses.Add(char.Parse(guess));
                    GuessesRemaining--;
                    foreach (var letter in Word)
                    {
                        if (letter == char.Parse(guess))
                        {
                            count++;
                        }
                    }
                    return count;
                }
            }
            return null;
        }

        public bool WonGame(List<char> list)
        {
            string word = "";

            foreach(char letter in Word)
            {
                if (list.Contains((char)letter))
                {
                    word += letter;
                }
            }

            if (word.Equals(Word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GameOver()
        {
            if (GuessesRemaining == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
