using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Funny.DB;
using Funny.Models;

namespace Funny.Services {
    public class StoryVoterResult {
        public Story Story { get; set; }
        public String Message { get; set; }
        public bool VoteSucceeded { get; set; }
    }

    public class StoryVoter {
        public StoryVoterResult AddVote(int? storyID) {
            var result = new StoryVoterResult();
            using (var session = new Session()) {
                // Get existing Story
                var story = session.Stories.Find(storyID);

                // Has this story been voted for in the last 10 seconds?
                var votes = story.Votes
                    .FirstOrDefault(v => v.CreatedAt > DateTime.Now.AddSeconds(-10));

                if (votes == null) {
                    // Success!
                    result.VoteSucceeded = true;

                    story.Votes.Add(new Vote { CreatedAt = DateTime.Now });

                    var currentRating = story.Rating;
                    story.Rating = currentRating + 1;

                    result.Story = story;
                    result.Message = "Thank you for voting!";
                    session.SaveChanges();
                } else {
                    result.VoteSucceeded = false;
                    result.Story = story;
                    result.Message = "Only 1 vote per story allowed every 10 seconds :-)";
                }
            }
            return result;
        }
    }
}
