using System;

namespace TicTacToe
{
    // Class to assist in managing the game
    public class GameHelper
    {
        // Method to welcome the player
        public void WelcomePlayer()
        {
            Console.WriteLine("Welcome to the Tic-Tac-Toe game!"); // Display welcome message
        }

        // Method to prompt the player for end game choice
        public int EndGame()
        {
            int endGameChoice; // Variable to store the player's choice
            Console.WriteLine("Game is over. Want to play again? Press 1. Press other keys to exit the game."); 
            endGameChoice = int.Parse(Console.ReadLine()); // Read player's choice
            return endGameChoice; // Return the choice
        }

        // Method to allow the player to choose the game mode
        public int ChooseGameMode()
        {
            int gameMode; // Variable to store the chosen game mode
            do
            {
                
                Console.WriteLine("\nPlease choose the game mode:");
                Console.WriteLine("1. Player vs. Computer."); 
                Console.WriteLine("2. Player vs. Player."); 

                if (int.TryParse(Console.ReadLine(), out gameMode)) // Try parsing the input as an integer
                {
                    if (gameMode == 1 || gameMode == 2) // Check if the input is either 1 or 2
                    {
                        break;  // Valid game mode selected, exit the loop
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter either 1 or 2."); // Display error message for invalid input
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer."); // Display error message for non-integer input
                }
            } while (true); // Repeat until a valid input is received

            return gameMode; // Return the chosen game mode
        }
    }
}
