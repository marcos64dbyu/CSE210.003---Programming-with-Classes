namespace Mindfulness;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "What is something you are truly grateful for today?",
        "When was the last time you felt completely at peace?",
        "Who has had the greatest positive impact on your life, and why?",
        "What is a personal challenge that made you stronger?",
        "When was the last time you stepped out of your comfort zone?",
        "What is a value or principle that guides your decisions?",
        "When was the last time you felt proud of yourself?",
        "Who is someone you can always rely on, and how do they support you?",
        "What is an act of kindness you recently witnessed or experienced?",
        "When was the last time you listened deeply to someone without interrupting?",
        "What is something you would like to forgive yourself for?",
        "Who is someone you need to forgive, and why is it important?",
        "When was the last time you surprised yourself in a positive way?",
        "What is something you want to improve about yourself?",
        "When was the last time you felt truly connected with nature?",
        "What is a memory that always makes you smile?",
        "When did you last take time to appreciate the little things in life?",
        "What is a lesson you learned from a failure or mistake?",
        "Who do you admire the most, and what qualities do they have?",
        "When was the last time you helped someone without expecting anything in return?"
    };

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();

        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            DisplayQuestions();
        }

        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        Console.WriteLine($"--- {_prompts[randomIndex]} ---");
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    private void DisplayQuestions()
    {
        Random random = new Random();
        int randomIndex = random.Next(_questions.Count);
        Console.Write($"> {_questions[randomIndex]} ");
        ShowSpinner(10);
        Console.WriteLine();
    }
}