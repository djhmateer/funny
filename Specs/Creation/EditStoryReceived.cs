using System;
using Funny.Models;
using Funny.Services;
using Xunit;

namespace Specs.Creation
{
    [Trait("CreateOrEdit", "Valid edit of existing Story")]
    public class EditStoryReceived : TestBase {
        StoryCreator _sc;
        StoryCreatorResult _result;
        Story _story2;

        public EditStoryReceived() {
            // Create a story
            _sc = new StoryCreator();
            var app = new StoryApplication("Stick", "Whats brown and sticky? A stick", StoryType.Joke);
            _result = _sc.CreateOrEditStory(app);

            // Edit that story using the id created above
            var _sc2 = new StoryCreator();
            var app2 = new StoryApplication("Stick", "Whats brown and sticky? A stick", 
                StoryType.Joke, "", "", storyID:_result.NewStory.ID, rating:5);
            var _result2 = _sc2.CreateOrEditStory(app2);
            _story2 = _result2.NewStory;
        }

        [Fact(DisplayName = "Story CreatedAt date is changed to now")]
        public void StoryCreatedAt(){
            var dbMinute = _story2.CreatedAt.Minute;
            Assert.Equal(DateTime.Now.Minute, dbMinute);
        }
        [Fact(DisplayName = "Rating remains the same")]
        public void RatingRemainsTheSame() {
            var rating = _story2.Rating;
            Assert.Equal(5, rating);
        }
        [Fact(DisplayName = "Story is validated")]
        public void StoryValidated() {
            Assert.True(_result.StoryApplication.IsValid());
        }
        [Fact(DisplayName = "Story is accepted")]
        public void StoryAccepted() {
            Assert.True(_result.StoryApplication.IsAccepted());
        }
        [Fact(DisplayName = "Story is added to the system")]
        public void StoryAddedToSystem() {
            Assert.NotNull(_result);
        }
        [Fact(DisplayName = "A StoryType of Joke is the default")]
        public void StoryTypeJoke() {
            Assert.Equal(StoryType.Joke, _story2.StoryType);
        }
        [Fact(DisplayName = "A confirmation message is shown to the administrator")]
        public void ConfirmationMessage() {
            Assert.Equal("Successfully created a new story!", _result.StoryApplication.Message);
        }
    }
}