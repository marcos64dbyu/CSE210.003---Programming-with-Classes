using System.Diagnostics;

namespace Mindfulness;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "What are some moments in your life when you felt truly at peace?",
        "What are some experiences that make you feel spiritually connected?",
        "Who are the people that bring light and positivity into your life?",
        
    };

    private int _count;
    private List<string> _responseList = new List<string>();

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _count = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        GetRandomPrompt();
        ShowCountDown(5);
        GetListFromUser();

        _count = _responseList.Count();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        string prompt = _prompts[randomIndex];
        Console.WriteLine($"--- {prompt} ---");
    }

    private void GetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (string.IsNullOrEmpty(response))
            {
                break;
            }
            _responseList.Add(response);
        }
    }
}