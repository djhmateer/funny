using Core.Models;
using System;
using Xunit;

namespace Tests.CRUD {
    [Trait("StoryCreate","Empty Title or Content")]
    public class EmptyTitle : TestBase {
       
        [Fact(DisplayName = "An exception is thrown with empty title")]
        public void ApplicationInvalid() {
            Assert.Throws<InvalidOperationException>(
                () => new StoryApplication("", "content here", StoryType.Joke)
                );
        }
        [Fact(DisplayName = "An exception is thrown with empty password")]
        public void MessageReturned() {
            Assert.Throws<InvalidOperationException>(
                 () => new StoryApplication("title here", "", StoryType.Joke)
                 );
        }
    }
}
