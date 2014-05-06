using System.Data.Entity;
using System.Data.Entity.Migrations;
using Funny.DB;
using System;
using Funny.Models;

namespace Specs {
    public class TestBase : IDisposable {
        public TestBase() {
            new Session().Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
        }

        public void Dispose() {
            //new Session().Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
        }
    }

    public class TestBaseWithData : IDisposable {
        public TestBaseWithData() {
            var session = new Session();
            session.Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
            // INSERT [dbo].[Stories] ([ID], [Title], [Content], [Rating], [ImageURL], [VideoURL], [CreatedAt], [StoryType]) VALUES (184, N'Banana', N'Q: Why did the banana go to the doctors? A: He wasn''t peeling very well', 10, NULL, NULL, CAST(0x0000A31D00744C94 AS DateTime), 0)

            //             var sql = @"SET IDENTITY_INSERT [dbo].[Stories] ON 
            //                INSERT [dbo].[Stories] ([ID], [Title], [Content], [Rating], [ImageURL], [VideoURL], [CreatedAt], [StoryType]) VALUES (184, N'Banana', N'Q: Why did the banana go to the doctors? A: He wasn''t peeling very well', 10, NULL, NULL, '2014-01-01 12:00:05'), 0)
            //
            //                INSERT [dbo].[Stories] ([ID], [Title], [Content], [Rating], [ImageURL], [VideoURL], [CreatedAt], [StoryType]) VALUES (185, N'Glasgow Pizza Shop', NULL, 2, NULL, N'//www.youtube.com/embed/y0TxfwB3BWQ?rel=0', CAST(0x0000A31D00644C84 AS DateTime), 1)
            //                INSERT [dbo].[Stories] ([ID], [Title], [Content], [Rating], [ImageURL], [VideoURL], [CreatedAt], [StoryType]) VALUES (186, N'Lily', N'Q: What do you call a girl with a frog on her heard?  A: Lily', 5, NULL, NULL, CAST(0x0000A31D00544C64 AS DateTime), 0)
            //                SET IDENTITY_INSERT [dbo].[Stories] OFF
            //                ";
            //            new Session().Database.ExecuteSqlCommand(sql);

            session.Stories.Add(new Story {
                //ID = 1,
                StoryType = StoryType.Joke,
                Title = "Banana",
                Content = "Q: Why did the banana go to the doctors? A: He wasn't peeling very well",
                CreatedAt = DateTime.Now.AddMinutes(3),
                Rating = 10
            });

            session.Stories.Add(new Story {
                //ID = 2,
                StoryType = StoryType.Video,
                Title = "Pizza",
                VideoURL = "//www.youtube.com/embed/y0TxfwB3BWQ?rel=0",
                CreatedAt = DateTime.Now.AddMinutes(2),
                Rating = 2
            });

            session.Stories.Add(new Story{
                //ID = 3,
                StoryType = StoryType.Joke,
                Title = "Lily",
                Content = "Q: What do you call a girl with a frog on her heard?  A: Lily",
                CreatedAt = DateTime.Now,
                Rating = 5
            });

            session.SaveChanges();
        }

        // Useful to comment this out as after each ncrunch test run, data is left in the db
        public void Dispose() {
            //new Session().Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
        }
    }


}
