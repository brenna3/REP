using System;

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredTimes;
    private int _bonusPoints;

    public int TimesCompleted { get => _timesCompleted; private set => _timesCompleted = value; }
    public int RequiredTimes { get => _requiredTimes; protected set => _requiredTimes = value; }
    public int BonusPoints { get => _bonusPoints; protected set => _bonusPoints = value; }

    public ChecklistGoal(string name, string description, int pointsPerRecord, int requiredTimes, int bonusPoints)
        : base(name, description, pointsPerRecord)
    {
        _timesCompleted = 0;
        _requiredTimes = requiredTimes;
        _bonusPoints = bonusPoints;
    }

    public override string Display()
    {
        string status = IsComplete ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) -- Progress {TimesCompleted}/{RequiredTimes} -- {PointsPerRecord} pts each, {BonusPoints} pts bonus";
    }

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        TimesCompleted++;
        int earned = PointsPerRecord;

        if (TimesCompleted >= RequiredTimes)
        {
            // Award bonus and mark complete
            earned += BonusPoints;
            MarkComplete();
        }

        return earned;
    }

    public override string Serialize()
    {
        // Add TimesCompleted|RequiredTimes|BonusPoints to base serialization
        return $"{base.Serialize()}|{TimesCompleted}|{RequiredTimes}|{BonusPoints}";
    }

    public static ChecklistGoal Deserialize(string[] parts)
    {
        // parts: type, name, desc, points, isComplete, timesCompleted, requiredTimes, bonusPoints
        string name = parts[1].Replace("&#124;", "|");
        string desc = parts[2].Replace("&#124;", "|");
        int pts = int.Parse(parts[3]);
        int timesCompleted = int.Parse(parts[5]);
        int required = int.Parse(parts[6]);
        int bonus = int.Parse(parts[7]);

        var g = new ChecklistGoal(name, desc, pts, required, bonus);
        for (int i = 0; i < timesCompleted; i++)
        {
            g.RecordEvent();
        }
        return g;
    }
}
