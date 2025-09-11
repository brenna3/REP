using System;

class Program
{
    static void Main()
    {
        // Ask for grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        // Determine letter grade
        string letter;

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

        // Print letter grade
        Console.WriteLine($"Your letter grade is {letter}.");

        // Pass or fail message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations on passing the course!");
        }
        else
        {
            Console.WriteLine("Keep trying, you can do better next time!");
        }
    }
}