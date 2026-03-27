using System;
using System.Collections.Generic;

// Video class - represents a YouTube video
public class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Get the number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Display video information and all comments
    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        
        foreach (Comment comment in _comments)
        {
            comment.Display();
        }
        
        Console.WriteLine(); // Blank line between videos
    }
}
