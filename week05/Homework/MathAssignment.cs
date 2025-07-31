namespace Homework;

public class MathAssignment : Assignment
{
    private string _textBookSection;
    private string _problems;

    public MathAssignment()
    {
        _studentName = "Roberto Rodriguez";
        _topic = "Fractions";
        _textBookSection = "Section 7.3";
        _problems = "Problems 8-19";
    }

    public string GetHomeworkList()
    {
        string value = $"""
            {_studentName} - {_topic}
            {_textBookSection} {_problems}
            """;
        return value;
    }
}
