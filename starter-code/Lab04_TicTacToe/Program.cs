
using System;
using Lab04_TicTacToe.Classes;

namespace Lab04_TicTacToe
{
  class Program
  {
    static void Main(string[] args)
    {
      StartGame();
    }

    static void StartGame()
    {
      // TODO: Setup your game. Create a new method that creates your players and instantiates the game class. Call that method in your Main method.
      try
      {
        string TTT = "*******Tic Tac Toe*******";
        Console.SetCursorPosition((Console.WindowWidth - TTT.Length) / 2, Console.CursorTop);
        Console.WriteLine(TTT);
        Console.WriteLine();

        string setOne = "Enter player 1, this person will be X: ";
        Console.SetCursorPosition((Console.WindowWidth - setOne.Length) / 2, Console.CursorTop);
        Console.WriteLine(setOne);
        string p1String = Console.ReadLine();

        string setTwo = "Enter player 2, this person will be O: ";
        Console.SetCursorPosition((Console.WindowWidth - setTwo.Length) / 2, Console.CursorTop);
        Console.WriteLine(setTwo);
        string p2String = Console.ReadLine();

        string begin = "Great! Let the game commence! Press any key to begin";
        Console.SetCursorPosition((Console.WindowWidth - begin.Length) / 2, Console.CursorTop);
        Console.WriteLine(begin);
        Console.ReadKey();

        // create new instance of player and setting their names to be whatever the user inputs
        Player playerOne = new Player();
        playerOne.Name = p1String;
        playerOne.Marker = "X";
        Player playerTwo = new Player();
        playerTwo.Name = p2String;
        playerTwo.Marker = "O";


        // creating new instance of game, passing in playerOne and playerTwo classes as arguments
        var newGame = new Game(playerOne, playerTwo);
        // start the game
        Player Winner = newGame.Play();
        // You are requesting a Winner to be returned, Determine who the winner is output the celebratory message to the correct player. If it's a draw, tell them that there is no winner.

        string congrats = $"*******Congratulations {Winner.Name}*******";
        Console.SetCursorPosition((Console.WindowWidth - congrats.Length) / 2, Console.CursorTop);
        Console.WriteLine(congrats);
        Console.WriteLine();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        throw;
      }
      finally
      {
        string thanks = "*****Thank you for playing!*****";
        Console.SetCursorPosition((Console.WindowWidth - thanks.Length) / 2, Console.CursorTop);
        Console.WriteLine(thanks);
      }
    }
  }
}