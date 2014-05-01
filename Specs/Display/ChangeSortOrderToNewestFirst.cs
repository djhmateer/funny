using Funny.Services;
using System.Linq;
using Xunit;

namespace Specs.Display
{
    [Trait("Homepage","User changes date sort newest first")]
    public class ChangeSortOrderToNewestFirst : TestBaseWithData {
        StoryViewer _viewer;
        public ChangeSortOrderToNewestFirst() {
            _viewer = new StoryViewer();    
        }

        [Fact(DisplayName = "Show all 3 Stories")]
        public void ShowAllStories() {
            var result = _viewer.ShowAllStoriesByDateCreatedDescending();
            Assert.Equal(3, result.Count());
        }
        [Fact(DisplayName = "Show all Stories newest first")]
        public void ShowListOfStoriesInDescendingDateCreatedOrder() {
            var result = _viewer.ShowAllStoriesByDateCreatedDescending();
            // Banana +5mins, Pizza+2, Lily0 is order of date insert in db
            Assert.Equal("Banana", result[0].Title);
            Assert.Equal("Pizza", result[1].Title);
            Assert.Equal("Lily", result[2].Title);
        }

    }
}