using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; } = new List<Comment>();

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void AddComment(string commenterName, string commentText)
    {
        Comments.Add(new Comment(commenterName, commentText));
    }
}

class Comment
{
    public string CommenterName { get; }
    public string CommentText { get; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create videos and add comments
        Video video1 = new Video { Title = "Video 1", Author = "Author 1", LengthInSeconds = 300 };
        video1.AddComment("UserA", "Great video!");
        video1.AddComment("UserB", "Awesome content!");
        videos.Add(video1);

        Video video2 = new Video { Title = "Video 2", Author = "Author 2", LengthInSeconds = 420 };
        video2.AddComment("UserC", "Nice video.");
        videos.Add(video2);

        // Iterate through videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
            Console.WriteLine($"Comment Count: {video.GetCommentCount()}");
            
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"Comment by {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();
        }
    }
}
