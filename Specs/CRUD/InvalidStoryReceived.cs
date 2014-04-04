using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.CRUD {
    [Trait("An Invalid Story is Received", "")]
    public class InValidStoryReceived {
        [Fact(DisplayName = "A Story is not added to the system")]
        public void StoryNotAddedToSystem() {
            throw new NotImplementedException();
        }

        [Fact(DisplayName = "A message is shown to the administrator explaining why")]
        public void MessageShown() {
            throw new NotImplementedException();
        }
    }

}
