using System;

namespace Funny.Models {
    public enum StoryType {
        Joke,
        Video,
        Quote,
        Picture,
        AnimatedGIF
    }

    public class Story {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public StoryType StoryType { get; set; }

        public Story() {
            this.CreatedAt = DateTime.Now;
            this.StoryType = StoryType.Joke;
        }
    }
}
