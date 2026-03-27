using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create first video
        Video video1 = new Video("How to Cook Perfect Rice", "Chef Lesedi", 420);
        video1.AddComment(new Comment("Rufaro", "This really helped! My rice came out perfect!"));
        video1.AddComment(new Comment("Maria", "Great tips, especially about the water ratio."));
        video1.AddComment(new Comment("Shingai", "I've been cooking rice wrong my whole life!"));
        video1.AddComment(new Comment("Lisa", "Simple and clear instructions. Thank you!"));
        videos.Add(video1);

        // Create second video
        Video video2 = new Video("10 Minute Morning Workout", "FitLife Academy", 600);
        video2.AddComment(new Comment("Mike", "Love this routine! Do it every morning now."));
        video2.AddComment(new Comment("Mike", "Perfect for busy schedules."));
        video2.AddComment(new Comment("Carlos", "Can you make a version for beginners?"));
        videos.Add(video2);

        // Create third video
        Video video3 = new Video("Introduction to Python Programming", "CodeMaster", 1800);
        video3.AddComment(new Comment("Alice", "Best Python tutorial I've found!"));
        video3.AddComment(new Comment("Tino", "Very clear explanations for beginners."));
        video3.AddComment(new Comment("Sophie", "The examples really helped me understand."));
        video3.AddComment(new Comment("James", "Will you make more advanced tutorials?"));
        videos.Add(video3);

        // Create fourth video
        Video video4 = new Video("Travel Guide: Hidden Gems of Zimbabwe", "WanderZim", 900);
        video4.AddComment(new Comment("Tendai", "So proud of our beautiful country!"));
        video4.AddComment(new Comment("Rachel", "Adding these places to my bucket list!"));
        video4.AddComment(new Comment("Peter", "Great cinematography and storytelling."));
        videos.Add(video4);

        // Display all videos
        Console.WriteLine("=== YouTube Videos ===");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}