namespace Journal;

public class message
{
    private DateTime _dateTime;
    private string _question;
    private string _text;

    public message()
    {
        _dateTime = DateTime.Now;
        _question = "";
        _text = "";
    }
}
