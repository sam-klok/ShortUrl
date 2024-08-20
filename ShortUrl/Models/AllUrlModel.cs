using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ShortUrl.Models
{
    public class AllUrlModel
    {
        [Required]
        [Display(Name = "Please provide long URL for shortening")]
        public string LongUrl { get; set; }

        public IEnumerable<ShortenedUrl> ShortenedUrls { get; set; }
    }
}