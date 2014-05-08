using Core.Models;
using Core.Services;
using Xunit;

namespace Tests.Creation {
    [Trait("StoryCreate", "Valid StoryApplication")]
    public class ValidStoryApplicationReceived : TestBase {
        StoryCreatorResult _result;
        Story _story;

        public ValidStoryApplicationReceived() {
            var storyCreator = new StoryCreator();
            var application = new StoryApplication("Stick", "Whats brown and sticky? A stick", StoryType.Joke);
            _result = storyCreator.CreateOrEditStory(application);
            _story = _result.NewStory;
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
            Assert.Equal(StoryType.Joke, _story.StoryType);
        }
        [Fact(DisplayName = "A confirmation message is shown to the administrator")]
        public void ConfirmationMessage() {
            Assert.Equal("Successfully created a new story!", _result.StoryApplication.Message);
        }
    }
}
