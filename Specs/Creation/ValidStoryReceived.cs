using Funny.Models;
using Funny.Services;
using Xunit;

namespace Specs.Creation {
    [Trait("Registration", "Valid StoryApplication")]
    public class ValidStoryReceived : TestBase {
        StoryCreator _sc;
        StoryCreatorResult _result;
        Story _story;

        public ValidStoryReceived() {
            _sc = new StoryCreator();
            var app = new StoryApplication("Stick", "Whats brown and sticky? A stick", StoryType.Joke);
            _result = _sc.CreateNewStory(app);
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
