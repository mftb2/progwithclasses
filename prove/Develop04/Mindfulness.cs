using System;
using System.Threading;

// Base class for all activities
class Activity
{
    protected int DurationInSeconds;

    public Activity(int duration)
    {
        DurationInSeconds = duration;
    }

    public virtual void Start()
    {
        Console.WriteLine($"Activity will last for {DurationInSeconds} seconds.");
        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);
    }

    public virtual void End()
    {
        Console.WriteLine("You've done a good job!");
        Console.WriteLine($"Activity completed in {DurationInSeconds} seconds.");
        PauseWithSpinner(3);
    }

    protected void PauseWithSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration) { }

    public override void Start()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        base.Start();
        Console.WriteLine("Let's begin...");

        for (int i = 0; i < DurationInSeconds; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            PauseWithSpinner(3);
        }

        base.End();
    }
}

// Reflection Activity
class ReflectionActivity : Activity
{
    private readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        // Add more questions as needed
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public override void Start()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        base.Start();
        Console.WriteLine("Let's begin...");

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(randomPrompt);

        // Ask the questions
        foreach (string question in questions)
        {
            Console.WriteLine(question);
            PauseWithSpinner(3);
        }

        // Wait for the specified duration in milliseconds
        Thread.Sleep(DurationInSeconds * 1000);

        base.End();
    }
}

// Listing Activity (simplified)
class ListingActivity : Activity
{
    private readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        // Add more prompts as needed
    };

    public ListingActivity(int duration) : base(duration) { }

    public override void Start()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life.");
        base.Start();
        Console.WriteLine("Let's begin...");

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"Think of as many as you can about '{randomPrompt}' for the next {DurationInSeconds} seconds.");

        // Wait for the specified duration in milliseconds
        Thread.Sleep(DurationInSeconds * 1000);

        base.End();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Relaxation Program!");
        Console.WriteLine("Select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.Write("Enter your choice: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    RunActivity(new BreathingActivity(60)); // Duration in seconds
                    break;
                case 2:
                    RunActivity(new ReflectionActivity(60)); // Set Reflection Activity to 60 seconds
                    break;
                case 3:
                    RunActivity(new ListingActivity(90)); // Duration in seconds
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

    static void RunActivity(Activity activity)
    {
        Console.Clear();
        activity.Start();
        Console.Clear();
        activity.End();
    }
}
