using System;

class Program
{
    static void Main(string[] args)
    {
        /* C# Programming Exercise 1—Variables, Input, and OutputLinks to an external site. */


        // input first name and last name
        Console.WriteLine("What is your first name? ");
        string first_name = Console.ReadLine();

        Console.WriteLine("What is your last name? ");
        string last_name = Console.ReadLine();


        // print text
        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}.");
    }
}