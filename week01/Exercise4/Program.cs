using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            if (number == 0)
                break;

            numbers.Add(number);
        }

        // Calculate sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Calculate average
        double average = (double)sum / numbers.Count;

        // Find the largest number
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
                max = num;
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}