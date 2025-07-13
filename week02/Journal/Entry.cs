namespace Journal;

public class Entry
{
    public DateTime _dateTime;
    public string _question;
    public string _answer;

    public Entry()
    {
        _dateTime = DateTime.Now;
        _question = "";
        _answer = "";
    }
}
