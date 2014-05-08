using Core.Models;
using Core.Services;
using Xunit;

namespace Tests.Creation {
    [Trait("StoryCreate", "Valid StoryApplication")]
    public class ValidStoryApplicationReceived : TestBase {
        StoryCreatorViewModel viewModel;
        Story _story;

        public ValidStoryApplicationReceived() {
            var storyCreator = new StoryCreator();
            var application = new StoryApplication("Stick", "Whats brown and sticky? A stick", StoryType.Joke);
            viewModel = storyCreator.CreateOrEditStory(application);
            _story = viewModel.NewStory;
        }

        [Fact(DisplayName = "Story is validated")]
        public void StoryValidated() {
            Assert.True(viewModel.StoryApplication.IsValid());
        }
        [Fact(DisplayName = "Story is accepted")]
        public void StoryAccepted() {
            Assert.True(viewModel.StoryApplication.IsAccepted());
        }
        [Fact(DisplayName = "Story is added to the system")]
        public void StoryAddedToSystem() {
            Assert.NotNull(viewModel);
        }
        [Fact(DisplayName = "A StoryType of Joke is the default")]
        public void StoryTypeJoke() {
            Assert.Equal(StoryType.Joke, _story.StoryType);
        }
        [Fact(DisplayName = "A confirmation message is shown to the administrator")]
        public void ConfirmationMessage() {
            Assert.Equal("Successfully created a new story!", viewModel.StoryApplication.Message);
        }
    }
}
