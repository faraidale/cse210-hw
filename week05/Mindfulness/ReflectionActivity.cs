using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    // Tracks which prompts/questions have been used so none repeat until exhausted
    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown\nstrength and resilience. This will help you recognize the power you have\nand how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times?",
            "What is your favorite thing about this experience?",
            "What could you learn from this that applies elsewhere?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
    }

    private string GetRandomItem(List<string> available, List<string> full)
    {
        // Refill if exhausted so no prompt repeats until all used (exceeds requirements)
        if (available.Count == 0)
            available.AddRange(full);

        Random rand = new Random();
        int index = rand.Next(available.Count);
        string item = available[index];
        available.RemoveAt(index);
        return item;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomItem(_unusedPrompts, _prompts);
        Console.WriteLine($"\nConsider the following:\n\n  > {prompt}\n");
        Console.WriteLine("When you have it in mind, press Enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomItem(_unusedQuestions, _questions);
            Console.Write($"\n  -- {question}  ");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}
