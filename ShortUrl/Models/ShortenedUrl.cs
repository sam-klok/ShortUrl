using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortUrl.Models
{
    public class ShortenedUrl
    {
        //public Guid Id { get; set; }
        public string Id { get; set; } 
        public string LongUrl { get; set; } 
        public string ShortUrl { get; set; } 
        public DateTime CreatedOnUtc { get; set; }
        public string CreatedBy { get; set; }
    }
}