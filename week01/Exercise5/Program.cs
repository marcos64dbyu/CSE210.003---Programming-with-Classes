using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();                                      // Displays the message, "Welcome to the Program!"
        string name = PromptUserName();                        // Asks for and returns the user's name (as a string)
        int favorite_number = PromptUserNumber();              // Asks for and returns the user's favorite number (as an integer)
        int sqr_Number = SquareNumber(favorite_number);        // Accepts an integer as a parameter and returns that number squared (as an integer)
        DisplayResult(name, sqr_Number);                       // Accepts the user's name and the squared number and displays them.
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string user_Name = Console.ReadLine();
        return user_Name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string user_Input = Console.ReadLine();
        int user_Number = int.Parse(user_Input);
        return user_Number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int sqr_Number)
    {
        Console.WriteLine($"{name}, the square of your number is {sqr_Number}.");
    }
}