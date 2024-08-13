using ShortUrl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShortUrl.Controllers
{
    public class SController : Controller
    {
        private DbLifeContext db = new DbLifeContext();

        //GET: Short
        [HttpGet]
        public ActionResult U(string id)
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

            shortenedUrl.Hits = shortenedUrl.Hits + 1;
            db.SaveChangesAsync();

            //var x = Task.Run(() => _emailService.SendEmailAsync());

            return Redirect(shortenedUrl.LongUrl);
        }

    }
}