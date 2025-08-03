namespace Mindfulness;

/// <summary>
/// The base class for all mindfulness activities.
/// This class provides common properties and methods for managing activities,
/// such as displaying messages, handling user input for duration,
/// and showing animations.
/// </summary>
public class Activity
{
    // The name of the activity.
    protected string _name;

    // A brief description of what the activity entails.
    protected string _description;

    // The duration of the activity in seconds, as set by the user.
    protected int _duration;

    /// <summary>
    /// Initializes a new instance of the Activity class with default values.
    /// </summary>
    public Activity()
    {
        _name = "Welcome to the Activity";
        _description = "Default message for all activities";
        _duration = 0;
    }

    /// <summary>
    /// Clears the console and displays the starting message for the activity,
    /// prompts the user for the activity duration, and shows a "Get ready" message
    /// followed by a brief spinner animation.
    /// </summary>
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"{_name}\n");
        Console.WriteLine($"{_description}");
        Console.Write("\nHow long in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    /// <summary>
    /// Displays a congratulatory ending message, followed by a summary
    /// of the completed activity and its duration. Includes a spinner animation.
    /// </summary>
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    /// <summary>
    /// Displays a spinning animation for a specified number of seconds.
    /// The animation cycles through a set of characters.
    /// </summary>
    /// <param name="seconds">The duration in seconds to display the spinner.</param>
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerFrames = new List<string> { "|", "/", "-", "\\" };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string frame = spinnerFrames[i % spinnerFrames.Count];
            Console.Write(frame);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i++;
        }
    }

    /// <summary>
    /// Displays a countdown from a specified number of seconds to 1.
    /// The countdown numbers overwrite each other on the same line.
    /// </summary>
    /// <param name="seconds">The number of seconds to countdown from.</param>
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}