using System;

class Program
{
    static void Main(string[] args)
    {
        // Try again variable
        string try_again = "no";
        do
        {
            /* Console.WriteLine("What is the magic number? ");
            string magicNumberString = Console.ReadLine();          // Read value written in terminal
            int magicNumber = int.Parse(magicNumberString);         // Convert string in int value
            */

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);

            string guessStringNumber;
            int guessNumber;
            int tries = 0;

            do
            {
                Console.WriteLine("What is your guess? ");
                guessStringNumber = Console.ReadLine();             // Read value written in terminal
                guessNumber = int.Parse(guessStringNumber);         // Convert string in int value

                if (magicNumber == guessNumber)
                {
                    Console.WriteLine($"You guessed it!, in {tries} tries.");
                    Console.WriteLine("Do you want to play again? (yes/no)");
                    try_again = Console.ReadLine().ToLower();       

                }
                else if (guessNumber < magicNumber)
                {
                    Console.WriteLine("Higher");
                    tries++;
                }
                else
                {
                    Console.WriteLine("Lower");
                    tries++;
                }

            } while (magicNumber != guessNumber);
        } while (try_again == "yes");
    }
}