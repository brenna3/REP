using System;
using System.Globalization;

class Program
{
    // Creativity & exceeding requirements:
    // - Added a simple leveling system based on total score (levels increase every 1000 points).
    // - Added "badges" that unlock when certain thresholds are reached.
    // - These extras are explained here and implemented in the UI loop (console).
    // (This comment documents what exceeds the core requirements.)

    static void Main(string[] args)
    {
        var manager = new GoalManager();
        string saveFile = "goals.txt";
        manager.Load(saveFile);

        Console.WriteLine("Welcome to Eternal Quest!");
        bool done = false;
        while (!done)
        {
            Console.WriteLine();
            Console.WriteLine("Score: " + manager.Score + " | Level: " + GetLevel(manager.Score));
            ShowBadges(manager.Score);
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create a goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoalInteractive(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    DoRecordInteractive(manager);
                    break;
                case "4":
                    manager.Save(saveFile);
                    Console.WriteLine($"Saved to {saveFile}");
                    break;
                case "5":
                    manager.Load(saveFile);
                    Console.WriteLine($"Loaded from {saveFile}");
                    break;
                case "6":
                    manager.Save(saveFile);
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void CreateGoalInteractive(GoalManager manager)
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal (one-time)");
        Console.WriteLine("2. Eternal Goal (repeatable)");
        Console.WriteLine("3. Checklist Goal (complete N times)");
        Console.Write("Choice: ");
        string t = Console.ReadLine()?.Trim();

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Description: ");
        string desc = Console.ReadLine() ?? "";
        int points = ReadInt("Points for each record: ");

        switch (t)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                Console.WriteLine("Simple goal created.");
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                Console.WriteLine("Eternal goal created.");
                break;
            case "3":
                int required = ReadInt("Required times to complete: ");
                int bonus = ReadInt("Bonus points on completion: ");
                manager.AddGoal(new ChecklistGoal(name, desc, points, required, bonus));
                Console.WriteLine("Checklist goal created.");
                break;
            default:
                Console.WriteLine("Unknown type.");
                break;
        }
    }

    static void DoRecordInteractive(GoalManager manager)
    {
        var goals = manager.GetGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        manager.DisplayGoals();
        int choice = ReadInt("Enter goal number to record: ") - 1;
        try
        {
            manager.RecordEvent(choice);
            Console.WriteLine("Recorded event. New score: " + manager.Score);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out int n))
                return n;
            Console.WriteLine("Please enter a valid integer.");
        }
    }

    static int GetLevel(int score)
    {
        // Simple leveling: 1 level per 1000 points
        return (score / 1000) + 1;
    }

    static void ShowBadges(int score)
    {
        if (score >= 5000) Console.WriteLine("Badge: Eternal Champion (5000+ pts)");
        else if (score >= 2000) Console.WriteLine("Badge: Quest Veteran (2000+ pts)");
        else if (score >= 500) Console.WriteLine("Badge: On The Way (500+ pts)");
    }
}
