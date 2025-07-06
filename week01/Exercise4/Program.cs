using System;

class Program
{
    static void Main(string[] args)
    {
        // make variables
        string insertValue = "";
        int number = 0;
        List<int> numbers = new List<int>();
        List<int> smallPositiveNumber = new List<int>();

        // Print
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
       
        //Calculate
        do 
        {
            Console.WriteLine("Enter number: ");
            insertValue = Console.ReadLine();
            number = int.Parse(insertValue);
            numbers.Add(number);
        } while (insertValue != "0");

        double total = numbers.Sum();
        numbers.Remove(0);

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {(total / (numbers.Count)):F3}"); 
        Console.WriteLine($"The largest number is: {numbers.Max()}");

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > 0)
            {
                smallPositiveNumber.Add(numbers[i]);
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallPositiveNumber.Min()}"); 
        Console.WriteLine($"The sorted list is: "); 

        numbers.Sort();
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]); 
        }
    }
}