To run this application locally, download all files and in Visual Studio type “dotnet build TicTacToe.csproj” to build the project, and then type “dotnet run” to run it. Alternatively, you can use Visual Studio Code.

Tic-tac-toe, noughts and crosses, or Xs and Os is a paper-and-pencil game for two players who take turns marking the spaces in a three-by-three grid with X or O. The player who succeeds in placing three of their marks in a horizontal, vertical, or diagonal row is the winner. (https://en.wikipedia.org/wiki/Tic-tac-toe)

In this project, I created and documented an object-oriented design for this game. The game is a Windows Console Application coded in C# (.NET 6.0). The use of object oriented design makes the application extensible and reusable for a wide variety of board games. 

**Features of the game:** 
1. Create a reusable board game
2. Cater for different modes of play: human vs human, computer vs human
3. Check the validity of moves made by human
4. Make random moves made by the computer player
5. Make the game play from start to finish
6. Make the game savable	
7. Make moves undoable

**1. Execution instructions**

1.	Execute the program in Visual Studio or VS Code.
   
3.	After executing the program, the user is greeted with a welcome message to the tic-tac-toe game.
   
5.	The user is prompted to selected a game mode: 1. Player vs. computer. 2. Player vs. player. The user needs to enter a valid number (1 or 2) to play the game. For game mode 1, a computer opponent is created. For game mode 2, a human opponent is created.
   
7.	Player 1 is automatically assigned with the “X” mark in the game. Player 2 (whether it is a computer or human player) is assigned to the “O” mark.
   
9.	The game board is displayed. For a tic-tac-toe game, there are 3 rows and 3 columns.
    
11.	Underneath the game board, the program prompts the player to input their next move. It's important to note that indexing starts from 0 and ends at 2. For instance, entering '1 1' indicates placing a move in the second row and second column. The program requires the user to input precisely two valid numbers to execute a valid move.
    
13.	After the user makes a move, the program switches to player 2. In the case of a player versus computer game mode, the computer will randomly select a move on the board. However, if it's a player versus player mode, the program prompts player 2 to make their move.
    
15.	After each move, the program checks if the game has concluded. It examines two endgame conditions: 1. Whether a winning condition has been met. 2. Whether the game board is completely filled. To determine a winning condition, the program scrutinizes the board horizontally, vertically, and diagonally. In terms of board completeness, the program verifies if there are any remaining empty spaces.
    
17.	The program will keep toggling between players until an endgame condition is met. Upon meeting an endgame condition, a congratulatory message will be displayed for the winner. In the event of a draw, a message indicating a draw game will be shown.
    
19.	The program saves the player ID and each move to a local file named “Game Record.json”. However, the current version of the program lacks the capability to load the file for replaying the game.
    
21.	After the game concludes, the user is prompted to play again by entering '1', or they can choose to exit the game by entering any other key.

**2. Class Responsibility Collaborator (CRC) analysis** 

<img src="CRC analysis 1.png" alt="CRC analysis" width="600" height="1000">
<img src="CRC analysis 2.png" alt="CRC analysis2" width="600" height="300">

<img src="2. Class diagram.svg" alt="SVG Image" width="800" height="700">
<img src="3. Object Diagram.svg" alt="SVG Image" width="800" height="500">
<img src="4. Sequence diagram.svg" alt="SVG Image" width="800" height="700">

**4. Design principles and patterns**

**Encapsulation**. Encapsulation encompasses the concept of data hiding. It has been achieved through the utilization of access modifiers, private fields, methods as interfaces, and more. This fundamental principle has been applied across all classes within the system.

**Abstraction**. Abstractions involve focusing on essential qualities and are usually achieved through using abstract classes and interfaces. For instance, GameBoard and Player classes are good examples. Both classes use abstract class to capture the essential characteristics of these classes.

**Inheritance**. Inheritance facilitates the acquisition of properties from one class by another. Once more, the GameBoard and Player classes serve as good examples. For instance, in a tic-tac-toe scenario, a subclass in GameBoard can inherit the board layout and related actions - such as initializing the board or manipulating cell contents. Similarly, within the Player class hierarchy, subclasses like HumanPlayer and ComputerPlayer inherit essential attributes like ID and playerMark from their parent class, along with crucial methods like MakeMove, which is indispensable in various board games.

**Polymorphism**. Polymorphism allows Polymorphism enables treating objects from distinct classes as instances of a shared superclass. Take the Player class as an example. We can have objects from subclasses like HumanPlayer and ComputerPlayer, but can can still handle them all as if they're just Players. Each subclass can have its version of the MakeMove method. Similarly, the TicTacToeBoard class shows polymorphic behaviour because we can use it anywhere in a GameBoard.

**Factory method pattern**. The Factory Method pattern is utilized in the GameBoard class. Here, an abstract class, GameBoard, outlines the blueprint for creating game boards, while a concrete subclass, TicTacToeBoard, implements a particular type of board. The InitializeBoard() method serves as the factory method, responsible for generating instances of game boards. This approach enhances flexibility and reduces dependency on specific board implementations within client code. Although the GameHelper class doesn't strictly adhere to the Factory Method pattern in all its methods, it does demonstrate elements of it. Specifically, it showcases similar characteristics, especially in how it manages the creation or selection of various game-related options.

**Template method pattern**. The Template Method pattern is used in the Player class, which establishes a template for player actions in Tic Tac Toe. The MakeMove() method serves as the core of the algorithm, outlining the sequence of steps. Concrete subclasses, such as HumanPlayer and ComputerPlayer, implement specific move-making behaviors. While the MakeMove() method in the Player class acts as the template, defining the overarching move-making algorithm, it delegates specific tasks to subclasses. This design fosters code reusability and maintains uniformity in player behaviour across various implementations.

**Singleton pattern**. The code utilizes the Singleton pattern to guarantee the existence of just one instance of the SaveManager class within the entire application. This is accomplished by employing a private constructor, which prohibits direct instantiation of the class, yet permits access to the sole instance via public methods like SaveMove and LoadMoves. This pattern streamlines the management of saving and loading game moves by offering a centralized access point to the singular instance of SaveManager, ensuring consistent and controlled handling of these operations.
