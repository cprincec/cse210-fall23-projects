using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;



public abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int BasePoint { get; protected set; }
    public bool IsComplete { get; protected set; }

    public Goal()
    { }

    [JsonConstructor]
    public Goal(string name, string desc, int basePoint)
    {
        Name = name;
        Description = desc;
        BasePoint = basePoint;
        IsComplete = false;
    }

    public virtual int RecordEvent()
    {
        IsComplete = true;
        return BasePoint;
    }

    public abstract string DisplayGoal();
    public abstract string GetStringRepresentation();
}
