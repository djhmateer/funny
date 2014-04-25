using System;
using System.ComponentModel.DataAnnotations;

namespace Funny.Models {

    public enum StoryApplicationStatus {
        Pending,
        Validated,
        Invalid,
        Accepted,
        Denied
    }

    public class StoryApplication {
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }
        [MaxLength(2048)]
        [Required]
        public string Content { get; set; }
        public StoryType StoryType { get; set; }
        public StoryApplicationStatus Status { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        public int StoryID { get; set; }

        public StoryApplication() { }

        public StoryApplication(string title, string content, StoryType storyType) :
            this(title, content, storyType, null, null, 0) {
        }

        //public StoryApplication(string title, string content, StoryType storyType, string ImageURL, string VideoURL) {
        //}

        public StoryApplication(string title, string content, StoryType storyType, string imageUrl, string videoUrl, int storyID) {
            this.Title = title;
            this.Content = content;
            this.StoryType = storyType;
            this.Status = StoryApplicationStatus.Pending;
            this.StoryID = storyID;

            if (String.IsNullOrWhiteSpace(this.Title)
               || String.IsNullOrWhiteSpace(this.Content))
                throw new InvalidOperationException("Can't have an empty Title or Content");
        }

        public bool IsAccepted() {
            return this.Status == StoryApplicationStatus.Accepted;
        }

        public bool IsValid() {
            return this.Status == StoryApplicationStatus.Validated ||
              this.Status == StoryApplicationStatus.Accepted;
        }

        public bool IsInvalid() {
            return !IsValid();
        }
    }
}
