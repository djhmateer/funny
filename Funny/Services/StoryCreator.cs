using System;
using System.Linq;
using Core.DB;
using Core.Models;

namespace Core.Services {
    public class StoryCreatorViewModel {
        public Story NewStory { get; set; }
        public StoryApplication StoryApplication { get; set; }

        public StoryCreatorViewModel() {
        }
    }

    public class StoryCreator {
        StoryApplication CurrentApplication;

        bool TitleNotPresent() {
            return String.IsNullOrWhiteSpace(CurrentApplication.Title);
        }

        bool TitleIsInvalid() {
            return CurrentApplication.Title.Length < 4;
        }

        private bool TitleAlreadyExists() {
            bool exists;
            using (var session = new Session()) {
                exists = session.Stories.FirstOrDefault(s => s.Title == CurrentApplication.Title
                                                            && s.ID != CurrentApplication.StoryID) != null;
            }
            return exists;
        }

        public StoryCreatorViewModel InvalidApplication(string reason) {
            var result = new StoryCreatorViewModel();
            CurrentApplication.Status = StoryApplicationStatus.Invalid;
            result.StoryApplication = CurrentApplication;
            result.StoryApplication.Message = reason;
            return result;
        }

        // Part 2
        private Story AcceptApplication() {
            bool isEdit = CurrentApplication.StoryID != 0;
            var story = new Story();
            using (var session = new Session()) {
                CurrentApplication.Status = StoryApplicationStatus.Accepted;

                if (isEdit) {
                    // Get existing Story
                    story = session.Stories.Find(CurrentApplication.StoryID);
                }

                story.Title = CurrentApplication.Title;
                story.Content = CurrentApplication.Content;
                story.Rating = CurrentApplication.Rating;
                story.CreatedAt = DateTime.Now;
                story.StoryType = CurrentApplication.StoryType;
                story.VideoURL = CurrentApplication.VideoURL;
                story.ImageURL = CurrentApplication.ImageURL;

                if (!isEdit) {
                    session.Stories.Add(story);
                }

                session.SaveChanges();
            }
            return story;
        }

        // Part 1
        public StoryCreatorViewModel CreateOrEditStory(StoryApplication app) {
            bool isEdit = app.StoryID != 0;
            var result = new StoryCreatorViewModel();

            CurrentApplication = app;
            result.StoryApplication = app;
            if (isEdit) {
                result.StoryApplication.Message = "Successfully edited story!";
            } else {
                result.StoryApplication.Message = "Successfully created a new story!";
            }

            if (TitleNotPresent())
                return InvalidApplication("Title is missing");

            if (TitleIsInvalid())
                return InvalidApplication("Title is invalid - needs to be 4 or more characters");

            if (TitleAlreadyExists())
                return InvalidApplication("Title exists already in database");

            // Accept the StoryApplication
            result.NewStory = AcceptApplication();
            return result;
        }
    }
}
