using System;
using System.Collections.Generic;
using System.IO;

// Journal class - manages a collection of entries
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in journal yet.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Save journal to a file
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Use ~|~ as separator (unlikely to appear in text)
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
            }
        }
        Console.WriteLine($"Journal saved to {file}");
        Console.WriteLine();
    }

    // Load journal from a file
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File {file} not found.");
            Console.WriteLine();
            return;
        }

        _entries.Clear(); // Clear current entries
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded from {file}");
        Console.WriteLine();
    }
}
