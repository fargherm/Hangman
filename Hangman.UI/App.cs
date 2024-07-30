using Hangman.BLL;
using Hangman.BLL.PlayerRepository;
using Hangman.BLL.WordRepository;

namespace Hangman.UI
{
    public class App
    {
        public void Run(IPlayerRepository player1, IPlayerRepository player2)
        {
            IPlayerRepository currentPlayerWord = player1;
            IPlayerRepository currentPlayerGuess = player2;
            string word = "";
            string guess;
            int player1Win = 0;
            int player2Win = 0;
            int? letterCount = 0;

            do
            {
                Console.Clear();
                if (currentPlayerWord.IsHuman)
                {
                    if (currentPlayerWord.WordSource.UseConsole)
                    {
                        word = currentPlayerWord.WordSource.GetWord(ConsoleIO.PickWord(currentPlayerWord, currentPlayerGuess));
                    }
                    else
                    {
                        word = currentPlayerWord.WordSource.GetWord("");
                        Console.WriteLine($"\nA word from the dictionary has been chosen for {currentPlayerWord.PlayerName}!\n");
                    }
                }
                else if (currentPlayerWord.WordSource.UseDictionary)
                {
                    word = currentPlayerWord.WordSource.GetWord("");
                    Console.WriteLine($"A word from the dictionary has been chosen for {currentPlayerWord.PlayerName}!\n");
                }

                GameManager _gameManager = new GameManager(word);

                while (!_gameManager.WonGame(_gameManager.PreviousGuesses) && !_gameManager.GameOver())
                {
                    Console.Clear();
                    Console.WriteLine($"{currentPlayerGuess.PlayerName} is guessing!\n");
                    ConsoleIO.TurnHeader(_gameManager);

                    if (currentPlayerGuess.IsHuman)
                    {
                        guess = ConsoleIO.GetValidString("Enter guess: ");
                    }
                    else
                    {
                        guess = currentPlayerGuess.Guess("");
                        Console.WriteLine($"Enter guess: {guess}\n");
                    }

                    letterCount = _gameManager.MakeGuess(guess);

                    if (_gameManager.WonGame(_gameManager.PreviousGuesses) || _gameManager.GameOver())
                    {
                        ConsoleIO.GameOver(_gameManager, currentPlayerWord, currentPlayerGuess);
                        if (currentPlayerGuess == player1)
                        {
                            currentPlayerWord = player1;
                            currentPlayerGuess = player2;
                            
                            if (_gameManager.WonGame(_gameManager.PreviousGuesses))
                            {
                                player1Win++;
                            }
                        }
                        else
                        {
                            currentPlayerWord = player2;
                            currentPlayerGuess = player1;

                            if (_gameManager.WonGame(_gameManager.PreviousGuesses))
                            {
                                player2Win++;
                            }
                        }
                        break;
                    }
                    else
                    {
                        ConsoleIO.LetterCount(letterCount);
                    }
                }
            } while (ConsoleIO.PlayAgain(player1Win, player2Win, player1.PlayerName, player2.PlayerName));
        }
    }
}
