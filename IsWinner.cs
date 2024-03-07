using System;

namespace TicTacToe
{
    // Class to check winning conditions and board fullness in the Tic Tac Toe game
    public class IsWinner
    {
        // Method to check if the current player has won the game
        public static bool CheckWinCondition(GameBoard board, char currentPlayer)
        {
            // Check horizontally
            for (int row = 0; row < 3; row++)
            {
                if (board.GetCell(row, 0) == currentPlayer && board.GetCell(row, 1) == currentPlayer && board.GetCell(row, 2) == currentPlayer)
                {
                    return true; 
                }
            }

            // Check vertically
            for (int col = 0; col < 3; col++)
            {
                if (board.GetCell(0, col) == currentPlayer && board.GetCell(1, col) == currentPlayer && board.GetCell(2, col) == currentPlayer)
                {
                    return true; 
                }
            }

            // Check diagonally
            if ((board.GetCell(0, 0) == currentPlayer && board.GetCell(1, 1) == currentPlayer && board.GetCell(2, 2) == currentPlayer) ||
                (board.GetCell(0, 2) == currentPlayer && board.GetCell(1, 1) == currentPlayer && board.GetCell(2, 0) == currentPlayer))
            {
                return true; 
            }
            return false; // If no winning condition found, return false
        }

        // Method to check if the game board is full
        public static bool CheckBoardFull(GameBoard board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board.GetCell(row, col) == ' ')
                    {
                        return false; // If any cell is empty, return false
                    }
                }
            }
            return true; // If no empty cell found, return true indicating the board is full
        }
    }
}
