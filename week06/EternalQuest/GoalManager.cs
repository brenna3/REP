using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    public int Score { get => _score; private set => _score = value; }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public IReadOnlyList<Goal> GetGoals() => _goals.AsReadOnly();

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        var goal = _goals[index];
        int earned = goal.RecordEvent();
        Score += earned;
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Display()}");
        }
    }

    public void Save(string filePath)
    {
        // Text format: one goal per line. First line: SCORE|<score>
        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine($"SCORE|{Score}");
            foreach (var g in _goals)
            {
                writer.WriteLine(g.Serialize());
            }
        }
    }

    public void Load(string filePath)
    {
        _goals.Clear();
        Score = 0;

        if (!File.Exists(filePath))
            return;

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var parts = line.Split('|');
            if (parts.Length == 0)
                continue;

            if (parts[0] == "SCORE")
            {
                Score = int.Parse(parts[1]);
                continue;
            }

            // Determine type and deserialize
            string type = parts[0];
            try
            {
                switch (type)
                {
                    case nameof(SimpleGoal):
                        {
                            // Ensure we have at least 5 parts
                            // SimpleGoal: type|name|desc|points|isComplete
                            var fullPartsSimple = EnsureParts(line, 5);
                            var g = SimpleGoal.Deserialize(fullPartsSimple);
                            _goals.Add(g);
                        }
                        break;
                    case nameof(EternalGoal):
                        {
                            var fullPartsEternal = EnsureParts(line, 5);
                            var g = EternalGoal.Deserialize(fullPartsEternal);
                            _goals.Add(g);
                        }
                        break;
                    case nameof(ChecklistGoal):
                        {
                            // ChecklistGoal: type|name|desc|points|isComplete|timesCompleted|requiredTimes|bonus
                            var fullPartsChecklist = EnsureParts(line, 8);
                            var g = ChecklistGoal.Deserialize(fullPartsChecklist);
                            _goals.Add(g);
                        }
                        break;
                    default:
                        // Unknown type - skip or extend as needed
                        break;
                }
            }
            catch
            {
                // ignored: if a line is malformed, skip it
            }
        }
    }

    private string[] EnsureParts(string line, int expected)
    {
        // A simple splitter that preserves escaped pipes inside content
        // We used replacement for '|' when serializing (&#124;), so normal Split is fine.
        var parts = line.Split('|');
        // If fewer than expected, pad (defensive)
        if (parts.Length < expected)
        {
            var list = parts.ToList();
            while (list.Count < expected) list.Add("");
            parts = list.ToArray();
        }
        return parts;
    }
}
