
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
      Console.WriteLine("*******Tic Tac Toe*******");
      Console.ReadKey();
      Console.WriteLine("Enter player 1, this person will be X: ");
      string p1String = Console.ReadLine();
      Console.WriteLine("Enter player 2, this person will be O: ");
      string p2String = Console.ReadLine();

      Console.WriteLine("Great! Let the game commence! Press any key to begin");
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
			newGame.Play();
      // You are requesting a Winner to be returned, Determine who the winner is output the celebratory message to the correct player. If it's a draw, tell them that there is no winner.
      Console.WriteLine("*******Congratulations {Winner}*******");
    }


  }
}