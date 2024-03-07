using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Tic_tac_toe_game
{
    // Class to manage saving game moves to a file
    public class SaveManager
    {
        private const string saveFilePath = "Game Record.json"; // Path to the save file

        // Method to save a move to the file
        public void SaveMove(int id, string[] currentMove)
        {
            // Load existing moves or create a new list
            List<MoveData> moves = LoadMoves();

            // Add the new move to the list
            moves.Add(new MoveData { Id = id, CurrentMove = currentMove });

            // Serialize the moves to JSON and save to file
            string json = JsonSerializer.Serialize(moves, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(saveFilePath, json); // Write the JSON string to the file
        }

        // Method to load moves from the file
        private List<MoveData> LoadMoves()
        {
            if (File.Exists(saveFilePath)) // Check if the save file exists
            {
                string json = File.ReadAllText(saveFilePath);             // Read the JSON data from the file
                return JsonSerializer.Deserialize<List<MoveData>>(json);  // Deserialize the JSON data into a list of MoveData objects
            }
            else
            {
                return new List<MoveData>(); // If the save file doesn't exist, return an empty list
            }
        }

        // Data structure to represent a single move
        private class MoveData
        {
            public int Id { get; set; }                // Player ID
            public string[] CurrentMove { get; set; }  // Current move
        }
    }
}
