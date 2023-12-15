using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;


[JsonDerivedType(typeof(EternalGoal))]
public class EternalGoal : Goal
{
    public string Type { get; private set; }
    public int NumOfTimesAccomplished { get; private set; }
    public DateTime LastRecordedDate { get; private set; }

    public EternalGoal() { }

    [JsonConstructor]
    public EternalGoal(string name, string desc, int basePoint) : base(name, desc, basePoint)
    {
        NumOfTimesAccomplished = 0;
        Type = "eternalGoal";
    }

    public override int RecordEvent()
    {
        LastRecordedDate = DateTime.Now;
        NumOfTimesAccomplished++;
        return BasePoint;
    }

    public override string DisplayGoal()
    {
        if (IsComplete)
        {
            return $"[X] {Name} ({Description})";
        }
        return $"[ ] {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"{Type}|{Name}|{Description}|{BasePoint}|{NumOfTimesAccomplished}|{IsComplete}|{LastRecordedDate}";
    }
}


