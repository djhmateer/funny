using Core.Models;
using Core.Services;
using System.Collections.Generic;
using Xunit;

namespace Tests.Display {
    [Trait("Homepage", "User changes sort order to highest rating first")]
    public class ChangeSortOrderToRating : TestBaseWithData {
        StoryViewer _viewer;
        public ChangeSortOrderToRating() {
            _viewer = new StoryViewer();
        }

        [Fact(DisplayName = "Show all 3 Stories")]
        public void ShowAllStories() {
            List<Story> result = _viewer.ShowAllStoriesHighestRatingFirst();
            Assert.Equal(3, result.Count);
        }
        [Fact(DisplayName = "Show all Stories in rating order")]
        public void ShowListOfStoriesInDescendingRankOrder() {
            var result = _viewer.ShowAllStoriesHighestRatingFirst();
            // 10,2,5 is order of insert in db
            // First should be rating of 2
            Assert.Equal(10, result[0].Rating);
            Assert.Equal(5, result[1].Rating);
            Assert.Equal(2, result[2].Rating);
        }
    }
}