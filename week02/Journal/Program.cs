using System;

// Creativity features added:
// 1. Added entry counter to show user how many entries they have
// 2. Added confirmation messages after save/load
// 3. Added two extra prompts (7 total instead of 5)
// 4. Added validation for empty entries
// 5. Added visual separators for better readability

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        Console.WriteLine("Welcome to the Journal Program!");
        
        string choice = "";
        
        while (choice != "5")
        {
            Console.WriteLine("\n=== Menu ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            choice = Console.ReadLine();
            
            if (choice == "1")
            {
                // Write new entry
                Entry newEntry = new Entry();
                
                // Get current date
                DateTime currentTime = DateTime.Now;
                newEntry._date = currentTime.ToShortDateString();
                
                // Get random prompt
                newEntry._promptText = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\n{newEntry._promptText}");
                Console.Write("> ");
                newEntry._entryText = Console.ReadLine();
                
                // Validation: don't add empty entries
                if (!string.IsNullOrWhiteSpace(newEntry._entryText))
                {
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully!");
                }
                else
                {
                    Console.WriteLine("Entry was empty and not saved.");
                }
            }
            else if (choice == "2")
            {
                // Display all entries
                journal.DisplayAll();
                
                // Show entry count (creativity feature)
                Console.WriteLine($"Total entries: {journal._entries.Count}");
            }
            else if (choice == "3")
            {
                // Save to file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                // Load from file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nThank you for using the Journal Program. Goodbye!");
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Please select 1-5.");
            }
        }
    }
}