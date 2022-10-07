using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
  class Board
  {
    /// <summary>
    /// Tic Tac Toe Gameboard states
    /// </summary>

    //NOTE
    // string[,] is a two-dimensional array
    // row then column
    // string[numberOfRows,numberOfColumns]

    //NOTE FOR GAMEBOARD
    //there's three rows, three columns
    // to access number 6, it'd be [1,2]
    public string[,] GameBoard = new string[,]
    {
      {"1", "2", "3"},
      {"4", "5", "6"},
      {"7", "8", "9"},
    };


    public void DisplayBoard()
    {
      //TODO: Output the board to the console
      // NOTE: HOW?
      Console.WriteLine($"\t{GameBoard[0,0]}  |  {GameBoard[0,1]}  |  {GameBoard[0,2]}");
			Console.WriteLine("      -----------------");
      Console.WriteLine($"\t{GameBoard[1,0]}  |  {GameBoard[1,1]}  |  {GameBoard[1,2]}");
			Console.WriteLine("      -----------------");
      Console.WriteLine($"\t{GameBoard[2,0]}  |  {GameBoard[2,1]}  |  {GameBoard[2,2]}");
    }
  }
}