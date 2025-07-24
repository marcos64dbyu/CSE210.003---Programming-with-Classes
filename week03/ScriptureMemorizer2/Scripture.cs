using System.Formats.Asn1;

namespace ScriptureMemorizer;

public class Scripture
{
    private string _text;
    private string _reference;
    private List<int> _hiddenIndexes = new List<int>();
    private Random _rand = new Random();

    public Scripture(string reference, string text)
    {
        _reference = reference;
        _text = text;
    }

    public string ScriptureRef
    {
        get{ return _reference; }
    }
    public string ScriptureText
    {
        get { return _text; }
    }

    public string PartialScripture()
    {
        // Split the full scripture text into individual words
        var words = _text.Split(' ');

        // If all words have already been hidden, return "exit" to indicate completion
        if (_hiddenIndexes.Count == words.Length)
        {
            return "exit";
        }
        // Otherwise, randomly select one word that hasn't been hidden yet
        else if (_hiddenIndexes.Count < words.Length)
        {
            int index;
            do
            {
                index = _rand.Next(words.Length); // Get a random index within the range of words
            }
            while (_hiddenIndexes.Contains(index)); // Repeat until an index that hasn't been hidden is found

            _hiddenIndexes.Add(index); // Mark this word index as hidden
        }

        // Replace each hidden word with underscores matching the word's length
        for (int i = 0; i < words.Length; i++)
        {
            if (_hiddenIndexes.Contains(i))
            {
                string hiddenWord = "";
                for (int j = 0; j < words[i].Length; j++)
                {
                    hiddenWord += "_";
                }
                words[i] = hiddenWord;

            }
        }

        // Return the scripture reference followed by the partially hidden text
        return $"{_reference}: {string.Join(" ", words)}";
    }

}

