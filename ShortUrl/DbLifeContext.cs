using ShortUrl.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShortUrl
{
    public partial class DbLifeContext : DbContext
    {
        public DbLifeContext()
            : base("name=dbLifelongLearning")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }
}
