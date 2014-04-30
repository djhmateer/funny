using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Funny.DB;
using Funny.Services;

namespace Web.Controllers {
    public class HomeController : Controller {
        //private Session db = new Session();

        public ActionResult Index(){
            var viewer = new StoryViewer();
            var stories = viewer.ShowAllStories();
            //var stories = db.Stories
            //    .OrderByDescending(s => s.Rating);
            return View(stories);
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