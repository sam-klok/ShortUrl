using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShortUrl;
using ShortUrl.Implementations;
using ShortUrl.Models;

namespace ShortUrl.Controllers
{
    public class ShortURLController : Controller
    {
        private DbLifeContext db = new DbLifeContext();

        // GET: ShortURL
        public ActionResult Index()
        {
            return View(db.ShortenedUrls.ToList());
        }

        public ActionResult Add()
        {
            var model = new AddUrlModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "LongUrl")] AddUrlModel model)
        {
            if (ModelState.IsValid)
            {
                if (!Uri.TryCreate(model.LongUrl, UriKind.Absolute, out _))
                {
                    ModelState.AddModelError("", "The specified URL is invalid.");
                    return View(model);
                    //return Results.BadRequest("The specified URL is invalid.");
                }

                // check if long URL already exists in the database
                var record = db.ShortenedUrls.FirstOrDefault(r => r.LongUrl == model.LongUrl);
                if (record != null)
                {
                    return RedirectToAction("Details", "ShortURL", new { Id = record.Id });
                }

                // generate ID
                var shortUrl = new ShortenedUrl();
                shortUrl.LongUrl = model.LongUrl;
                
                using (var urlShorteningService = new UrlShorteningService())
                {
                    shortUrl.Id = urlShorteningService.GenerateUniqueCode();
                }

                //shortUrl.ShortUrl = $"https://localhost:44311/S/{shortUrl.Id}";
                shortUrl.ShortUrl = ConfigurationManager.AppSettings["ShortURL"] + shortUrl.Id;
                shortUrl.CreatedDate = DateTime.Now;
                shortUrl.CreatedBy = "Sergiy";

                db.ShortenedUrls.Add(shortUrl);
                db.SaveChanges();
                return RedirectToAction("Details", "ShortURL", new { Id = shortUrl.Id });
            }

            return View(model);
        }

        // GET: ShortURL/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShortenedUrl shortenedUrl = db.ShortenedUrls.Find(id);
            if (shortenedUrl == null)
            {
                return HttpNotFound();
            }
            return View(shortenedUrl);
        }

        // GET: ShortURL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShortURL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LongUrl,ShortUrl,CreatedDate,CreatedBy")] ShortenedUrl shortenedUrl)
        {
            if (ModelState.IsValid)
            {
                db.ShortenedUrls.Add(shortenedUrl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shortenedUrl);
        }

        // GET: ShortURL/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShortenedUrl shortenedUrl = db.ShortenedUrls.Find(id);
            if (shortenedUrl == null)
            {
                return HttpNotFound();
            }
            return View(shortenedUrl);
        }

        // POST: ShortURL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LongUrl,ShortUrl,CreatedDate,CreatedBy")] ShortenedUrl shortenedUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shortenedUrl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shortenedUrl);
        }

        // GET: ShortURL/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShortenedUrl shortenedUrl = db.ShortenedUrls.Find(id);
            if (shortenedUrl == null)
            {
                return HttpNotFound();
            }
            return View(shortenedUrl);
        }

        // POST: ShortURL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ShortenedUrl shortenedUrl = db.ShortenedUrls.Find(id);
            db.ShortenedUrls.Remove(shortenedUrl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
