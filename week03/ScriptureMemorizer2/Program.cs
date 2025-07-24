using System;
using System.Net.Quic;
using ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        string input;
        string inputLower;
        string reference;
        string text;
        string scriptureText;
        
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press 'q' or 'quit' to quit or any other key to continue...");
        Console.WriteLine("\nEnter a scripture reference (e.g., John 3:16):");
        input = Console.ReadLine();
        inputLower = input.ToLower();
        if (inputLower == "quit" || inputLower == "q")
        {
            return;
        }
        else
        {
            reference = input;
        }
        Console.WriteLine("\nEnter a scripture Text:");
        input = Console.ReadLine();
        inputLower = input.ToLower();
        if (inputLower == "quit" || inputLower == "q")
        {
            return;
        }
        else
        {
            text = input;
        }
        Scripture scripture = new Scripture(reference, text);

        do
        {
            Console.Clear();
            Console.WriteLine("Can you recall the missing words?\n");
            scriptureText = scripture.PartialScripture();
            if (scriptureText == "exit")
            {
                Console.Clear();
                Console.WriteLine("This is the complete scripture:");
                Console.WriteLine($"{scripture.ScriptureRef}: {scripture.ScriptureText}");
                Console.WriteLine("Congratulations! You have completed the scripture memorization!");
                return;
            }
            Console.WriteLine(scriptureText);
            Console.WriteLine("\nPress ENTER to continue or type 'q' or 'quit' to exit:");
            input = Console.ReadLine();
            inputLower = input.ToLower();
        }
        while (inputLower != "quit" && inputLower != "q");

    }

}