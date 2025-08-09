namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public bool _isComplete { get; set; }

        public SimpleGoal(string name, string description, string points) : base(name, description, points) // Call the base constructor
        {
            _isComplete = false;            // Initialize the completion status
        }

        public override void RecordEvent()
        {
            base.RecordEvent();             // Call the base method to record the event
        }

        public override bool IsComplete()
        {
            return _isComplete;      // Return the completion status
        }

        public override string GetDetailsString()
        {
            return $"{_shortName} ({_description})";
        }
    }
}
