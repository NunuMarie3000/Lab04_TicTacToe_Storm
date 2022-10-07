using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
  class Game
  {
    public Player PlayerOne { get; set; }
    public Player PlayerTwo { get; set; }
    public Player Winner { get; set; }
    public Board Board { get; set; }


    /// <summary>
    /// Require 2 players and a board to start a game. 
    /// </summary>
    /// <param name="p1">Player 1</param>
    /// <param name="p2">Player 2</param>
    public Game(Player p1, Player p2)
    {
      PlayerOne = p1;
      PlayerTwo = p2;
      Board = new Board();
    }

    /// <summary>
    /// Activate the Play of the game
    /// </summary>
    /// <returns>Winner</returns>
    public Player Play()
    {
      // if numberOfTurns == 10, then its a draw...or ==9...

      //TODO: Complete this method and utilize the rest of the class structure to play the game.

      /*
       * Complete this method by constructing the logic for the actual playing of Tic Tac Toe. 
       * 
       * A few things to get you started:
      1. A turn consists of a player picking a position on the board with their designated marker. 
			
			// so for each turn...
			// check who's turn it is
			// player.isTurn == true? then they need to take their turn
			// so...player.getPosition(Board); // how would i make edits/add player.marker to the board? with the player.TakeTurn(Board) method,
			//so...
				// player.isTurn == true ?
					// player.TakeTurn(Board);
					// Position desiredCoordinate = player.GetPosition(Board);
					// Position position = player.PositionForNumber(desiredCoordinate); 
					// Board.DisplayBoard();
					// isThereAWinner = CheckForWinner(Board);

				// then switch player
				// game.SwitchPlayer();
				// game.NextPlayer() // returns player who's turn it is, so i can do 
					// player.TakeTurn(Board);

      2. Display the board after every turn to show the most up to date state of the game board.DisplayBoard():
      3. Once a Winner is determined, display the board one final time and return a winner
      Few additional hints:
          Be sure to keep track of the number of turns that have been taken to determine if a draw is required
          and make sure that the game continues while there are unmarked spots on the board. 
      Use any and all pre-existing methods in this program to help construct the method logic. 
       */

      int numberOfTurns = 0;
      bool isThereAWinner = false;
      Player whoseTurn = PlayerOne;
      Player Draw = new Player();
      Draw.Name = "it's a Draw";

      while (!isThereAWinner)
      {
        if (numberOfTurns == 9) // if its a draw, break
        {
          isThereAWinner = true;
          Winner = Draw;
        }
        else
        {
          // this is essentially the loop i gotta do to play the game
          Board.DisplayBoard();
          whoseTurn.TakeTurn(Board);
          SwitchPlayer();
          numberOfTurns++;
          isThereAWinner = CheckForWinner(Board);
          whoseTurn = NextPlayer();
        }
      }
      Board.DisplayBoard(); // display board one more time when game ends

      //this is gonna return a winner, instance of player
      return Winner;
    }


    /// <summary>
    /// Check if winner exists
    /// </summary>
    /// <param name="board">current state of the board</param>
    /// <returns>if winner exists</returns>
    public bool CheckForWinner(Board board)
    {
      bool isWinner = false;
      // this is a jagged array: array whose elements are other arrays
      // 
      int[][] winners = new int[][]
      {
        new[] {1,2,3},
        new[] {4,5,6},
        new[] {7,8,9},

        new[] {1,4,7},
        new[] {2,5,8},
        new[] {3,6,9},

        new[] {1,5,9},
        new[] {3,5,7}
      };

      // Given all the winning conditions, Determine the winning logic. 
      for (int i = 0; i < winners.Length; i++)
      {
        // Player.PositionForNumber() takes in an integer(1-9 corresponding to gameboard) and returns a position with row and column
        // so p1/p2/p3 is gonna be a Position with row and column accessible by p1.Row and p1.Column
        // winners[][] is all 8 possible winning situations
        // so... p1/p2/p3 will be the winning 3 possible numbers
        Position p1 = Player.PositionForNumber(winners[i][0]); // i=array, 0=first element; [0][0] = 1
        Position p2 = Player.PositionForNumber(winners[i][1]); // [0][1] = 2
        Position p3 = Player.PositionForNumber(winners[i][2]); // [0][2] = 3

        // Board.GameBoard[], gameboard is a 2D array where first index is row, second is column
        // gameboard is the actual board 1-9
        // a/b/c is a 2D array that's the physical board of our current game
        string a = Board.GameBoard[p1.Row, p1.Column]; // 
        string b = Board.GameBoard[p2.Row, p2.Column];
        string c = Board.GameBoard[p3.Row, p3.Column];

        // TODO:  Determine a winner has been reached. 
        // so how do i use these tools to check if there is a win?
        // i'll have to set it here
        // i can check if there's a winner(true/false), but how do i know who the winner is???
        // the Player.TakeTurn() method changes the number on the board to the players' marker, X or O
        if (a == "X" && b == "X" && c == "X")
        {
          isWinner = true;
          Winner = PlayerOne;
          break;
        }
        else if (a == "O" && b == "O" && c == "O")
        {
          isWinner = true;
          Winner = PlayerTwo;
          break;
        }
        else { isWinner = false; }
        // return true if a winner has been reached. 
      }

      return isWinner;
    }


    /// <summary>
    /// Determine next player
    /// </summary>
    /// <returns>next player</returns>
    public Player NextPlayer()
    {
      return (PlayerOne.IsTurn) ? PlayerOne : PlayerTwo;
    }

    /// <summary>
    /// End one players turn and activate the other
    /// </summary>
    public void SwitchPlayer()
    {
      if (PlayerOne.IsTurn)
      {

        PlayerOne.IsTurn = false;


        PlayerTwo.IsTurn = true;
      }
      else
      {
        PlayerOne.IsTurn = true;
        PlayerTwo.IsTurn = false;
      }
    }


  }
}