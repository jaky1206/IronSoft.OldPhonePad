# IronSoft Old Phone Pad Challenge

## Description

This project implements a solution to the IronSoft Old Phone Pad coding challenge. The challenge involves converting a string of numbers and symbols into text, simulating the input from an old phone keypad. A pause is required to type two characters from the same button after each other. The "#" symbol indicates the end of the input.

## Solution Structure

The solution consists of the following projects:

- **IronSoft.OldPhonePad.Console:** A console application that takes input from the user and converts it to the Old Phone Pad output.
- **IronSoft.OldPhonePad.Library:** A class library containing the core logic for converting the input string to the Old Phone Pad output. The main class is `OldPhonePad` class.
- **IronSoft.OldPhonePad.UnitTests:** A unit test project that tests the `OldPhonePad` class.

## Examples
```
OldPhonePad("33#") => output: E
OldPhonePad("227*#") => output: B
OldPhonePad("4433555 555666#") => output: HELLO
OldPhonePad("8 88777444666*664#") => output: ??????
```

## .NET Version

This project targets .NET 8.0.

## How to Build and Run from Command Prompt

1.  Clone the repository.
2.  Navigate to the project directory.
3.  Build the solution using the following command:

    ```bash
    dotnet build
    ```

4.  Run the console application using the following command:

    ```bash
    dotnet run --project IronSoft.OldPhonePad.Console
    ```

5.  Run the unit tests using the following command:

    ```bash
    dotnet test IronSoft.OldPhonePad.UnitTests
    ```

## How to Run in Visual Studio

1.  Clone the repository.
2.  Open the `IronSoft.OldPhonePad.sln` solution in Visual Studio.
3.  To run the console application, set `IronSoft.OldPhonePad.Console` as the startup project and run it.
4.  To run the unit tests, open the Test Explorer and run all tests in the `IronSoft.OldPhonePad.UnitTests` project.
