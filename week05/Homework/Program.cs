using Homework;
using System;

class Program
{
    static void Main(string[] args)
    {
        //Assignment assignment = new Assignment();
        //Console.WriteLine(assignment.GetSummary());

        //MathAssignment mathAssignment = new MathAssignment();
        //Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment();
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}