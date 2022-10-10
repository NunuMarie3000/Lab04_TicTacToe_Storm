using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
  class Player
  {
    public string Name { get; set; }
    /// <summary>
    /// P1 is X and P2 will be O
    /// </summary>
    public string Marker { get; set; }

    /// <summary>
    /// Flag to determine if it is the user's turn
    /// </summary>
    public bool IsTurn { get; set; }


    public Position GetPosition(Board board)
    {
      Position desiredCoordinate = null;

      while (desiredCoordinate == null)
      {
        Console.WriteLine("Please select a location");
        // this is where the bug is i need to check if the tryparse fails or not. if it fails, then that means the spot is already occupied
        // i have no clue why this loop is repeating when the user types in an answer the first time
        Int32.TryParse(Console.ReadLine(), out int position);
        desiredCoordinate = PositionForNumber(position);
      }
      return desiredCoordinate;
    }

    public static Position PositionForNumber(int position)
    {
      // this is evaluating the 1-9 numerical position that corresponds to spots on teh game board
      // based on the input position, it'll return a new instance of the Position class,
      // which takes in row, column as arguments, and sets it to the private row and column , which is where? idk cause there isn't a private int row or private int column anywhere...maybe i have to make it?
      switch (position)
      {
        case 1: return new Position(0, 0); // Top Left
        case 2: return new Position(0, 1); // Top Middle
        case 3: return new Position(0, 2); // Top Right
        case 4: return new Position(1, 0); // Middle Left
        case 5: return new Position(1, 1); // Middle Middle
        case 6: return new Position(1, 2); // Middle Right
        case 7: return new Position(2, 0); // Bottom Left
        case 8: return new Position(2, 1); // Bottom Middle 
        case 9: return new Position(2, 2); // Bottom Right

        default: return null;
      }
    }

    public void TakeTurn(Board board)
    {
      IsTurn = true;

      Console.SetCursorPosition((Console.WindowWidth - (Name.Length + 16)) / 2, Console.CursorTop);
      Console.WriteLine($"{Name} it is your turn\n");

      Position position = GetPosition(board);

      // int32.tryparse converts string to 32 bit int equivalent so "3" converts to 3
      // if it doesn't/can't convert, it fails, ex: if you try to convert "X" into a number, it doesn't work
      // first param is a string to convert
      // second param is what to conver the string to, 
      // ex: int numberThree;
      // Int32.TryParse("3", out int numberThree);
      if (Int32.TryParse(board.GameBoard[position.Row, position.Column], out int _))
      {
        // i need to check if the space is already occupied first before a player can stake claim
        board.GameBoard[position.Row, position.Column] = Marker;
      }
      else
      {
        // here we already know if the space is occupied, b/c it fails the test
        Console.SetCursorPosition((Console.WindowWidth - 30) / 2, Console.CursorTop);
        Console.WriteLine("This space is already occupied");
        TakeTurn(board);
      }
    }
  }
}