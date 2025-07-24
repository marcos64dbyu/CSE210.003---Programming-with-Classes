namespace ScriptureMemorizer;

public class Reference
{
    private string _text;

    public Reference(string text)
    {
        _text = text;
    }

    public string GetDisplayText()
    {
        return _text;
    }
}
