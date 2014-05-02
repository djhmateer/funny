using Funny.DB;
using Funny.Models;

namespace Funny.Services {
    public class StoryVoter {
        public Story AddVote(int? storyID){
            Story story;
            using (var session = new Session()) {
                // Get existing Story
                story = session.Stories.Find(storyID);
                var currentRating = story.Rating;
                story.Rating = currentRating + 1;
                session.SaveChanges();
            }
            return story;
        }
    }
}
