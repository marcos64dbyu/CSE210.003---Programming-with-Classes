namespace Mindfulness;

public class BreathingActivity : Activity
{
    private int _duration;

    public BreathingActivity()
    {
        _activityWelcome = "Welcome to the Breathing Activity.";
        _activityMessage = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breating";
    }

    public void StartBreathing()
    {
        // Total duration of the activity / cycle duration
        _duration = StartActivity() / 10;
        for (int i = 0; i < _duration; i++)
        {
            Actions("Breathe in...", 4);
            Actions("Now breathe out...", 6);
            Console.WriteLine("\n");
        }
        
        Console.WriteLine("Well done!!");
        Loading(timeC:10);

        return;
    }

}
