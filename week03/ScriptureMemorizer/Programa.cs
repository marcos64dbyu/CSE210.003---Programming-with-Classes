using System;
using System.Threading.Tasks;
using ScriptureMemorizer;

class Programa
{
    static async Task Main(string[] args)
    {
        string input;
        string inputLower;
        Reference reference;
        string text;
        string[] scriptureText;

        Console.Clear();
        Console.WriteLine("------------Welcome to the Scripture Memorizer!------------");
        Console.WriteLine("Wait while we get a scripture verse from the internet...\n");

        try
        {
            string result = await dataScriptures.GetScriptureAsync();
            scriptureText = result.Split('\n');
            if (scriptureText.Length < 2)
            {
                Console.WriteLine("Failed to retrieve a valid scripture.");
                return;
            }

            reference = new Reference(scriptureText[0]);
            Console.WriteLine(reference.GetDisplayText());
            text = scriptureText[1];
            Console.WriteLine(text);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving scripture: {ex.Message}");
            return;
        }

        Console.WriteLine("\nPress ENTER to Start practice...");
        input = Console.ReadLine();
        // inputLower = input.ToLower();

        // if (inputLower == "quit" || inputLower == "q")
        //     return;

        Scripture scripture = new Scripture(reference, text);

        do
        {
            Console.Clear();
            Console.WriteLine("Can you recall the missing words?\n");

            scripture.HideRandomWords(3);
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("This is the complete scripture:\n");
                Console.WriteLine(scripture.OriginalText());
                Console.WriteLine("\nCongratulations! You have completed the scripture memorization!");
                return;
            }

            Console.WriteLine("\nPress ENTER to continue or type 'q' or 'quit' to exit:");
            input = Console.ReadLine();
            inputLower = input.ToLower();
        }
        while (inputLower != "quit" && inputLower != "q");
    }
}
