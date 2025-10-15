using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()
        {
            new Running(new DateTime(2025, 10, 14), 30, 4.8),
            new Cycling(new DateTime(2025, 10, 13), 45, 20),
            new Swimming(new DateTime(2025, 10, 12), 25, 40)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
