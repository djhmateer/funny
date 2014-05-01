using System;
using System.Linq;
using Funny.Models;
using Funny.Services;
using Xunit;

namespace Specs.Display
{
    [Trait("Homepage","User votes for a Story")]
    public class VoteForAStory : TestBase{
        StoryVoter _voter;

        [Fact(DisplayName = "Rating is incremented by 1")]
        public void RatingIsIncrementedBy1() {
            var _sc = new StoryCreator();
            var app = new StoryApplication("Stick", "Whats brown and sticky? A stick", StoryType.Joke);
            var _result = _sc.CreateOrEditStory(app);
            var _story = _result.NewStory;

            _voter = new StoryVoter();
            Story result2 = _voter.AddVote(_story);
            Assert.Equal(1, result2.Rating);
        }

        //[Fact(DisplayName = "A messsage is provided to the User")]
        //public void AMessageIsProvidedForUser() {
        //    throw new NotImplementedException();
        //}
         
        //[Fact(DisplayName = "Show all 3 Stories")]
        //public void ShowAllStories() {
        //    var result = _viewer.ShowAllStoriesByDateCreatedDescending();
        //    Assert.Equal(3, result.Count());
        //}
        //[Fact(DisplayName = "Show all Stories newest first")]
        //public void ShowListOfStoriesInDescendingDateCreatedOrder() {
        //    var result = _viewer.ShowAllStoriesByDateCreatedDescending();
        //    // Banana +5mins, Pizza+2, Lily0 is order of date insert in db
        //    Assert.Equal("Banana", result[0].Title);
        //    Assert.Equal("Pizza", result[1].Title);
        //    Assert.Equal("Lily", result[2].Title);
        //}
    }
}