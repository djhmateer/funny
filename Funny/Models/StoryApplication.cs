﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models {

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
        public string Content { get; set; }
        public StoryType StoryType { get; set; }
        public StoryApplicationStatus Status { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
        public string VideoURL { get; set; }
        public string ImageURL { get; set; }
        public int StoryID { get; set; }
        // To allow date importer to set the date
        public DateTime? CreatedAt { get; set; }

        public StoryApplication() { }

        // Helper so don't need to pass StoryID (as we do when editing) and a rating
        public StoryApplication(string title, string content, StoryType storyType) :
            this(title, content, storyType, null, null, 0, 0) {
        }

        public StoryApplication(string title, string content, StoryType storyType,
            string imageUrl, string videoUrl, int storyID, int rating) {

            this.Title = title;
            this.Content = content;
            this.StoryType = storyType;
            this.Status = StoryApplicationStatus.Pending;
            this.StoryID = storyID;
            this.Rating = rating;
            this.ImageURL = ImageURL;
            this.VideoURL = videoUrl;

            // Caught by validations in web project, however if using a Console then this would throw
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
