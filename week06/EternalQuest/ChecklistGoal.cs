namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        public int _amountCompleted { get; set; }
        public int _target { get; set; }
        public int _bonus { get; set; }

        public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            base.RecordEvent();                                                         // Call the base method to record the event
            Console.Write($"How many times do you need to complete this goal? ");       // add prompt for target
            _target = int.Parse(Console.ReadLine());
            Console.Write($"What is the bonus points for completing this goal? ");      // add prompt for bonus points
            _bonus = int.Parse(Console.ReadLine());
        }

        public override bool IsComplete()
        {
            if (_amountCompleted >= _target)                                            // Check if the amount completed is greater than or equal to the target
            {
                return true;                                                            // If so, return true
            }
            else
            {
                return false;                                                           // Otherwise, return false
            }
        }

        public override string GetDetailsString()
        {
            return $"{_shortName} ({_description}) -- Currently Complete {_amountCompleted}/{_target}"; // Return a string representation of the goal details
        }

        public override string GetStringRepresentation()
        {
            return $"{GetType().Name}:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}"; // Return a string representation of the goal
        }
    }
}
