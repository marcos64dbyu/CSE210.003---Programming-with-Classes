namespace Homework;

public class Assignment
{
    protected string _studentName;
    protected string _topic;

    // constructor
    public Assignment()
    {
        _studentName = "Samuel Bennett";
        _topic = "Multiplication";
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}
