using ExerciseTracking;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("--------------------------------");
        Swimming swim = new Swimming();
        Console.WriteLine(swim.GetSummary());

        Cycling cycling = new Cycling();
        Console.WriteLine(cycling.GetSummary());

        Running run1 = new Running("03 Nov 2022", 30, 3);
        Console.WriteLine(run1.GetSummary());

        Running run2 = new Running("03 Nov 2022", 30, 4.8f);
        Console.WriteLine(run2.GetSummary());
    }
}