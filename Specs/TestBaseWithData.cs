﻿using Core.DB;
using Core.Models;
using System;

namespace Tests
{
    public class TestBaseWithData : IDisposable {
        public TestBaseWithData() {
            var session = new Session();
            session.Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");

            session.Stories.Add(new Story {
                StoryType = StoryType.Joke,
                Title = "Banana",
                Content = "Q: Why did the banana go to the doctors? A: He wasn't peeling very well",
                CreatedAt = DateTime.Now.AddMinutes(3),
                Rating = 10
            });

            session.Stories.Add(new Story {
                StoryType = StoryType.Video,
                Title = "Pizza",
                VideoURL = "//www.youtube.com/embed/y0TxfwB3BWQ?rel=0",
                CreatedAt = DateTime.Now.AddMinutes(2),
                Rating = 2
            });

            session.Stories.Add(new Story{
                StoryType = StoryType.Joke,
                Title = "Lily",
                Content = "Q: What do you call a girl with a frog on her heard?  A: Lily",
                CreatedAt = DateTime.Now,
                Rating = 5
            });
            session.SaveChanges();
        }

        // Useful to comment this out as after each ncrunch test run, so some data is left in the db.. actually unpredictable.. much better to clear down!
        public void Dispose() {
            new Session().Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
        }
    }
}