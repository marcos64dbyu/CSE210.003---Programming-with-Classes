using HtmlAgilityPack;
namespace ScriptureMemorizer;

public class dataScriptures
{
    static readonly HttpClient client = new();

    private Random _rand = new Random();

    static readonly (string id, string name, int maxChapter)[] books = new[]
    {
        ("1-ne", "1 Nephi", 22),
        ("2-ne", "2 Nephi", 33),
        ("jacob", "Jacob", 7),
        ("enos", "Enos", 1),
        ("jarom", "Jarom", 1),
        ("omni", "Omni", 1),
        ("w-of-m", "Words of Mormon", 1),
        ("mosiah", "Mosiah", 29),
        ("alma", "Alma", 63),
        ("hel", "Helaman", 16),
        ("3-ne", "3 Nephi", 30),
        ("4-ne", "4 Nephi", 1),
        ("morm", "Mormon", 9),
        ("ether", "Ether", 15),
        ("moro", "Moroni", 10)
    };

    public static async Task<string> GetScriptureAsync(int maxRetries = 10)
    {
        var rand = new Random();
        int attempts = 0;

        int i = rand.Next(books.Length);
        string bookId = books[i].id;
        string bookName = books[i].name;
        int chapter = rand.Next(1, books[i].maxChapter + 1);
        while (attempts < maxRetries)
        {
            int verse = rand.Next(1, 51); // Versos mayores a los disponibles serán descartados al fallar

            string url = $"https://www.churchofjesuschrist.org/study/scriptures/bofm/{bookId}/{chapter}?lang=eng&id=p{verse}#p{verse}";

            try
            {
                string html = await client.GetStringAsync(url);

                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                // Buscar el span con id="p{verse}"
                var verseNode = doc.GetElementbyId($"p{verse}");

                if (verseNode != null)
                {
                    // string verseText = verseNode.InnerText.Trim();
                    string verseText = System.Text.RegularExpressions.Regex.Replace(verseNode.InnerText, @"^\s*\d{1,2}\s*", "").Trim();

                    string reference = $"{bookName} {chapter}:{verse}";

                    return $"{reference}\n{verseText}";
                }
                else
                {
                    // No encontró el versículo, intentar otro
                    attempts++;
                    continue;
                }
            }
            catch (HttpRequestException)
            {
                // Error de red o del servidor
                throw;
            }
        }

        throw new Exception($"No se pudo obtener un versículo válido después de {maxRetries} intentos.");
    }
}
