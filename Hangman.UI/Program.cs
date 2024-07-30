using Hangman.BLL.PlayerRepository;
using Hangman.UI;

App app = new App();
Console.WriteLine("Welcome to Hangman!\n");

IPlayerRepository player1 = ConsoleIO.PlayerFactory("Is player 1 a (h)uman or (c)omputer: ", "Player 1");
Console.WriteLine("");
IPlayerRepository player2 = ConsoleIO.PlayerFactory("Is player 2 a (h)uman or (c)omputer: ", "Player 2");

app.Run(player1, player2);