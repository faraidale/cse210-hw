using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _unusedPrompts;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life\nby having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _unusedPrompts = new List<string>(_prompts);
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
            _unusedPrompts.AddRange(_prompts);

        Random rand = new Random();
        int index = rand.Next(_unusedPrompts.Count);
        string item = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return item;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nList as many responses as you can to the following:\n\n  > {prompt}\n");
        Console.Write("You have 5 seconds to think before you begin...");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> items = new List<string>();

        Console.WriteLine("Start listing! Press Enter after each item.\n");
        while (DateTime.Now < endTime)
        {
            Console.Write("  > ");
            string entry = Console.ReadLine();
            if (entry != null && entry.Trim() != "")
                items.Add(entry.Trim());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        DisplayEndingMessage();
    }
}
