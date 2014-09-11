using Core.Models;
using Core.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Controllers {
    public class HomeController : Controller {

        public ActionResult Index(string sortOrder = "ratingDescending", string message = "") {
            var viewer = new StoryViewer();
            List<Story> stories = null;
            switch (sortOrder) {
                case "ratingDescending":
                    stories = viewer.ShowAllStoriesHighestRatingFirst();
                    break;
                case "dateCreatedDescending":
                    stories = viewer.ShowAllStoriesByDateCreatedDescending();
                    break;
            }

            DisplayMessageToUserIfRequired(message);
            return View(stories);
        }

        private void DisplayMessageToUserIfRequired(string message){
            // Is there a message, and what type to display to user ie green or red
            if (message.Contains("Thank you for voting!") && message != ""){
                ViewBag.GreenMessage = true;
            } else{
                ViewBag.RedMessage = true;
            }
            ViewBag.Message = message;
        }

        public ActionResult Vote(int? storyID, string sortOrder = "ratingDescending") {
            var sv = new StoryVoter();
            var result = sv.AddVote(storyID);
            // Display success or fail message of voting
            return RedirectToAction("Index", "Home", new { sortOrder = sortOrder, message = result.Message });
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Test() {
            return View();
        }

    }
}