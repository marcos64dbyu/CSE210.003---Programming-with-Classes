using System;

class Program
{
    // Variables
    private static Journal.PromptGenerator promptGenerator = new Journal.PromptGenerator();
    private static Journal.Entry entry = new Journal.Entry();
    private static string choseElection = "";
    private static List<Journal.Entry> entries = new List<Journal.Entry>();

    static void Main(string[] args)
    {
        do
        {
            choseElection = menu();     // Call the menu method
        } while (choseElection != "5"); 
    }

    static string menu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;      // assign color to the text
        Console.WriteLine($"\n---------Welcome to the Journal App!------------");
        Console.ResetColor();                               // reset color to default
        Console.WriteLine("1. Create a new entry");
        Console.WriteLine("2. View entries");
        Console.WriteLine("3. Save entries to file");
        Console.WriteLine("4. Load entries from file");
        Console.WriteLine("5. Exit");
        Console.Write("\nPlease select an option: ");
        string choice = Console.ReadLine();

        if (choice == "1")                                  // Action in election 1
        {
            string prompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine($"\n{prompt}");
            string answer = Console.ReadLine();
            entry = new Journal.Entry
            {
                _question = prompt,
                _answer = answer
            };
            entries.Add(entry);
        }
        else if (choice == "2")                             // Action in election 2
        {
            if (entries.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere are no entries to view.\n");
                Console.ResetColor();
                return choice;
            }
            else
            {
                Console.WriteLine("\nThis is the content:");
                Console.ForegroundColor = ConsoleColor.Magenta;
                viewEntries();
                Console.ResetColor();
            }
        }
        else if (choice == "3")                             // Action in election 3
        {
            saveEntriesToFile();
            
        }
        else if (choice == "4")                             // Action in election 4
        {
            entries.Clear(); 
            loadEntriesFromFile();
            
        }
        else if (choice == "5")                             // Action in election 5
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nExiting the Journal App. Goodbye!");
            Console.ResetColor();
        }
        else                                                // If the user enters an invalid option
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n>>>>>>>>  Incorrect election  <<<<<<<<<<\n");
            Console.ResetColor();
        }
        return choice;
    }

    static void viewEntries()                               // Method to view all entries
    {
        for (int i = 0; i < entries.Count; i++)
        {
            Console.WriteLine($"\n{entries[i]._dateTime} -> {entries[i]._question}: {entries[i]._answer}");
        }
    }

    static void saveEntriesToFile()                         // Method to save entries to a file
    {
        if (entries.Count == 0)                             // Check if there are no entries to save
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThere are no entries to save.\n");
            Console.ResetColor();
            return;
        }
        else
        {
            Console.Write("What name do you want to save the file as?. ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter a name without the extension (it will be added automatically).");
            Console.ResetColor();
            string fileName = Console.ReadLine();
            fileName = Path.ChangeExtension(fileName, ".csv");
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name is not valid");
                Console.ResetColor();
                return;
            }

            try
            {
                var lines = entries.Select(entry => $"{entry._dateTime};{entry._question};{entry._answer}").ToList();
                File.WriteAllLines(fileName, lines);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nText save in '{fileName}' successfully.\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError to save file: {ex.Message}\n");
                Console.ResetColor();
            }
        }            
    }

    static void loadEntriesFromFile()                       // Method to load entries from a file
    {
        string fileRead = "";
        var files = new List<string>();

        foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv")) // Get all .txt files in the current directory
        {
            files.Add(file);
        }

        if (files.Count == 0)                               // Check if there are no files to load
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThere are no files to load.\n");
            Console.ResetColor();
            return;
        }
        else if (files.Count == 1)                          // If there is only one file, read it directly
        {
            Console.Write("\nThe following file exist: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("'");
            Console.Write(string.Join("', '", files.Select(f => Path.GetFileName(f))));
            Console.Write("'");
            Console.ResetColor();
            Console.WriteLine("\n\nThis is the content: \n");
            fileRead = Path.ChangeExtension(files[0],".csv");
        }
        else if (files.Count > 1)                           // If there are multiple files, ask the user which one to read
        {
            Console.Write("\nThe following files exist: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("'");
            Console.Write(string.Join("', '", files.Select(f => Path.GetFileName(f))));
            Console.Write("'");
            Console.ResetColor();
            Console.WriteLine(". Which file do you want to read the journal from? ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please enter a name without the extension (it will be added automatically).");
            Console.ResetColor();
            fileRead = Path.ChangeExtension(Console.ReadLine(),".csv");
        }

        try                                                 // Try to read the selected file
        {
            var lines = File.ReadAllLines(fileRead);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 3)
                {
                    var entry = new Journal.Entry
                    {
                        _dateTime = DateTime.Parse(parts[0]),
                        _question = parts[1],
                        _answer = parts[2]
                    };
                    entries.Add(entry);
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            viewEntries();
            Console.ResetColor();
        }
        catch (Exception ex)                                // Catch any exceptions that occur while reading the file
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError loading file: {ex.Message}\n");
            Console.ResetColor();
        }
    }
}