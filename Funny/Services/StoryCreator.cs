using Funny.Models;
using System;

namespace Funny.Services {
    public class StoryCreatorResult {
        public Story NewStory { get; set; }
        public StoryApplication StoryApplication { get; set; }

        public StoryCreatorResult() {
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

        public StoryCreatorResult InvalidApplication(string reason) {
            var result = new StoryCreatorResult();
            CurrentApplication.Status = StoryApplicationStatus.Invalid;
            //TODO: refactor isvalid out
            CurrentApplication.IsValid = false;
            result.StoryApplication = CurrentApplication;
            result.StoryApplication.Message = reason;
            return result;
        }

        // Part 2
        public Story AcceptApplication() {
            Story story = new Story();
            return story;
        }

        // Part 1
        public StoryCreatorResult CreateNewStory(StoryApplication app) {
            var result = new StoryCreatorResult();

            app.IsValid = true;
            CurrentApplication = app;
            result.StoryApplication = app;
            result.StoryApplication.Message = "Successfully created a new story!";

            if (TitleNotPresent())
                return InvalidApplication("Title is missing");

            if (TitleIsInvalid())
                return InvalidApplication("Title is invalid - needs to be 4 or more characters");

            result.NewStory = AcceptApplication();
            return result;
        }
    }
}
