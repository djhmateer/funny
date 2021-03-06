using Core.DB;
using Core.Models;
using System;
using System.Data.Entity.Migrations;

namespace Core.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<Session> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Funny.DB.Session";
        }

        // Method only runs when doing an update-database
        protected override void Seed(Session context) {
            context.Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
            context.Stories.Add(new Story {
                StoryType = StoryType.Joke,
                Title = "Banana",
                Content = "Q: Why did the banana go to the doctors? A: He wasn't peeling very well",
                CreatedAt = DateTime.Now.AddMinutes(3),
                Rating = 10
            });

            context.Stories.Add(new Story {
                StoryType = StoryType.Video,
                Title = "Pizza",
                VideoURL = "//www.youtube.com/embed/y0TxfwB3BWQ?rel=0",
                CreatedAt = DateTime.Now.AddMinutes(2),
                Rating = 2
            });

            context.Stories.Add(new Story {
                StoryType = StoryType.Joke,
                Title = "Lily",
                Content = "Q: What do you call a girl with a frog on her heard?  A: Lily",
                CreatedAt = DateTime.Now,
                Rating = 5
            });
            context.SaveChanges();
        }
    }
}
