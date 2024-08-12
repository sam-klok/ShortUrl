using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShortUrl.Models
{
    public class AddUrlModel
    {
        [Required]
        [Display(Name ="Please provide long URL for shortening")]
        public string LongUrl { get; set; }
    }
}