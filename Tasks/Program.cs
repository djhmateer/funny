using Core.DB;
using Core.Models;
using System;
using System.Linq;

namespace Tasks {
    class Program {
        static void Main(string[] args) {
            var session = new Session();
            var story = new Story { Title = "Stick8", Content = "test"};
            session.Stories.Add(story);

            var vote = new Vote { Story=story, CreatedAt = DateTime.Now };
            session.Votes.Add(vote);
            session.SaveChanges();

            foreach (var sto in session.Stories) {
                Console.WriteLine(sto.Title);
                if (sto.Votes != null) {
                    var vot = sto.Votes.FirstOrDefault();
                    Console.WriteLine(vot.CreatedAt);
                }
            }

            Console.WriteLine("Done!");
            Console.Read();
        }
    }
}
