using System.Collections.Generic;
using Funny.Models;
using Funny.Services;
using System.Web.Mvc;

namespace Web.Controllers {
    public class HomeController : Controller {

        public ActionResult Index(string sortOrder = "ratingDescending") {
            var viewer = new StoryViewer();
            List<Story> stories = null;
            switch (sortOrder) {
                case "ratingDescending":
                    stories = viewer.ShowAllStoriesByRatingDescending();
                    break;
                case "dateCreatedDescending":
                    stories = viewer.ShowAllStoriesByDateCreatedDescending();
                    break;
            }
            return View(stories);
        }

        public ActionResult Vote(int? storyID) {
            // Call StoryVoter service
            var sv = new StoryVoter();
            Story result = sv.AddVote(storyID);
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}