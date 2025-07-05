using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string grade_string = Console.ReadLine();           // Read value writen in terminal
        int grade = int.Parse(grade_string);                // Convert string in int value
        int last_digit = grade % 10;                        // Get the last digit to select + o - 

        //Variable
        string letter = "";

        // Asign letter depending score
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";

        }


        // Asign + o - depending the last number in score
        if (last_digit >= 7 && grade < 81 && grade > 60)
        {
            letter += "+";
        }
        else if (last_digit < 3 && grade < 84 && grade > 60)
        {
            letter += "-";
        }

        // Show message depending the score
        if (grade >= 70)
        {
            Console.WriteLine($"Congratulation, you passed!. Your score is {letter}");
        }
        else
        {
            Console.WriteLine($"Sorry, you failed. Your score is {letter}");
        }
    }
}