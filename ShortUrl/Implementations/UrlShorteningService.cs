using ShortUrl.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShortUrl.Implementations
{
    public class UrlShorteningService: IDisposable
    {
        private readonly Random _random = new Random();

        public void Dispose()
        {
        }

        public string GenerateUniqueCode()
        {
            var codeChars = new char[ShortLinkSettings.Length];
            int maxValue = ShortLinkSettings.Alphabet.Length;

            while (true)
            {
                for (var i = 0; i < ShortLinkSettings.Length; i++)
                {
                    var randomIndex = _random.Next(maxValue);

                    codeChars[i] = ShortLinkSettings.Alphabet[randomIndex];
                }
                var code = new string(codeChars);

                using (DbLifeContext dbContext = new DbLifeContext())
                {
                    if (!dbContext.ShortenedUrls.Any(r => r.Id == code))
                        return code;
                }
            }
        }
    }
}