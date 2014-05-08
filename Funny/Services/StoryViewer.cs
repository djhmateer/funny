using System.Collections.Generic;
using System.Linq;
using Core.DB;
using Core.Models;

namespace Core.Services {
    public class StoryViewer {
        public List<Story> ShowAllStoriesHighestRatingFirst(){
            List<Story> result;
            using (var session = new Session()){
                result = session.Stories
                    .OrderByDescending(s => s.Rating)
                    .ToList();
            }
            return result;
        }
        public List<Story> ShowAllStoriesByDateCreatedDescending(){
            List<Story> result;
            using (var session = new Session()) {
                result = session.Stories
                    .OrderByDescending(s => s.CreatedAt)
                    .ToList();
            }
            return result;
        }
    }
}
