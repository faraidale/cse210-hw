using System;
using System.Collections.Generic;
using System.Linq;

// Scripture class - represents a complete scripture with reference and words
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    // Hide random words
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        // Get list of words that aren't hidden yet
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // Hide up to numberToHide words (or all remaining visible words)
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        while (hiddenCount < wordsToHide)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
            hiddenCount++;
        }
    }

    // Get display text of scripture
    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.Trim();
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
