using System.Diagnostics;

namespace Mindfulness;

public class ListingActivity : Activity
{
    private List<string> _spiritualPrompts = new List<string>
    {
        "What are some moments in your life when you felt truly at peace?",
        "What are some experiences that make you feel spiritually connected?",
        "Who are the people that bring light and positivity into your life?",
        "What are some of the blessings in your life that you are most grateful for?",
        "What songs, places, or activities bring you closer to your spiritual self?",
        "When do you feel the deepest sense of gratitude?",
        "What are some values that guide your life and decisions?",
        "Who are the people that inspire you to be a better version of yourself?",
        "What are some experiences that have strengthened your faith or hope?",
        "When do you feel the most connected to nature and the world around you?",
        "What small acts of kindness have left a big impact on you?",
        "What are some ways you find inner calm during stressful moments?",
        "When was the last time you felt truly loved and supported?",
        "What are some lessons life has taught you about patience and trust?",
        "Who are the people you feel called to support or uplift?",
        "What are some memories that fill you with joy and peace?",
        "When have you felt a sense of purpose or calling in your life?",
        "What are some ways you express gratitude for the life you have?",
        "When do you feel the presence of something greater than yourself?",
        "What are some moments that made you feel deeply connected to others?"
    };

    private List<string> _responseList = new List<string>();

    public ListingActivity()
    {
        _activityWelcome = "Welcome to the Listing Activity.";
        _activityMessage = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area";
    }

    public void StartListing()
    {
        StartActivity();
        
        Console.WriteLine("List as many responses you can to the following prompt:");
        Random random = new Random();
        int randomIndex = random.Next(_spiritualPrompts.Count);
        string prompt = _spiritualPrompts[randomIndex];
        Console.WriteLine($"--- {prompt} ---");
        Actions("You may begin in: ",5);
        Console.Write("> ");
        _responseList.Add(Console.ReadLine());
        Console.Write("> ");
        _responseList.Add(Console.ReadLine());
        Console.Write("> ");
        _responseList.Add(Console.ReadLine());
        Console.Write("> ");
        _responseList.Add(Console.ReadLine());

        Console.WriteLine($"You listed {_responseList.Count()} items!");
        Console.WriteLine("\nWell done!!\n");
        Loading(timeC: 10);

        return;
    }
}
