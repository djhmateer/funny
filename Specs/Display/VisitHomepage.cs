using Funny.Services;
using System.Linq;
using Xunit;

namespace Specs.Display {
    [Trait("Homepage","User visits homepage")]
    public class VisitHomepage : TestBaseWithData
    {
        StoryViewer _viewer;
        public VisitHomepage(){
            _viewer = new StoryViewer();    
        }
        [Fact(DisplayName = "Show all 3 Stories")]
        public void ShowAllStories() {
        
            var result = _viewer.ShowAllStoriesByRatingDescending();
            Assert.Equal(3, result.Count());
        }
        [Fact(DisplayName="Show all Stories in descending rank order")]
        public void ShowListOfStoriesInDescendingRankOrder() {
            var result = _viewer.ShowAllStoriesByRatingDescending();
            // 10,2,5 is order of insert in db
            // First should be rating of 2
            Assert.Equal(10, result[0].Rating);
            Assert.Equal(5, result[1].Rating);
            Assert.Equal(2, result[2].Rating);
        }
    }
}
