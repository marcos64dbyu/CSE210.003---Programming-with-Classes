namespace ExerciseTracking
{
    public class Activity
    {
        protected string _date { get; set; }
        protected int _duration { get; set; }

        public Activity()
        {
            _date = "01/01/2024";
            _duration = 0;
        }

        public virtual float GetDistance()
        {
            return 0.0f;
        }

        public virtual float GetSpeed()
        {
            return 0.0f;
        }

        public virtual float GetPace()
        {
            return 0.0f;
        }

        public virtual string GetSummary()
        {
            return $"{_date} ({_duration} min)";
        }
    }
}
