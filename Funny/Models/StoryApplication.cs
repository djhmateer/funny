using System;
namespace Funny.Models {

    public enum StoryApplicationStatus {
        Pending,
        Invalid,
        Accepted,
        Denied
    }

    public class StoryApplication {
        public string Title { get; set; }
        public string Content { get; set; }
        public StoryType StoryType { get; set; }
        public bool IsValid { get; set; }
        public StoryApplicationStatus Status { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }

        public StoryApplication(string title, string content, StoryType storyType) {
            this.Title = title;
            this.Content = content;
            this.StoryType = storyType;
            this.IsValid = false;
            this.Status = StoryApplicationStatus.Pending;

            if (String.IsNullOrWhiteSpace(this.Title)
               || String.IsNullOrWhiteSpace(this.Content))
                throw new InvalidOperationException("Can't have an empty Title or Content");
        }

        public bool IsAccepted() {
            return this.Status == StoryApplicationStatus.Accepted;
        }
    }
}
