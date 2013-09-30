using System;

namespace WorldWideWat.IffyLink.Service.Models
{
    public class LinkInfo
    {
        public string Alias { get; set; }

        public string Url { get; set; }

        public DateTimeOffset Expires { get; set; }
    }
}