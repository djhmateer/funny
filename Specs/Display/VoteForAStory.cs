using Core.DB;
using Core.Models;
using Core.Services;
using System.Linq;
using System.Web.Mvc;
using Web.Controllers;
using Xunit;

namespace Tests.Display
{
    [Trait("Homepage","User votes for a Story")]
    public class VoteForAStory : TestBaseWithData{
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
            Assert.Equal(1, result.Story.Rating);
        }
        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser(){
            _voter = new StoryVoter();
            var result = _voter.AddVote(_story.ID);
            Assert.Equal("Thank you for voting!", result.Message);
            Assert.Equal(true, result.VoteSucceeded);
        }

        [Fact(DisplayName = "Default of ratingDescending sort order is remembered")]
        public void SortOrder(){
            // Get StoryID of last one entered
            var session = new Session();
            int storyID = session.Stories.FirstOrDefault(st => st.Rating == 5).ID;

            var controller = new HomeController();
            // Rating entered as 10,2,5.. so this sort order is 10,5,2
            var result = controller.Index(sortOrder: "ratingDescending") as ViewResult;

            // Vote for the last story
            var redirectResult = (RedirectToRouteResult)controller.Vote(storyID);

            // Want to assert the RedirectToAction has worked
            Assert.Equal(redirectResult.RouteValues["sortOrder"], "ratingDescending");
        }

        [Fact(DisplayName = "Sorting by date with newest first is remembered")]
        public void SortOrderDateDescending() {
            // Get StoryID of last one entered
            var session = new Session();
            int storyID = session.Stories.FirstOrDefault(st => st.Rating == 5).ID;

            var controller = new HomeController();
            var result = controller.Index(sortOrder: "dateCreatedDescending") as ViewResult;

            // Vote for the last story
            var redirectResult = (RedirectToRouteResult)controller.Vote(storyID, sortOrder: "dateCreatedDescending");

            // Want to assert the RedirectToAction has worked
            Assert.Equal(redirectResult.RouteValues["sortOrder"], "dateCreatedDescending");
        }
    }
}