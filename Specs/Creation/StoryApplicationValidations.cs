using Funny.Models;
using Funny.Services;
using Xunit;

namespace Specs.Creation {
    [Trait("Registration","Title <= 4 characters")]
    public class ShortTitle : TestBase{

        StoryCreatorResult _result;
        public ShortTitle() {
            var app = new StoryApplication("asd", "content", StoryType.Joke);
            _result = new StoryCreator().CreateOrEditStory(app);
        }

        [Fact(DisplayName = "StoryApplication is denied")]
        public void StoryApplicaitonDenied() {
            Assert.False(_result.StoryApplication.IsValid());
        }

        [Fact(DisplayName = "A message is shown to the administrator explaining why")]
        public void MessageShown() {
            Assert.Contains("invalid", _result.StoryApplication.Message);
        }
    }
    [Trait("Registration","Title has existing title")]
    public class ExistingTitle : TestBase{

        StoryCreatorResult _result;
        public ExistingTitle() {
            var app1 = new StoryApplication("asdf", "content", StoryType.Joke);
            _result = new StoryCreator().CreateOrEditStory(app1);
        }

        [Fact(DisplayName = "StoryApplication is denied")]
        public void DoesNotThrow() {
            var app2 = new StoryApplication("asdf", "content", StoryType.Joke);
            Assert.DoesNotThrow( () => new StoryCreator().CreateOrEditStory(app2));
        }

        [Fact(DisplayName = "A message is shown to the administrator explaining why")]
        public void MessageShown() {
            var app2 = new StoryApplication("asdf", "content", StoryType.Joke);
            var result2 = new StoryCreator().CreateOrEditStory(app2);
            Assert.Contains("exists", result2.StoryApplication.Message);
        }
    }
}
