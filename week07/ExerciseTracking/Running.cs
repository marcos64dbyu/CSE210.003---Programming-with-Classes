namespace ExerciseTracking
{
    public class Running : Activity
    {
        private float _distance; // kilometers

        public Running(string date, int duration, float distance)
        {
            _date = date;
            _duration = duration;
            _distance = distance;
        }

        public override float GetDistance()
        {
            return _distance;
        }

        public override float GetSpeed()
        {
            return (_distance / _duration) * 60.0f; // speed in km/h
        }

        public override float GetPace()
        {
            return _duration / _distance; // pace in min/km
        }

        public override string GetSummary()
        {
            return $"{_date} Running ({_duration} min), Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} km/h, Pace: {GetPace():F2} min/km";
        }
    }
}
