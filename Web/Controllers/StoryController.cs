using Funny.DB;
using Funny.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Funny.Services;

namespace Web.Controllers {
    public class StoryController : Controller {
        // private field initialisation without need for constructor
        // happens before this/base constructor
        private Session db = new Session();

        public ActionResult Index() {
            return View(db.Stories.ToList());
        }

        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null) {
                return HttpNotFound();
            }
            return View(story);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryApplication app) {
            if (ModelState.IsValid) {
                // Call our StoryCreator service
                var sc = new StoryCreator();
                StoryCreatorResult result = sc.CreateOrEditStory(app);
                if (result.StoryApplication.IsValid()) {
                    return RedirectToAction("Index");
                }
            }
            return View(app);
        }

        // GET: /Story/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null) {
                return HttpNotFound();
            }
            // Map to a StoryApplication
            var app = new StoryApplication();
            app.StoryID = story.ID;
            app.Title = story.Title;
            app.Content = story.Content;
            app.Rating = story.Rating;
            app.StoryType = story.StoryType;

            return View(app);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoryApplication app) {
            if (ModelState.IsValid) {
                // Call our StoryCreator service
                var sc = new StoryCreator();
                StoryCreatorResult result = sc.CreateOrEditStory(app);
                if (result.StoryApplication.IsValid()) {
                    return RedirectToAction("Index");
                }
            }
            return View(app);
        }

        // GET: /Story/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null) {
                return HttpNotFound();
            }
            
            return View(story);
        }

        // POST: /Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Story story = db.Stories.Find(id);
            db.Stories.Remove(story);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
