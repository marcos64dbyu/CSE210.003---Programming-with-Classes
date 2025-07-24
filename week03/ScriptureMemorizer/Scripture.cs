namespace ScriptureMemorizer;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

public Scripture(Reference reference, string text)
{
    _reference = reference;

    // Split the text into words by spaces
    string[] splitWords = text.Split(' ');

    // Create an empty list of Word objects
    _words = new List<Word>();

    // Iterate through each word and create Word objects
    foreach (string word in splitWords)
    {
        Word newWord = new Word(word);
        _words.Add(newWord);
    }
}


    public void HideRandomWords(int numberToHide)
    {
        var visibleWords = new List<Word>();
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        int countToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = visibleWords.Count - 1; i > 0; i--)
        {
            int j = _rand.Next(i + 1);
            (visibleWords[i], visibleWords[j]) = (visibleWords[j], visibleWords[i]);
        }

        // Hide first words 
        for (int i = 0; i < countToHide; i++)
        {
            visibleWords[i].Hide();
        }

    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (var word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        string result = string.Join(" ", displayWords);
        return $"{_reference.GetDisplayText()} - {result}";

    }

    public string OriginalText()
    {
        string wstr = "";
        foreach (var word in _words)
        {
            word.Show();
            wstr += word.GetDisplayText() + " ";
        }
        return _reference.GetDisplayText() + " - " + wstr;
    }

    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;

    }
}
