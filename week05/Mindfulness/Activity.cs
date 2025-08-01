namespace Mindfulness;

public class Activity
{
    protected string _activityWelcome;
    protected string _activityMessage;
    protected string _questionActivity;
    protected int _duration;
    private string _previousDuration;
    protected DateTime _startTime;
    protected DateTime _endTime;
    protected bool _isActive;

    public Activity()
    {
        _activityWelcome = "Welcome to activity";
        _activityMessage = "Default Message";
        _questionActivity = "\nHow long in seconds, would you like for your session? ";
        _isActive = false;
    }

    public void Loading(string text = "", int timeC = 3)
    {
        List<string> _loading = new List<string>
        {
            "-",
            "\\",
            "|",
            "/",
        };


        DateTime start = DateTime.Now;
        _isActive = true;
        _startTime = start;
        _endTime = start.AddSeconds(timeC);
        int i = 0;
        string _points = ""; 

        do
        {
            foreach (var frame in _loading)
            {
                // generate points for loading animation
                if (text != "")
                {
                    if (i < timeC)
                    {
                        i++;
                        _points = new string('.', i);
                    }
                    else
                    {
                        // Clean points
                        i = 0;
                        _points = "   ";
                    }
                    Console.Write($"\r{frame} {text} {_points}");
                }
                else
                {
                    Console.Write($"\b \b{frame}");
                }
    
                start = DateTime.Now;
                if (start >= _endTime)
                {
                    _isActive = false;
                }
                Thread.Sleep(500);
            }
            
        } while (_isActive);
        Console.WriteLine("\b \b \n");

    }

    public int StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"{_activityWelcome}\n\n{_activityMessage}");
        Console.Write(_questionActivity);
        _previousDuration = Console.ReadLine();
        // Validate input
        
        if (_previousDuration == "")
        {
            _duration = 0; 
        }
        else
        {
            _duration = int.Parse(_previousDuration);
        }
            

        Console.Clear();

        Console.WriteLine("Get ready...");
        Loading();

        return _duration;
    }

    public void Actions(string textAction, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{textAction}{i}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("");
    }
}
