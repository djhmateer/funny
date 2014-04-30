using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funny.Services;
using Xunit;

namespace Specs.Display {
    [Trait("Homepage","User visits")]
    public class VisitHomepage : TestBaseWithData
    {
        StoryViewer _viewer;

        public VisitHomepage(){
            _viewer = new StoryViewer();    
        }
        [Fact(DisplayName = "Show all Stories")]
        public void ShowAllStories() {
        
            var result = _viewer.ShowAllStories();
            Assert.Equal(3, result.Count());
        }
        [Fact(DisplayName="Show list of all Stories in descending rank order")]
        public void ShowListOfStoriesInDescendingRankOrder() {
            var result = _viewer.ShowAllStories();
            // 10,2,5 is order of insert
            // First should be rating of 2
            Assert.Equal(10, result[0].Rating);
            Assert.Equal(5, result[1].Rating);
            Assert.Equal(2, result[2].Rating);
        }
        [Fact(DisplayName = "Log entry is created")]
        public void LogEntryIsCreated() {
            throw new NotImplementedException();
        }
    }

    [Trait("Homepage","User votes for a Story")]
    public class VoteForAStory {
        [Fact(DisplayName = "Rating is incremented by 1")]
        public void RatingIsIncrementedBy1() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "Log entry is created")]
        public void LogEntryIsCreated() {
            throw new NotImplementedException();
        }
    }

    [Trait("Homepage","User changes sort order to date")]
    public class ChangeSortOrderToDate {
        [Fact(DisplayName = "Story sort order changed to date")]
        public void StorySortOrder() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser() {
            throw new NotImplementedException();
        }
    }

    [Trait("Homepage","User changes sort order to rank")]
    public class ChangeSortOrderToRank {
        [Fact(DisplayName = "Story sort order changed to rank")]
        public void StorySortOrder() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser() {
            throw new NotImplementedException();
        }
    }
}
