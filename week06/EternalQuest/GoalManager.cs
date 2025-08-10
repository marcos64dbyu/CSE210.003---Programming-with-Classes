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

            SplashScreen();
            Thread.Sleep(3000);
            do
            {
                Console.Clear();
                DisplayPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
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
                        Console.WriteLine(">>>> Create a New Goal <<<<\n");
                        CreateGoal();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(">>>> List Goals <<<<\n");
                        ListGoalDetails();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(">>>> Save Goals <<<<\n");
                        SaveGoals();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine(">>>> Load Goals <<<<\n");
                        LoadGoals();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine(">>>> Record Event <<<<\n");
                        RecordEvent();
                        break;
                    case "6":
                        Console.WriteLine("\nGood Bye");
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
            if (_goals.Count == 0)
            {
                Console.WriteLine("\n   No goals available.");
            }
            else
            {
                Console.WriteLine("\nThe goals are:\n");
                for (int i = 0; i < _goals.Count; i++)
                {
                    bool complete = _goals[i].IsComplete();
                    string completeString = complete ? "X" : " ";
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
            int actualScore = 0;

            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record an event.");
                return;
            }
            ListGoalNames();
            Console.Write("\nSelect the goal number to record an event: ");
            if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
            {
                if(_goals[goalIndex - 1].IsComplete())              // Check if the goal is already complete
                {
                    Console.WriteLine("\n   (X) This goal is already complete.");
                    ReturnMenu();
                    return;
                }

                // If the goal is not complete, record the event

                actualScore = int.Parse(_goals[goalIndex - 1]._points);
                
                var goal = _goals[goalIndex - 1];
                var amountCompleteProperty = goal.GetType().GetProperty("_amountCompleted");
                var targetProperty = goal.GetType().GetProperty("_target");
                var bonusProperty = goal.GetType().GetProperty("_bonus");
                var isCompleteProperty = goal.GetType().GetProperty("_isComplete");
                if (amountCompleteProperty != null)   // Check if the goal has a property named "_amountComplete"
                {
                    // Increment the _amountComplete property if it exists
                    int currentAmount = (int)amountCompleteProperty.GetValue(goal);
                    currentAmount++;
                    amountCompleteProperty.SetValue(goal, currentAmount);

                    // If currentAmount ≥ targetValue, give the bonus.
                    int targetValue = (int)targetProperty.GetValue(goal);
                    if (currentAmount >= targetValue)
                    {
                        actualScore += (int)bonusProperty.GetValue(goal);
                    }
                }
                else if (goal.GetType().Name == "SimpleGoal") 
                {
                    isCompleteProperty.SetValue(goal, true);
                }
                _score += actualScore;

            }
            else
            {
                Console.WriteLine("\n(X) Invalid goal number.");
                ReturnMenu();
                return;
            }

            Console.WriteLine($"\nCongratulations! You have earned {actualScore} points!");
            Console.WriteLine($"You now have {_score} points.");
            ReturnMenu();
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
                Console.Write("\nWhat is the filename for the goal file?: ");

                string filename = Console.ReadLine();

                string pathSave = Path.Combine(Directory.GetCurrentDirectory(), filename);

                using (StreamWriter outputFile = new StreamWriter(pathSave))
                {
                    // Write the goals to the file
                    outputFile.WriteLine(_score);

                    foreach (Goal goal in _goals)
                    {
                        if (goal.GetType().Name == "SimpleGoal") 
                        {
                            outputFile.WriteLine($"{goal.GetStringRepresentation()},{goal.IsComplete().ToString()}");
                        }
                        else
                        {
                            outputFile.WriteLine($"{goal.GetStringRepresentation()}");
                        }
                    }
                }
                Console.WriteLine($"\n   Goals saved to '{filename}'.");
                ReturnMenu();
            }
        }

        public void LoadGoals()
        {
            Console.Write("\nWhat is the filename for the goal file?:  ");

            string filename = Console.ReadLine();

            if (filename.Length < 4)        // Check for valid filename
            {
                Console.WriteLine("\n     (X) Invalid filename.");
                Console.Write($"\nPlease press <Enter> to continue.");
                Console.ReadLine();
                return;
            }

            string pathSave = Path.Combine(Directory.GetCurrentDirectory(), filename);
            
            if (!File.Exists(pathSave))     // Check if the file exists
            {
                Console.WriteLine($"File {filename} does not exist.");
                Console.Write($"\n   Please press <Enter> to continue.");
                Console.ReadLine();
                return;
            }

            string[] lines = System.IO.File.ReadAllLines(pathSave);

            if (lines.Length == 0)      // Check if the file is empty
            {
                Console.WriteLine("\n   (X) No goals available to load.");
                Console.Write($"\nPlease press <Enter> to continue.");
                Console.ReadLine();
                return;
            }

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string goalType = parts[0];
                string[] goalDetails = parts[1].Split(",");

                if (goalType == "SimpleGoal")
                {
                    Goal goal = new SimpleGoal(goalDetails[0], goalDetails[1], goalDetails[2]);
                    var isCompleteProperty = goal.GetType().GetProperty("_isComplete");
                    if (goalDetails.Length > 3 && bool.Parse(goalDetails[3]))
                    {
                        isCompleteProperty.SetValue(goal, true);
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
                    int target = int.Parse(goalDetails[4]);
                    int bonus = int.Parse(goalDetails[3]);
                    int amountCompleted = int.Parse(goalDetails[5]);
                    ChecklistGoal goal = new ChecklistGoal(goalDetails[0], goalDetails[1], goalDetails[2], target, bonus)
                    {
                        _amountCompleted = amountCompleted
                    };
                    _goals.Add(goal);
                }

                Console.WriteLine($"\n   Goals loaded from '{filename}'.");
            }

            ReturnMenu();
        }

        public void ReturnMenu()
        {
            int i = 5;

            Console.Write("\nReturn to menu in:   ");
            for (i = 5; i >= 1; i--)
            {
                
                Console.Write($"\b \b{i}");
                Thread.Sleep(1000);
            }
        }

        public void SplashScreen()
        {

            string[] logo = new string[2];
            logo[0] = @"
 ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ 
 |______|______|______|______|______|______|______|______|______|______|______|______|______|
                                         Welcome to the                                         
 ______        ______ _                        _    ____                  _   _     ______   
 \ \ \ \      |  ____| |                      | |  / __ \                | | | |   / / / /   
  \ \ \ \     | |__  | |_ ___ _ __ _ __   __ _| | | |  | |_   _  ___  ___| |_| |  / / / /    
   > > > >    |  __| | __/ _ \ '__| '_ \ / _` | | | |  | | | | |/ _ \/ __| __| | < < < <     
  / / / /     | |____| ||  __/ |  | | | | (_| | | | |__| | |_| |  __/\__ \ |_|_|  \ \ \ \    
 /_/_/_/      |______|\__\___|_|  |_| |_|\__,_|_|  \___\_\\__,_|\___||___/\__(_)   \_\_\_\  
                                              Game!
  ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ ______ 
 |______|______|______|______|______|______|______|______|______|______|______|______|______|

        ";

            logo[1] = @"
                                        Welcome to the
 __________________________________________________________________________________________              
/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/              
______             ________                        __   ____                  __  __   ______
\ \ \ \           / ____/ /____  _________  ____ _/ /  / __ \__  _____  _____/ /_/ /  / / / /
 \ \ \ \         / __/ / __/ _ \/ ___/ __ \/ __ `/ /  / / / / / / / _ \/ ___/ __/ /  / / / / 
 / / / /        / /___/ /_/  __/ /  / / / / /_/ / /  / /_/ / /_/ /  __(__  ) /_/_/   \ \ \ \ 
/_/_/_/        /_____/\__/\___/_/  /_/ /_/\__,_/_/   \___\_\__,_/\___/____/\__(_)     \_\_\_\
 __________________________________________________________________________________________              
/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/_____/  
                                            Game!
        ";
            

            Random rand = new Random();
            int logoIndex = rand.Next(0, 2);

            List<string> logoLines = logo[logoIndex].Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            foreach (string line in logoLines)
            {
                Console.WriteLine(line);
                Thread.Sleep(80); 
            }

        }

    }
}
