using System;

namespace TicTacToe
{
    // Class representing the game board
    // Abstract class representing a general game board
    public abstract class GameBoard
    {
        protected char[,] board; // 2D array to store the board state
        protected int rows;
        protected int columns;

        // Constructor to initialize the board with dimensions provided
        public GameBoard(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            board = new char[rows, columns];
            InitializeBoard();       // Call the method to initialize the board with empty cells
        }

        // Method to initialize the board with empty cells
        public virtual void InitializeBoard()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        // Method to get the current state of the board
        public char[,] GetBoard()
        {
            return board;
        }

        // Method to present the game board
        public void PresentBoard()
        {
            Console.Clear(); // Clear the console before printing the board

            // Print column indexes
            Console.Write("   ");
            for (int col = 0; col < columns; col++)
            {
                Console.Write(" " + col + "  "); // Adjust the spacing for smaller cells
            }
            Console.WriteLine();

            // Print top border
            Console.Write("  ");
            for (int col = 0; col < columns; col++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            // Print row index and cell values
            for (int row = 0; row < rows; row++)
            {
                Console.Write(row + " |"); // Print row index
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(" " + board[row, col] + " |"); // Adjust the spacing for smaller cells
                }
                Console.WriteLine(); // Move to the next line for the next row

                // Print separator
                Console.Write("  ");
                for (int col = 0; col < columns; col++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
            }
        }

        // Method to get the value of a specific cell on the board
        public char GetCell(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= columns) // Check if the indexes are valid
            {
                Console.WriteLine("Invalid row or column index.");
                return ' ';
            }
            return board[row, col]; // Return the value of the specified cell
        }

        // Method to set the value of a specific cell on the board
        public void SetCell(int row, int col, char cell)
        {
            if (row < 0 || row >= rows || col < 0 || col >= columns) // Check if the indexes are valid
            {
                Console.WriteLine("Invalid row or column index."); // Print error message for invalid indexes
                return;                                            // Exit the method for invalid indexes
            }
            board[row, col] = cell; // Set the value of the specified cell
        }
    }

    // Subclass representing a Tic Tac Toe 3*3 game board
    public class TicTacToeBoard : GameBoard
    {
        public TicTacToeBoard() : base(3, 3) { }
    }
}
