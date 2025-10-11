using System;

public abstract class Goal
{
    // Private member variables use _underscoreCamelCase
    private string _name;
    private string _description;
    private int _pointsPerRecord;
    private bool _isComplete;

    // Properties (public accessors)
    public string Name { get => _name; protected set => _name = value; }
    public string Description { get => _description; protected set => _description = value; }
    public int PointsPerRecord { get => _pointsPerRecord; protected set => _pointsPerRecord = value; }
    public bool IsComplete { get => _isComplete; protected set => _isComplete = value; }

    protected Goal(string name, string description, int pointsPerRecord)
    {
        _name = name;
        _description = description;
        _pointsPerRecord = pointsPerRecord;
        _isComplete = false;
    }

    // Display is polymorphic; derived classes override to show additional info
    public virtual string Display()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description})";
    }

    // RecordEvent returns the points to add when the goal is recorded
    public abstract int RecordEvent();

    // Serialize the goal to a text line for saving (type-specific data appended by derived classes)
    public virtual string Serialize()
    {
        // Base fields: Name|Description|PointsPerRecord|IsComplete
        return $"{GetType().Name}|{Escape(Name)}|{Escape(Description)}|{PointsPerRecord}|{IsComplete}";
    }

    // Helper for serializing strings with pipes
    protected string Escape(string s)
    {
        return s.Replace("|", "&#124;");
    }

    protected string Unescape(string s)
    {
        return s.Replace("&#124;", "|");
    }

    // Allow derived classes to mark complete
    protected void MarkComplete()
    {
        _isComplete = true;
    }

    // Factory method used when loading from file (implemented outside)
}
