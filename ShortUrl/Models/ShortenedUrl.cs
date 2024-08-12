using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShortUrl.Models
{
    
    public class ShortenedUrl
    {
        [Key]
        [StringLength(7, ErrorMessage = "Id value cannot exceed 7 characters.")]
        [Column(TypeName="varchar")]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string LongUrl { get; set; }

        [Required]
        [StringLength(512, ErrorMessage = "ShortUrl value cannot exceed 512 characters.")]
        [Column(TypeName = "varchar")]
        [Index(nameof(ShortUrl), IsUnique = true)]
        public string ShortUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "CreatedBy value cannot exceed 20 characters.")]
        [Column(TypeName = "varchar")]
        public string CreatedBy { get; set; }
    }
}