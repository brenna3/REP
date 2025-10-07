using System;
using System.Threading;

public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration; // in seconds

    public Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {_activityName}.");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You completed the {_activityName} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string spinner = @"|/-\";
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public virtual void Run()
    {
        Start();
        End();
    }
}
