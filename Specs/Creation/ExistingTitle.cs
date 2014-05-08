using Core.Models;
using Core.Services;
using Xunit;

namespace Tests.Creation
{
    [Trait("StoryCreate","Title has existing title")]
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