using System.IO;


namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            string userInput;

            do
            {
                Console.Clear();
                DisplayPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Welcome to the Eternal Quest!");
                Console.WriteLine("  1. Create a New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Exit");
                Console.Write("Select a choice for the menu: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Menu --> Create a New Goal");
                        CreateGoal();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Menu --> List Goals");
                        ListGoalDetails();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Menu --> Save Goals");
                        SaveGoals();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Menu --> Load Goals");
                        LoadGoals();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Menu --> Record Event");
                        RecordEvent();
                        break;
                    case "6":
                        Console.WriteLine("Menu --> Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

            } while (userInput != "6");
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"You have {_score} points.");
        }

        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\n   No goals available.");
            }
            else
            {
                Console.WriteLine("\nThe goals are:\n");
                for (int i = 0; i < _goals.Count; i++)
                { 
                    Console.WriteLine($"   {i + 1}. {_goals[i]._shortName}");
                }
            }

        }

        public void ListGoalDetails()
        {
            bool complete = false;
            string completeString = complete ? "X" : " ";

            if (_goals.Count == 0)
            {
                Console.WriteLine("\n   No goals available.");
            }
            else
            {
                Console.WriteLine("\nThe goals are:\n");
                for (int i = 0; i < _goals.Count; i++)
                {
                    complete = _goals[i].IsComplete();
                    Console.WriteLine($"   {i + 1}. [{completeString}] {_goals[i].GetDetailsString()}");
                }
            }

            Console.Write($"\nPlease press <Enter> to continue.");
            Console.ReadLine();
        }

        public void CreateGoal()
        {
            Console.WriteLine("Select the type of goal to create:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create?: ");
            string choice = Console.ReadLine();
            Goal newGoal = null;
            switch (choice)
            {
                case "1":
                    newGoal = new SimpleGoal("", "", "");
                    newGoal.RecordEvent();
                    break;
                case "2":
                    newGoal = new EternalGoal("", "", "");
                    newGoal.RecordEvent();
                    break;
                case "3":
                    newGoal = new ChecklistGoal("", "", "", 0, 0);
                    newGoal.RecordEvent();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal creation cancelled.");
                    return;
            }
            _goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record an event.");
                return;
            }
            ListGoalNames();
            Console.Write("Select the goal number to record an event: ");
            if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
            {
                Goal selectedGoal = _goals[goalIndex - 1];
                selectedGoal.RecordEvent();
                if (selectedGoal.IsComplete())
                {
                    _score += int.Parse(selectedGoal._points);
                    Console.WriteLine($"Congratulations! You completed the goal '{selectedGoal._shortName}' and earned {selectedGoal._points} points.");
                }
                else
                {
                    Console.WriteLine($"You recorded an event for the goal '{selectedGoal._shortName}'.");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        public void SaveGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\n No goals available to save.");
                Console.Write($"\nPlease press <Enter> to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.Write("What is the filename for the goal file? ");

                string filename = Console.ReadLine();

                string pathSave = Path.Combine(Directory.GetCurrentDirectory(), filename);

                using (StreamWriter outputFile = new StreamWriter(pathSave))
                {
                    // Write the goals to the file
                    outputFile.WriteLine(_score);

                    foreach (Goal goal in _goals)
                    {
                        if (goal.GetType().GetProperties().Length < 4) 
                        {
                            outputFile.WriteLine($"{goal.GetStringRepresentation()},{goal.IsComplete()}");
                        }
                        else
                        {
                            outputFile.WriteLine($"{goal.GetStringRepresentation()}");
                        }
                    }
                }
                Console.WriteLine($"\n   Goals saved to {filename}.");
                Console.Write($"\nPlease press <Enter> to continue.");
                Console.ReadLine();
            }
        }

        public void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");

            string filename = Console.ReadLine();

            if (filename.Length < 4)
            {
                Console.WriteLine("Invalid filename.");
                Console.Write($"\n   Please press <Enter> to continue.");
                Console.ReadLine();
                return;
            }

            string pathSave = Path.Combine(Directory.GetCurrentDirectory(), filename);
            
            if (!File.Exists(pathSave))
            {
                Console.WriteLine($"File {filename} does not exist.");
                Console.Write($"\n   Please press <Enter> to continue.");
                Console.ReadLine();
                return;
            }

            string[] lines = System.IO.File.ReadAllLines(pathSave);

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string goalType = parts[0];
                string[] goalDetails = parts[1].Split(",");

                if (goalType == "SimpleGoal")
                {
                    Goal goal = new SimpleGoal(goalDetails[0], goalDetails[1], goalDetails[2]);
                    if (goalDetails.Length > 3 && bool.Parse(goalDetails[3]))
                    {
                        goal.IsComplete();
                    }
                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    Goal goal = new EternalGoal(goalDetails[0], goalDetails[1], goalDetails[2]);
                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int target = int.Parse(goalDetails[3]);
                    int bonus = int.Parse(goalDetails[4]);
                    int amountCompleted = int.Parse(goalDetails[5]);
                    ChecklistGoal goal = new ChecklistGoal(goalDetails[0], goalDetails[1], goalDetails[2], target, bonus)
                    {
                        _amountCompleted = amountCompleted
                    };
                    _goals.Add(goal);
                }
            }
        }

    }
}
