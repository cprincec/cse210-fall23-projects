using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;


[JsonDerivedType(typeof(SimpleGoal))]
public class SimpleGoal : Goal
{
    public string Type { get; private set; }

    public SimpleGoal() { }

    [JsonConstructor]
    public SimpleGoal(string name, string desc, int basePoint) : base(name, desc, basePoint)
    {
        Type = "simpleGoal";
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
        return $"{Type}|{Name}|{Description}|{BasePoint}|{IsComplete}";
    }
}
