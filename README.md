# MineSweeper Game

## Introduction

Dear Reviewer,

Thank you for the opportunity to showcase my skills through this Minesweeper coding test. In this
project, I have implemented a console-based version of the classic Minesweeper game using C#.
This game demonstrates my proficiency in object-oriented programming, algorithmic thinking, and
attention to detail.

## Key Features:

- Object-oriented design with clear separation of responsibilities.
- Implemented using some useful approaches of designing principles.
- Focused to optimize reusability, maintainability and readability.
- Handling of edge cases such as boundary conditions and invalid inputs.
- Ensured game logic adheres to classic Minesweeper rules for a faithful gameplay experience.

## Design Architecture and Implementation Approach

1. Ensure lean and readable codes
    1. By keeping all files in proper format and removing unnecessary usings
    2. By following standard naming conventions across the project.
    3. By using some approaches like using enums, C# extension methods (example.
       **```Direction.Up```** , **```cell.GetAdjacentCells()```** in extension class)
2. Core game logic is implemented in the base abstract class, while Console App capabilities are
    encapsulated in a separate child class. This approach enhances the project's extensibility by
    facilitating integration with various platforms such as WinForms, WPF, web-based ASP.NET
    applications, and other C# based game engines (Unity).
3. **SOLID principles**
    * Single Responsibility Principle – ensure all classes / methods to be as small as possible and each has
    only one purpose / job.
    * Open/Closed Principle – **```BaseMineSweeperGame```** class allows extending functionalities like Console
      capabilities but would not allow to update core game logics.
    * Liskov’s Substitution Principle – **```ConsoleMineSweeperGame```** is substitutable for their base or parent
    class **```BaseMineSweeperGame```** without affecting core game logics.
    * Interface Segregation Principle – Implemented **```IHasGamePlatform```** , **```IInputOutputHandler```** and some
    other interfaces to make sure all components only need to implement interfaces relevant to them.
    * Dependency Inversion Principle – Implemented Game Platform and Console handler as dependencies
    so that we could use **```MockConsole```** in test cases and make it extensible to other game platforms.


## Test Scenario Details

1. End-To-End Tests
    Game Logic Tests
    1. ```Game_UserWon_ReturnsCongratulations``` – automated test script will find all non-mine
cells and input them until player won the game.
    2. ```Game_GameOver_ReturnsGameOver``` – automated test script will find one mine cell and
input. Expected output is game over message.

2. Unit Tests
    1. General Tests, ```GameInit_SizeMines_ReturnCorrectGameState``` – to check if all cells are correctly populated and mines are properly placed.
    2. Utility Tests, ```GetAdjacentCell_AllDirectionsOfX1Y1_ReturnsCorrectCells``` – to test if GetAdjacentCell method returns correct cells of all directions of cell B2 (x: 1, y: 1).
    3. Validation Tests, ```Game_ValidationFailure_ReturnsCorrectError``` – test input and output are prepared according to validation scenarios in coding exercise instruction.
        ```/UnitTests/TestCases/ValidationTests_Game_ValidationFailure_ReturnsCorrectError_In.txt```
        ```/UnitTests/TestCases/ValidationTests_Game_ValidationFailure_ReturnsCorrectError_In.txt```

## Running and Testing the Game:

Environment: **cross-platform**
Recommended: **Windows**
Requirements: **.NET 8.0 installed**

To run the Minesweeper game:

1. Unzip the project zip.
2. <ins>Using IDE</ins>
    1. Open “MineSweeper_HtetWaiYan.sln” in Visual Studio or preferred IDE.
    2. Ensure that “MineSweeper_HtetWaiYan” is set as startup project.
    3. Click on Play button

    <ins>Using dotnet command</ins>
    1. Open command prompt in project root folder.
    2. Execute ```dotnet run --project MineSweeper_HtetWaiYan``` in the folder.

To run Test Cases

1. Unzip the project zip.
2. <ins>Using IDE</ins>
    1. Open “MineSweeper_HtetWaiYan.sln” in Visual Studio or preferred IDE.
    2. Click “Run All” to execute all test cases.

    <ins>Using dotnet command</ins>
    1. Open command prompt in project root folder.
    1. Execute commands as below in the same order
        1. ```dotnet add MineSweeper_HtetWaiYan.Tests package MSTest.TestFramework```
        2. ```dotnet test```

