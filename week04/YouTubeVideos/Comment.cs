using System;

// Comment class - represents a comment on a video
public class Comment
{
    private string _name;
    private string _text;

    // Constructor
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Display the comment
    public void Display()
    {
        Console.WriteLine($"{_name}: {_text}");
    }
}
