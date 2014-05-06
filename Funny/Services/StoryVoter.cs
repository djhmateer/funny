using System;
using Funny.DB;
using Funny.Models;

namespace Funny.Services {
    public class StoryVoter {
        public Story AddVote(int? storyID){
            Story story;
            using (var session = new Session()) {
                // Get existing Story
                story = session.Stories.Find(storyID);

                // TODO Add a vote **here**
                //story.Votes.Add(new Vote { CreatedAt = DateTime.Now });

                // Has this story been voted for in the last 10 seconds?
                //var votes = story.Votes;

                var currentRating = story.Rating;
                story.Rating = currentRating + 1;

                session.SaveChanges();
            }
            return story;
        }
    }
}
