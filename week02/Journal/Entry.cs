using System;

// Entry class - represents a single journal entry
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    // Display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }
}
