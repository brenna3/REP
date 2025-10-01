using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Unboxing the New Phone 17", "TechGirl", 420);
        Video video2 = new Video("How to Bake a Chocolate Cake", "BakingWithBrenna", 900);
        Video video3 = new Video("Travel Vlog: Thailand edition", "WanderWithBrenna", 1080);
        Video video4 = new Video("Workout Routine for Beginners", "FitWithBren", 600);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great unboxing! That phone looks amazing."));
        video1.AddComment(new Comment("Bob", "I just bought the same one!"));
        video1.AddComment(new Comment("Charlie", "Nice review. Very detailed."));

        // Add comments to video2
        video2.AddComment(new Comment("David", "Love your baking videos!"));
        video2.AddComment(new Comment("Emma", "Tried this recipe today, turned out great."));
        video2.AddComment(new Comment("Frank", "Can you do a lemon version?"));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Thailand looks beautiful!"));
        video3.AddComment(new Comment("Hannah", "Awesome vlog, I want to go there now."));
        video3.AddComment(new Comment("Ian", "What camera did you use?"));

        // Add comments to video4
        video4.AddComment(new Comment("Jack", "Perfect for beginners, thanks!"));
        video4.AddComment(new Comment("Karen", "I’m going to try this tomorrow."));
        video4.AddComment(new Comment("Leo", "Can you make an advanced version too?"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display info for each video
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}