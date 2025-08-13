namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private float _speed; // km per hour

        public Cycling()
        {
            _date = "03 Nov 2022";
            _duration = 30;
            _speed = 6;
        }

        public override float GetDistance()
        {
            return _speed * (_duration / 60.0f);
        }

        public override float GetSpeed()
        {
            return _speed;
        }

        public override float GetPace()
        {
            return 60.0f / _speed;
        }

        public override string GetSummary()
        {
            return $"{_date} Cycling ({_duration} min), Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} km/h, Pace: {GetPace():F2} min/km";
        }
    }
}
