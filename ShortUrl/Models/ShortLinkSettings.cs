using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortUrl.Models
{
    public static class ShortLinkSettings
    {
        public const int Length = 7;
        public const string Alphabet =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    }
}