namespace Journal;

public class Entry      // Object to represent a journal entry
{
    // Variables
    public DateTime _dateTime;
    public string _question;
    public string _answer;

    // Properties
    public Entry()
    {
        _dateTime = DateTime.Now;
        _question = "";
        _answer = "";
    }
}
