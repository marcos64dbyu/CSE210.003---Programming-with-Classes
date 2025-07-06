using System;

class Program
{
    static void Main(string[] args)
    {
        string insertValue = "";
        int number = 0;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
       
        do 
        {
            Console.WriteLine("Enter number: ");
            insertValue = Console.ReadLine();
            number = int.Parse(insertValue);
            numbers.Add(number);
        } while (insertValue != "0");

        int total = numbers.Sum();

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {total / (numbers.Count - 1)}"); 
        Console.WriteLine($"The largest number is: {numbers.Max()}"); 

    }
}