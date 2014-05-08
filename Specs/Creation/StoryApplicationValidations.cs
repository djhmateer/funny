using Core.Models;
using Core.Services;
using Xunit;

namespace Tests.Creation {
    [Trait("StoryCreate","Title <= 4 characters")]
    public class ShortTitle : TestBase{

        StoryCreatorViewModel viewModel;
        public ShortTitle() {
            var app = new StoryApplication("asd", "content", StoryType.Joke);
            viewModel = new StoryCreator().CreateOrEditStory(app);
        }

        [Fact(DisplayName = "StoryApplication is denied")]
        public void StoryApplicaitonDenied() {
            Assert.False(viewModel.StoryApplication.IsValid());
        }

        [Fact(DisplayName = "A message is shown to the administrator explaining why")]
        public void MessageShown() {
            Assert.Contains("invalid", viewModel.StoryApplication.Message);
        }
    }
}
