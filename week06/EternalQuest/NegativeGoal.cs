using System;

// Negative goal - lose points for bad habits (CREATIVITY FEATURE)
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Return NEGATIVE points - lose points for bad habit!
        return -_points;
    }

    public override bool IsComplete()
    {
        return false; // Never complete
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) [NEGATIVE GOAL]";
    }
}
