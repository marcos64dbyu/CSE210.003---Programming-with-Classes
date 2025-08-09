namespace EternalQuest
{
    public class Goal
    {
        public string _shortName { get; set; }
        public string _description { get; set; }
        public string _points { get; set; }

        public Goal(string name, string description, string points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public virtual void RecordEvent()
        {
            Console.WriteLine();
            Console.Write($"What is the name of your goal? ");
            _shortName = Console.ReadLine();

            Console.Write($"What is a short description of your goal? ");
            _description = Console.ReadLine();

            Console.Write($"What is the amount of points associated with this goal? ");
            _points = Console.ReadLine();
        }

        public virtual bool IsComplete()
        {
            return false;
        }

        public virtual string GetDetailsString()
        {
            return $"{_shortName} ({_description})";
        }

        public virtual string GetStringRepresentation()
        {
            return $"{GetType().Name}:{_shortName},{_description},{_points}";
        }
    }

}
