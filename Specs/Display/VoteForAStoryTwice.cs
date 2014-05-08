using Core.Models;
using Core.Services;
using Xunit;

namespace Tests.Display
{
    [Trait("Homepage", "User votes for a Story twice in the space of 10 seconds")]
    public class VoteForAStoryTwice : TestBase {
        StoryVoter _voter;
        Story _story;
        public VoteForAStoryTwice() {
            var sc = new StoryCreator();
            var app = new StoryApplication("Stick", "Whats brown and sticky? A stick", StoryType.Joke);
            var result = sc.CreateOrEditStory(app);
            _story = result.NewStory;
        }
        [Fact(DisplayName = "Rating is not incremented by 1")]
        public void RatingIsNotIncrementedBy1() {
            _voter = new StoryVoter();
            var result = _voter.AddVote(_story.ID);
            Assert.Equal(1, result.Story.Rating);

            var result2 = _voter.AddVote(_story.ID);
            Assert.Equal(1, result2.Story.Rating);
        }
        [Fact(DisplayName = "A red messsage is provided to the User")]
        public void AMessageIsProvidedForUser() {
            _voter = new StoryVoter();
            var result = _voter.AddVote(_story.ID);

            var result2 = _voter.AddVote(_story.ID);
            Assert.False(result2.VoteSucceeded);
            Assert.Equal("Only 1 vote per story allowed every 10 seconds :-)", result2.Message);
        }
    }
}