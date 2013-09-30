using System;
using System.Web.DynamicData;

namespace WorldWideWat.IffyLink.Service.Models
{
    public class Link
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public DateTimeOffset Created { get; set; }
    }

    public class LinkAlias
    {
        public long Id { get; set; }
        public string Alias { get; set; }
        public long LinkId { get; set; }
        public DateTimeOffset Expires { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}