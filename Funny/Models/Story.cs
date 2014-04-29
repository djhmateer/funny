using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Funny.Models {
    public enum StoryType {
        Joke,
        Video,
        Quote,
        Picture,
        AnimatedGIF
    }

    public class Vote {
        public int ID { get; set; }
        public int RatingChange { get; set; }
        public string IPAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Story Story { get; set; }
    }

    public class Story {
        public int ID { get; set; }
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }
        [MaxLength(2048)]
        [Required]
        public string Content { get; set; }
        public int Rating { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public StoryType StoryType { get; set; }
        public ICollection<Vote> Votes { get; set; }

        public Story() {
            this.CreatedAt = DateTime.Now;
            this.StoryType = StoryType.Joke;
        }
    }
}
