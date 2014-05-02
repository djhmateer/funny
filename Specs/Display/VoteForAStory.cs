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
        Story _story;
        public VoteForAStory(){
            var sc = new StoryCreator();
            var app = new StoryApplication("Stick", "Whats brown and sticky? A stick", StoryType.Joke);
            var result = sc.CreateOrEditStory(app);
            _story = result.NewStory;
        }

        [Fact(DisplayName = "Rating is incremented by 1")]
        public void RatingIsIncrementedBy1() {
            _voter = new StoryVoter();
            var result = _voter.AddVote(_story.ID);
            Assert.Equal(1, result.Rating);
        }

        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser(){
            throw new NotImplementedException();
        }

        [Fact(DisplayName = "Sort order is remembered")]
        public void SortOrder(){
            throw new NotImplementedException();
        }
    }

    [Trait("Homepage", "User votes for a Story twice")]
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
        public void RatingIsIncrementedBy1() {
            //_voter = new StoryVoter();
            //var result = _voter.AddVote(_story.ID);
            //Assert.Equal(1, result.Rating);
        }

        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser() {
            throw new NotImplementedException();
        }
    }
}