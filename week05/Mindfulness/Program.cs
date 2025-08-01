using Mindfulness;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "0";
        do
        {
            Console.Clear();
            Console.WriteLine("------------Welcome to the Mindfulness Program!---------------------");
            Console.WriteLine("This program will help you practice mindfulness techniques.");
            Console.WriteLine("Menu Options:");

            // Example mindfulness technique
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            // Get user input
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    // Call method for breathing activity
                    BreathingActivity breathingActivity = new();
                    breathingActivity.StartBreathing();
                    break;
                case "2":
                    // Call method for reflection activity
                    ReflectingActivity reflectingActivity = new();
                    reflectingActivity.StartReflection();
                    break;
                case "3":
                    // Call method for listing activity
                    ListingActivity listingActivity = new();
                    listingActivity.StartListing();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (userInput != "4");

    }
}