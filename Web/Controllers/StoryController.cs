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
                StoryCreatorResult result = sc.CreateNewStory(app);

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
            return View(story);
        }

        // POST: /Story/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,Rating,CreatedAt,StoryType")] Story story) {
            if (ModelState.IsValid) {
                db.Entry(story).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story);
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
