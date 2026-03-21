using System;

// Creativity features added:
// 1. Only hides words that aren't already hidden (stretch challenge)
// 2. Hides 3 words at a time instead of 1 (better user experience)
// 3. Multiple scripture examples provided (easy to switch)
// 4. Clear instructions for user

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture
        // You can uncomment different scriptures to try different ones:
        
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths";
        
        // Reference reference = new Reference("John", 3, 16);
        // string text = "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life";
        
        // Reference reference = new Reference("Nephi", 3, 7);
        // string text = "And it came to pass that I Nephi said unto my father I will go and do the things which the Lord hath commanded for I know that the Lord giveth no commandments unto the children of men save he shall prepare a way for them that they may accomplish the thing which he commandeth them";

        Scripture scripture = new Scripture(reference, text);

        string input = "";
        
        while (input != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            
            input = Console.ReadLine();
            
            if (input != "quit")
            {
                // Hide 3 words at a time for better experience
                scripture.HideRandomWords(3);
            }
        }

        // Show final state with all words hidden
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are now hidden. Great job memorizing!");
        }
    }
}