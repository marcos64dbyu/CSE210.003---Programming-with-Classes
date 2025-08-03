namespace Mindfulness;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
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
        _activityWelcome = "Consider the following prompt: ";
        //Random random = new Random();
        //int randomIndex = random.Next(_prompts.Count);
        //_activityMessage = $"--- {_prompts[randomIndex]} ---";
        _activityMessage = $"--- Think of a time when you did something really difficult. ---";
        _questionActivity = "\nWhen you have something in mind, press enter to continue.";
    }

    public void StartReflection()
    {
        // Total duration of the activity / cycle duration
        _duration = StartActivity();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");

        Actions("You may begin in: ",6);

        Console.Clear();

        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        Console.Write($"> {_prompts[randomIndex]}  ");
        Loading(timeC:15);
        randomIndex = random.Next(_prompts.Count);
        Console.Write($"> {_prompts[randomIndex]}  ");
        Loading(timeC: 15);

        Console.WriteLine("\nWell done!!");
        Loading(timeC: 5);
        Console.WriteLine("You have completed another 30 seconds of the Reflecting Activity");
        Loading(timeC: 5);

        return;
    }
}
