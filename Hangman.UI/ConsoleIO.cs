using Hangman.BLL;
using Hangman.BLL.PlayerRepository;
using Hangman.BLL.WordRepository;

namespace Hangman.UI
{
    public static class ConsoleIO
    {
        public static IPlayerRepository PlayerFactory(string prompt, string playerNumber)
        {
            do
            {
                Console.Write(prompt);
                string? response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    if (response.ToUpper() == "H")
                    {
                        string playerName = GetValidString("Enter player name: ");

                        Console.WriteLine($"\n{playerName}, how would you like to choose your words?");
                        var player = new HumanPlayerRepository(playerName);
                        player.WordSource = GetWordSource();
                        return player;
                    }
                    else if (response.ToUpper() == "C")
                    {
                        Console.WriteLine($"The computer has been assigned the name '{playerNumber}' " +
                                          $"and will pick a random word from the dictionary.\n");
                        return new ComputerPlayerRepository(playerNumber);
                    }
                }
                Console.WriteLine("That is not a valid input!");
            } while (true);
        }

        public static IWordSource GetWordSource()
        {
            Console.WriteLine("\n1. I will choose the word.");
            Console.WriteLine("2. Pick a random word from the dictionary for me.\n");
            do
            {
                Console.Write("Enter choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        return new ConsoleWordSource();
                    }
                    else if (choice == 2)
                    {
                        return new DictionaryWordSource();
                    }
                }
                Console.WriteLine("That is not a valid input!");
            } while (true);
        } 

        public static string GetValidString(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string? response = Console.ReadLine();

                if (!string.IsNullOrEmpty(response))
                {
                    return response;
                }
                Console.WriteLine("You must enter something!");
            } while (true);
        }

        public static string PickWord(IPlayerRepository currentPlayer, IPlayerRepository otherPlayer)
        {
            Console.WriteLine($"{currentPlayer.PlayerName}, you will pick the word to guess. {otherPlayer.PlayerName}, look away!");

            do
            {
                string word = GetValidString("Enter word: ");
                Console.Clear();
                return word;
            } while (true);
        }

        public static void TurnHeader(GameManager gameManager)
        {
            string guesses = "";
            string word = "";

            for (int i = 0; i < gameManager.PreviousGuesses.Count; i++)
            {
                if (i < gameManager.PreviousGuesses.Count - 1)
                {
                    guesses = guesses + gameManager.PreviousGuesses[i] + ", ";
                }
                else
                {
                    guesses = guesses + gameManager.PreviousGuesses[i];
                }
            }

            foreach (var item in gameManager.Word)
            {
                if (gameManager.PreviousGuesses.Contains(item))
                {
                    word = word + item;
                }
                else
                {
                    word = word + "_";
                }
            }
            Console.WriteLine($"Strikes Remaining: {gameManager.GuessesRemaining}");
            Console.WriteLine($"Previous Guesses: {guesses}\n");
            Console.WriteLine($"Word: {word}\n");
        }

        public static void LetterCount(int? letterCount)
        {
            if (letterCount > 0)
            {
                Console.WriteLine($"\nWe found {letterCount} of those!");
            }
            else if (letterCount == 0)
            {
                Console.WriteLine("Sorry, we didn't find any of those.");
            }
            AnyKey();
        }

        public static void GameOver(GameManager gameManager, IPlayerRepository currentPlayerWord, IPlayerRepository currentPlayerGuess)
        {
            if (gameManager.WonGame(gameManager.PreviousGuesses))
            {
                Console.WriteLine($"{currentPlayerGuess.PlayerName} guessed the word. They win!");
            }
            else if (gameManager.GameOver())
            {
                Console.WriteLine($"{currentPlayerGuess.PlayerName} has struck out, {currentPlayerWord.PlayerName} wins!");
            }
        }

        public static bool PlayAgain(int player1Score, int player2Score, string player1Name, string player2Name)
        {
            do
            {
                Console.WriteLine("\nThe score is:");
                Console.WriteLine($"{player1Name} - {player1Score}");
                Console.WriteLine($"{player2Name} - {player2Score}");
                Console.Write("\nDo you want to play again? (y/n): ");

                string? response = Console.ReadLine();

                if (!string.IsNullOrEmpty(response))
                {
                    if (response.ToUpper() == "Y")
                    {
                        Console.Clear();
                        return true;
                    }
                    else if (response.ToUpper() == "N")
                    {
                        return false;
                    }
                }
                Console.WriteLine("That is not a valid input!");
            } while (true);
        }

        public static void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
