namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps; // number of laps swum

        public Swimming()
        {
            _date = "03 Nov 2022";
            _duration = 30;
            _laps = 3;
        }

        public override float GetDistance()
        {
            return _laps * 50 / 1000f; // Lap 50 meters
        }

        public override float GetSpeed()
        {
            return GetDistance() / (_duration / 60.0f); // speed in km/h
        }

        public override float GetPace()
        {
            return _duration / GetDistance(); // pace in min/km
        }

        public override string GetSummary()
        {
            return $"{_date} Swimming ({_duration} min) - Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} km/h, Pace: {GetPace():F2} min/km";
        }
    }
}
