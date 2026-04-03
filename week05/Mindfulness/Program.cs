// =============================================================
// W05 Mindfulness Program — Farai Rwambiwa, CSE 210
//
// EXCEEDS REQUIREMENTS bonus:
// 1. I added a 4th activity: Gratitude Activity (gratitude journaling with reflection).
// 2. Non-repeating random prompts/questions in Reflection and Listing activities —
//    items are tracked and none repeat until all have been used at least once per session.
// 3. Session log: tracks how many times each activity was done and displays a
//    summary when the user quits.
// =============================================================

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Session log (exceeds requirements)
        Dictionary<string, int> sessionLog = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflection", 0 },
            { "Listing", 0 },
            { "Gratitude", 0 }
        };

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflection Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Gratitude Activity");
            Console.WriteLine("  5. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    sessionLog["Breathing"]++;
                    break;
                case "2":
                    new ReflectionActivity().Run();
                    sessionLog["Reflection"]++;
                    break;
                case "3":
                    new ListingActivity().Run();
                    sessionLog["Listing"]++;
                    break;
                case "4":
                    new GratitudeActivity().Run();
                    sessionLog["Gratitude"]++;
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }

        // Display session summary log on quit (exceeds requirements)
        Console.Clear();
        Console.WriteLine("=== Session Summary ===\n");
        foreach (var entry in sessionLog)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
        }
        Console.WriteLine("\nThank you for taking time for mindfulness today. Goodbye!");
    }
}