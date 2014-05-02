using System;
using System.Linq;
using Funny.Models;

namespace Funny.Migrations {
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DB.Session> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Funny.DB.Session";
        }

        // Method only runs when doing an update-database
        protected override void Seed(DB.Session context) {
            // Only insert if there are none in there
            //if (!context.Stories.Any()) {
            //    context.Stories.AddOrUpdate(
            //    s => s.ID,
            //    new Story { ID = 1, StoryType = StoryType.Joke, Title = "Banana", Content = "Q: Why did the banana go to the doctors? A: He wasn't peeling very well", CreatedAt = DateTime.Now.AddMinutes(3), Rating = 10 },
            //    new Story { ID = 2, StoryType = StoryType.Video, Title = "Glasgow Pizza Shop", VideoURL = "//www.youtube.com/embed/y0TxfwB3BWQ?rel=0", CreatedAt = DateTime.Now.AddMinutes(2), Rating = 2 },
            //    new Story { ID = 3, StoryType = StoryType.Joke, Title = "Lily", Content = "Q: What do you call a girl with a frog on her heard?  A: Lily", CreatedAt = DateTime.Now, Rating = 5 }
            //    );
            //}

            context.Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
            context.Stories.Add(new Story {
                ID = 1,
                StoryType = StoryType.Joke,
                Title = "Banana",
                Content = "Q: Why did the banana go to the doctors? A: He wasn't peeling very well",
                CreatedAt = DateTime.Now.AddMinutes(3),
                Rating = 10
            });

            context.Stories.Add(new Story {
                ID = 2,
                StoryType = StoryType.Video,
                Title = "Pizza",
                VideoURL = "//www.youtube.com/embed/y0TxfwB3BWQ?rel=0",
                CreatedAt = DateTime.Now.AddMinutes(2),
                Rating = 2
            });

            context.Stories.Add(new Story {
                ID = 3,
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
