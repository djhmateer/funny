using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Specs.Display {
    [Trait("Anon User visits the Homepage", "")]
    public class VisitHomepage {
        [Fact(DisplayName="Show list of all Stories in rank order")]
        public void ShowListOfStoriesInRankOrder() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "Log entry is created")]
        public void LogEntryIsCreated() {
            throw new NotImplementedException();
        }
    }

    [Trait("Anon User votes for a Story", "")]
    public class VoteForAStory {
        [Fact(DisplayName = "Rating is incremented by 1")]
        public void RatingIsIncrementedBy1() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "Log entry is created")]
        public void LogEntryIsCreated() {
            throw new NotImplementedException();
        }
    }

    [Trait("Anon User changes sort order to date", "")]
    public class ChangeSortOrderToDate {
        [Fact(DisplayName = "Story sort order changed to date")]
        public void StorySortOrder() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser() {
            throw new NotImplementedException();
        }
    }

    [Trait("Anon User changes sort order to rank", "")]
    public class ChangeSortOrderToRank {
        [Fact(DisplayName = "Story sort order changed to rank")]
        public void StorySortOrder() {
            throw new NotImplementedException();
        }
        [Fact(DisplayName = "A messsage is provided to the User")]
        public void AMessageIsProvidedForUser() {
            throw new NotImplementedException();
        }
    }
}
