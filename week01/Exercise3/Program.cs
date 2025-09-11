using System;

class Program
{
    static void Main()
    {
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess = -1; // Initialize with a value that can't be the magic number

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it :)");
            }
        }
    }
}