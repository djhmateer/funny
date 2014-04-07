using Funny.Models;

namespace Funny.Services {
public class StoryCreatorResult {
    public Story NewStory { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    public StoryApplication StoryApplication { get; set; }

    public StoryCreatorResult() {
        this.Success = false;
    }
}

public class StoryCreator {
    public StoryApplication ValidateApplication(StoryApplication app) {
        // do some stuff
        app.HasBeenValidated = true;
        return app;
    }

    public StoryCreatorResult CreateNewStory(StoryApplication app) {
        var result = new StoryCreatorResult();

        // validation
        result.StoryApplication = ValidateApplication(app);

        // Successful creation of story!
        result.NewStory = new Story();
        result.Message = "Successfully created a new story!";
        result.StoryApplication = app;

        return result;
    }
}
}
