using Funny.DB;
using Funny.Models;
using System;
using System.Linq;

namespace Tasks {
    class Program {
        static void Main(string[] args) {
            var session = new Session();
            var story = new Story { Title = "Stick7" };
            session.Stories.Add(story);

            var vote = new Vote { Story=story, RatingChange = 1, CreatedAt = DateTime.Now };
            session.Votes.Add(vote);
            session.SaveChanges();

            foreach (var sto in session.Stories) {
                Console.WriteLine(sto.Title);
                if (sto.Votes != null) {
                    var vot = sto.Votes.FirstOrDefault();
                    Console.WriteLine(vot.RatingChange);
                }
            }

            Console.WriteLine("Done!");
            Console.Read();
        }
    }
}
