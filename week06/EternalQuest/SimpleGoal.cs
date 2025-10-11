using System;

public class SimpleGoal : Goal
{
    // No additional fields needed for a simple goal.
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override string Display()
    {
        // Uses base display which includes completion, plus points info
        return $"{base.Display()} -- Simple Goal -- Worth {PointsPerRecord} pts";
    }

    public override int RecordEvent()
    {
        // When recorded, gain points and mark complete.
        if (IsComplete)
        {
            return 0;
        }

        MarkComplete();
        return PointsPerRecord;
    }

    public override string Serialize()
    {
        return base.Serialize();
    }

    // Static helper to create from serialized values
    public static SimpleGoal Deserialize(string[] parts)
    {
        // parts: type, name, description, points, isComplete
        string name = parts[1].Replace("&#124;", "|");
        string desc = parts[2].Replace("&#124;", "|");
        int pts = int.Parse(parts[3]);
        bool complete = bool.Parse(parts[4]);
        var g = new SimpleGoal(name, desc, pts);
        if (complete) g.RecordEvent(); // mark complete (simple)
        return g;
    }
}
