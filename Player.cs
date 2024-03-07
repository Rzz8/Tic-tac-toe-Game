using System;

namespace TicTacToe
{
    // Abstract class representing a player in the Tic Tac Toe game
    public abstract class Player
    {        
        public int id;           // Player's ID
        public char playerMark;  // Player's marker (X or O)

        public Player(int id, char marker)
        {
            this.id = id;
            playerMark = marker;
        }

        // Abstract method to make a move, to be implemented by subclasses
        public abstract string[] MakeMove(GameBoard board);
    }

    // Class representing a human player
    public class HumanPlayer : Player
    {
        public HumanPlayer(int id, char marker) : base(id, marker)
        {
        }

        // Method to make a move for a human player
        public override string[] MakeMove(GameBoard board)
        {
            bool validMove = false;       // Flag to track if the move is valid
            string[]? currentMove = null;  // Track the current move

            // Loop until a valid move is entered
            do
            {
                Console.WriteLine("\nPlayer " + playerMark + ", please enter your next move (row column): ");
                Console.WriteLine("The index starts from 0 and please use a blank space between row and column.");
                Console.WriteLine("An example of '1 1' means putting your move at the second row and the second column.");
                string[] nextMove = Console.ReadLine().Split(' ');

                // Validate the input
                if (nextMove.Length != 2)
                {
                    Console.WriteLine("\nInvalid input! Please enter both row and column number.");
                    continue;
                }

                // Parse row and column inputs
                if (!int.TryParse(nextMove[0], out int row) || !int.TryParse(nextMove[1], out int col))
                {
                    Console.WriteLine("\nInvalid input! Please enter numeric values for row and column.");
                    continue;
                }

                // Check if the move is within bounds and the cell is empty
                if (row >= 0 && col >= 0 && row < 3 && col < 3 && board.GetCell(row, col) == ' ')
                {
                    board.SetCell(row, col, playerMark);  // Set the cell with player's marker
                    validMove = true;                     // Set validMove flag to true
                    currentMove = nextMove;               // Record the current move
                }
                else
                {
                    Console.WriteLine("The move you entered is not valid! Please enter a valid move: ");
                }
            } while (!validMove); 

            return currentMove; // Return the current move
        }
    }

    // Class representing a computer player
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(int id, char marker) : base(id, marker)
        {
        }

        // Method to make a random move for a computer player
        public override string[] MakeMove(GameBoard board)
        {
            Random random = new Random();  // Random object to generate random moves
            int row, col;                  // Variables to store row and column for the move
            string[] currentMove = null;   // Track the current move

            // Loop until a valid move is generated
            do
            {
                row = random.Next(0, 3);               // Generate random row index
                col = random.Next(0, 3);               // Generate random column index
            } while (board.GetCell(row, col) != ' ');  // Repeat if the cell is not empty

            board.SetCell(row, col, playerMark);                            // Set the cell with player's marker
            currentMove = new string[] { row.ToString(), col.ToString() };  // Record the current move

            return currentMove; // Return the current move
        }
    }
}
