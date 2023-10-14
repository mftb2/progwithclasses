using System;
using System.Collections.Generic;

// Base class for all types of goals
class Goal
{
    public string Title { get; private set; }
    public int Value { get; protected set; }
    public int Progress { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string title)
    {
        Title = title;
        Value = 0;
        Progress = 0;
        IsCompleted = false;
    }

    public virtual void MarkComplete()
    {
        if (!IsCompleted)
        {
            Progress++;
            if (Progress >= Value)
            {
                IsCompleted = true;
                Progress = Value;
                Console.WriteLine($"{Title} goal completed!");
            }
            else
            {
                Console.WriteLine($"{Title} goal progress: {Progress}/{Value}");
            }
        }
    }
}

// SimpleGoal is a goal that can be marked complete to gain points
class SimpleGoal : Goal
{
    public SimpleGoal(string title, int value) : base(title)
    {
        Value = value;
    }
}

// EternalGoal is a goal that can be recorded repeatedly to gain points
class EternalGoal : Goal
{
    public EternalGoal(string title, int value) : base(title)
    {
        Value = value;
    }

    public override void MarkComplete()
    {
        base.MarkComplete();
        Console.WriteLine($"You earned {Value} points for {Title}.");
    }
}

// ChecklistGoal is a goal that requires completing it a certain number of times to get a bonus
class ChecklistGoal : Goal
{
    private int RequiredCount;
    private int BonusValue;

    public ChecklistGoal(string title, int requiredCount, int bonusValue) : base(title)
    {
        RequiredCount = requiredCount;
        BonusValue = bonusValue;
        Value = bonusValue;
    }

    public override void MarkComplete()
    {
        base.MarkComplete();
        if (IsCompleted)
        {
            if (Progress % RequiredCount == 0)
            {
                Console.WriteLine($"{Title} bonus achieved! You earned an additional {BonusValue} points.");
            }
        }
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int userScore = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Eternal Quest Goal Tracker!");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Create a Simple Goal");
            Console.WriteLine("2. Create an Eternal Goal");
            Console.WriteLine("3. Create a Checklist Goal");
            Console.WriteLine("4. List Goals");
            Console.WriteLine("5. Mark Goal as Complete");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateSimpleGoal();
                        break;
                    case 2:
                        CreateEternalGoal();
                        break;
                    case 3:
                        CreateChecklistGoal();
                        break;
                    case 4:
                        ListGoals();
                        break;
                    case 5:
                        MarkGoalComplete();
                        break;
                    case 6:
                        DisplayScore();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }

    static void CreateSimpleGoal()
    {
        Console.Write("Enter the title for your Simple Goal: ");
        string title = Console.ReadLine();
        Console.Write("Enter the point value for your Simple Goal: ");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            Goal simpleGoal = new SimpleGoal(title, value);
            goals.Add(simpleGoal);
            Console.WriteLine($"Simple Goal '{title}' with {value} points created.");
        }
        else
        {
            Console.WriteLine("Invalid input for point value.");
        }
    }

    static void CreateEternalGoal()
    {
        Console.Write("Enter the title for your Eternal Goal: ");
        string title = Console.ReadLine();
        Console.Write("Enter the point value for your Eternal Goal: ");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            Goal eternalGoal = new EternalGoal(title, value);
            goals.Add(eternalGoal);
            Console.WriteLine($"Eternal Goal '{title}' with {value} points created.");
        }
        else
        {
            Console.WriteLine("Invalid input for point value.");
        }
    }

    static void CreateChecklistGoal()
    {
        Console.Write("Enter the title for your Checklist Goal: ");
        string title = Console.ReadLine();
        Console.Write("Enter the required count for your Checklist Goal: ");
        if (int.TryParse(Console.ReadLine(), out int requiredCount))
        {
            Console.Write("Enter the bonus point value for your Checklist Goal: ");
            if (int.TryParse(Console.ReadLine(), out int bonusValue))
            {
                Goal checklistGoal = new ChecklistGoal(title, requiredCount, bonusValue);
                goals.Add(checklistGoal);
                Console.WriteLine($"Checklist Goal '{title}' with {requiredCount} required, {bonusValue} bonus points created.");
            }
            else
            {
                Console.WriteLine("Invalid input for bonus point value.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for required count.");
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("List of Goals:");
        foreach (var goal in goals)
        {
            string goalStatus = goal.IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{goalStatus} {goal.Title} - Progress: {goal.Progress}/{goal.Value}");
        }
    }

    static void MarkGoalComplete()
    {
        ListGoals();
        Console.Write("Enter the index of the goal to mark as complete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < goals.Count)
        {
            goals[index].MarkComplete();
            userScore += goals[index].Value;
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    static void DisplayScore()
    {
        Console.WriteLine($"Your current score: {userScore} points");
    }
}
