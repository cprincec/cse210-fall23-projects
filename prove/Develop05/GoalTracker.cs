using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

public class GoalTracker
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalPointsEarned;
    private List<string> _goalTypes = new List<string> {
        "Simple Goal",
        "Eternal Goal",
        "Checklist Goal"
    };

    public int TotalPointsEarned
    {
        get => _totalPointsEarned;
    }

    public GoalTracker()
    {
        _totalPointsEarned = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void CalculateTotalPoints(int goalIndex)
    {
        int pointsEarned = _goals[goalIndex - 1].RecordEvent();
        _totalPointsEarned += pointsEarned;
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
    }

    public void DisplayGoals()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are: ");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.DisplayGoal()}");
            i++;
        }
    }

    public string DisplayGoalTypes()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are: ");
        for (int i = 0; i < _goalTypes.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goalTypes[i]}");
        }
        Console.Write("What type of goal would you like to create: ");
        return Console.ReadLine();
    }

    public int DisplayGoalNames()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }
        Console.Write("What goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine());
        while (index < 1 || index > _goals.Count)
        {
            Console.WriteLine("\nInvalid input. Please select a valid goal number.");
            index = int.Parse(Console.ReadLine());
        }
        return index;
    }

    public void SaveGoals(string fileName)
    {

        GoalTrackerData goalTrackerData = new GoalTrackerData
        {
            TotalPointsEarned = _totalPointsEarned,
            Goals = _goals
        };

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(goalTrackerData, options);
        File.WriteAllText(fileName, json);


    }

    public void LoadGoals(string filename)
    {
        string json = File.ReadAllText(filename);

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        GoalTrackerData goalTrackerData = JsonSerializer.Deserialize<GoalTrackerData>(json, options);

        if (goalTrackerData != null)
        {
            // Update the internal state based on the loaded data
            _totalPointsEarned = goalTrackerData.TotalPointsEarned;
            _goals = goalTrackerData.Goals;

            Console.WriteLine($"Goals loaded from {filename}");
        }
        else
        {
            Console.WriteLine($"Failed to load goals from {filename}");
        }
    }
}
