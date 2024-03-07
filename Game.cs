using System;
using Tic_tac_toe_game; 

namespace TicTacToe
{
    class Game
    {
        static GameBoard board = new TicTacToeBoard();  // Initialize the game board
        static Player? currentPlayer;                   // Track the current player
        static Player? player1;                         // Player 1
        static Player? player2;                         // Player 2 (either computer or another human player)
        static readonly Move moveMarker1 = new('X');    // Player 1 move marker
        static readonly Move moveMarker2 = new('O');    // Player 2 move marker
        static int gameMode;                            // Track the game mode (1: Player vs Computer; 2. Player vs. Player)
        static bool isWin;                              // Flag to indicate if there's a winner
        static bool isBoardFull;                        // Flag to indicate if the board is full
        static string[]? currentMove;                   // Track the current move, which can be saved to "Game Record.json"
        static bool playAgain;                          // Flag to indicate if the game should be played again

        static void Main(string[] args)
        {
            do
            {
                player1 = new HumanPlayer(1, moveMarker1.Marker);  // Initialize player 1
                GameHelper gameHelper = new();      // Initialize game helper
                SaveManager saveManager = new();    // Initialize save manager

                // Welcome player and let player select the game mode
                // Initialize player 2 based on game mode (1: HumanPlayer; 2. ComputerPlayer)
                // Set player 1 as the current player
                gameHelper.WelcomePlayer();
                gameMode = gameHelper.ChooseGameMode();
                player2 = gameMode == 1 ? (Player)new ComputerPlayer(2, moveMarker2.Marker) : new HumanPlayer(2, moveMarker2.Marker); 
                currentPlayer = player1; 
                
                // Loop the game until the player choose to exit
                do 
                {
                    board.PresentBoard();                                // Display current game board
                    currentMove = currentPlayer.MakeMove(board);         // Get current player's move
                    saveManager.SaveMove(currentPlayer.id, currentMove); // Save the current move
                    isWin = IsWinner.CheckWinCondition(board, currentPlayer.playerMark); // Check for win condition
                    isBoardFull = IsWinner.CheckBoardFull(board);        // Check if the board is full
                    TogglePlayer();                                      // Switch to the next player
                } while (!isWin && !isBoardFull);                        // Continue the loop until someone wins or the board is full

                board.PresentBoard();                    // Display the final game board
                DisplayGameOutcome();                    // Display the game outcome
                board.InitializeBoard();                 // Initialize the board after starting a new game
                playAgain = gameHelper.EndGame() == 1;   // Determine if the game should be played again
            } while (playAgain);
        }
        
        // Toggle players
        static void TogglePlayer()
        {
            currentPlayer = (currentPlayer == player1) ? player2 : player1; 
        }
        
        // Display game outcome based on win or draw
        static void DisplayGameOutcome()
        {
            if (isWin)
            {
                if (currentPlayer == player2 && gameMode == 1)
                    Console.WriteLine("Congratulations! you win!");
                else if (currentPlayer == player1 && gameMode == 1)
                    Console.WriteLine("Sorry! you lost.");
                else if (currentPlayer == player2 && gameMode == 2)
                    Console.WriteLine("Congratulations! Player 1 wins!");
                else if (currentPlayer == player1 && gameMode == 2)
                    Console.WriteLine("Congratulations! Player 2 wins!");
            }
            else
                Console.WriteLine("It's a draw game!");
        }
    }
}
