namespace Homework;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment()
    {
        _studentName = "Mary Waters";
        _topic = "European History"; 
        _title = "The Causes of World War II by Mary Waters";
    }

    public string GetWritingInformation()
    {
        string value = $"""
            {_studentName} - {_topic}
            {_title}
            """;
        return value;
    }
}
