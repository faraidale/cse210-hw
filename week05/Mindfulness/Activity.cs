// Base class for all mindfulness activities
// Contains shared attributes and behaviors (abstraction + encapsulation)
using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public int Duration => _duration;
    public string Name => _name;

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long would you like this activity to last (in seconds)? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done! ");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name}.");
        Console.WriteLine($"Duration: {_duration} seconds.");
        ShowSpinner(3);
    }

    // Spinner animation using backspace trick
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
        Console.WriteLine();
    }

    // Countdown animation: 5... 4... 3...
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
