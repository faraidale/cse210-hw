// For my EXCEEDS REQUIREMENTS bonus: I added a 4th activity which is Gratitude Journaling.
// The user writes 3 gratitude entries with timed reflection pauses between each.
// This deepens the mindfulness experience beyond the 3 required activities.
using System;

public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base(
        "Gratitude Activity",
        "This activity will help you cultivate a grateful heart by walking you through\nwriting three things you are grateful for today, with quiet reflection after each one.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"\nGratitude #{i} — What are you grateful for? ");
            string entry = Console.ReadLine();
            Console.WriteLine($"\nReflect quietly on: \"{entry}\"");
            ShowSpinner(5);
        }

        Console.WriteLine("\nA grateful heart is a happy heart.");
        DisplayEndingMessage();
    }
}
