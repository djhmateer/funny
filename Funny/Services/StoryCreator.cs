using Funny.Models;

namespace Funny.Services {
    public class StoryCreatorResult {
        public Story NewStory { get; set; }
        public StoryApplication StoryApplication { get; set; }

        public StoryCreatorResult() {
        }
    }

    public class StoryCreator {
        public StoryApplication ValidateApplication(StoryApplication app) {
            // do some stuff

            if (app.Title.Length < 4) {
                app.IsValid = false;
                app.Status = StoryApplicationStatus.Denied;
                app.Message = "Invalid - Title needs to be 4 or more characters";
            } else {
                app.IsValid = true;
            }

            return app;
        }

        public StoryCreatorResult CreateNewStory(StoryApplication app) {
            var result = new StoryCreatorResult();

            // validation
            result.StoryApplication = ValidateApplication(app);

            if (result.StoryApplication.IsValid) {
                // Successful creation of story!
                result.NewStory = new Story();
                result.StoryApplication.Message = "Successfully created a new story!";
                result.StoryApplication.Status = StoryApplicationStatus.Accepted;
                //result.StoryApplication = app;
            }
            
            return result;
        }
    }
}
