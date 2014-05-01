using Funny.DB;
using Funny.Models;

namespace Funny.Services {
    public class StoryVoter {
        public Story AddVote(Story story){
            Story storyInDB;
            using (var session = new Session()) {
                // Get existing Story
                storyInDB = session.Stories.Find(story.ID);
                var currentRating = storyInDB.Rating;
                storyInDB.Rating = currentRating + 1;
            }
            return storyInDB;
        }
    }
}
