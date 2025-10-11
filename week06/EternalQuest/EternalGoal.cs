using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int pointsPerRecord)
        : base(name, description, pointsPerRecord)
    {
    }

    public override string Display()
    {
        return $"{base.Display()} -- Eternal Goal -- {PointsPerRecord} pts each time (never completes)";
    }

    public override int RecordEvent()
    {
        // Eternal goals never complete; each recording awards points
        return PointsPerRecord;
    }

    public override string Serialize()
    {
        return base.Serialize();
    }

    public static EternalGoal Deserialize(string[] parts)
    {
        string name = parts[1].Replace("&#124;", "|");
        string desc = parts[2].Replace("&#124;", "|");
        int pts = int.Parse(parts[3]);
        // parts[4] is isComplete (should usually be false)
        return new EternalGoal(name, desc, pts);
    }
}
