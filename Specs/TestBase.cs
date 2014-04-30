using Funny.DB;
using System;

namespace Specs {
    public class TestBase : IDisposable {
        public TestBase(){
            new Session().Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
        }

        public void Dispose(){
            new Session().Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
        }
    }

     public class TestBaseWithData : IDisposable {
        public TestBaseWithData(){
            new Session().Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
             var sql = @"SET IDENTITY_INSERT [dbo].[Stories] ON 
                INSERT [dbo].[Stories] ([ID], [Title], [Content], [Rating], [ImageURL], [VideoURL], [CreatedAt], [StoryType]) VALUES (184, N'Banana', N'Q: Why did the banana go to the doctors? A: He wasn''t peeling very well', 10, NULL, NULL, CAST(0x0000A31D00744C94 AS DateTime), 0)
                INSERT [dbo].[Stories] ([ID], [Title], [Content], [Rating], [ImageURL], [VideoURL], [CreatedAt], [StoryType]) VALUES (185, N'Glasgow Pizza Shop', NULL, 2, NULL, N'//www.youtube.com/embed/y0TxfwB3BWQ?rel=0', CAST(0x0000A31D00744C94 AS DateTime), 1)
                INSERT [dbo].[Stories] ([ID], [Title], [Content], [Rating], [ImageURL], [VideoURL], [CreatedAt], [StoryType]) VALUES (186, N'Lily', N'Q: What do you call a girl with a frog on her heard?  A: Lily', 5, NULL, NULL, CAST(0x0000A31D00744C94 AS DateTime), 0)
                SET IDENTITY_INSERT [dbo].[Stories] OFF
                ";
            new Session().Database.ExecuteSqlCommand(sql);
        }

        public void Dispose(){
            new Session().Database.ExecuteSqlCommand("DELETE FROM Votes; DELETE FROM Stories");
        }
    }

   
}
