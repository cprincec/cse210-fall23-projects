using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(ChecklistGoal))]
public class ChecklistGoal : Goal
{
    public string Type { get; private set; }
    public int NumOfTimesToBeAccomplished { get; private set; }
    public int BonusPoints { get; private set; }
    public int Progress { get; private set; }

    public ChecklistGoal() { }

    [JsonConstructor]
    public ChecklistGoal(string name, string desc, int basePoint, int numOfTimes, int bonus) : base(name, desc, basePoint)
    {
        NumOfTimesToBeAccomplished = numOfTimes;
        BonusPoints = bonus;
        Progress = 0;
        Type = "checklistGoal";
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            Progress += 1;
        }
        IsComplete = NumOfTimesToBeAccomplished == Progress;
        return BasePoint;
    }

    public override string DisplayGoal()
    {
        if (IsComplete)
        {
            return $"[X] {Name} ({Description}) -- Currently completed: {Progress}/{NumOfTimesToBeAccomplished}";
        }
        return $"[ ] {Name} ({Description}) -- Currently completed: {Progress}/{NumOfTimesToBeAccomplished}";
    }

    public override string GetStringRepresentation()
    {
        return $"{Type}|{Name}|{Description}|{BasePoint}|{BonusPoints}|{NumOfTimesToBeAccomplished}|{Progress}|{IsComplete}";
    }
}
