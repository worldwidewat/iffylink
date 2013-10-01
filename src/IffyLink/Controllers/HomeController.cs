using System;
using System.Globalization;
using System.Web.Mvc;
using WorldWideWat.IffyLink.Models;
using WorldWideWat.IffyLink.Service;

namespace WorldWideWat.IffyLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkRepository _linkRepository;

        public HomeController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public ActionResult Index(string alias = "")
        {
            if (!string.IsNullOrEmpty(alias))
            {
                var linkInfo = _linkRepository.GetLinkInfo(alias);

                return Redirect(linkInfo.Url);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(IffifyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Alias))
            {
                model.Alias = ToBase62String(DateTime.UtcNow.Ticks);
            }

            _linkRepository.CreateLink(model.Link, model.Alias, model.Expiration.Value.UtcDateTime);

            return RedirectToAction("Share", new {alias = model.Alias});
        }

        public ActionResult Share(string alias)
        {
            var linkInfo = _linkRepository.GetLinkInfo(alias);

            var viewModel = new ShareViewModel
            {
                IffyLink = string.Format("{0}/{1}", Request.Url.GetLeftPart(UriPartial.Authority), linkInfo.Alias)
            };

            return View(viewModel);
        }

        // http://www.anotherchris.net/csharp/friendly-unique-id-generation-part-2/
        private static string ToBase62String(long value)
        {
            long x;
            var y = Math.DivRem(value, 62, out x);
            return y > 0 ? ToBase62String(y) + ValToChar(x) : ValToChar(x).ToString(CultureInfo.InvariantCulture);
        }

        private static char ValToChar(long value)
        {
            if (value > 9)
            {
                var ascii = (65 + ((int) value - 10));

                if (ascii > 90)
                {
                    ascii += 6;
                }

                return (char) ascii;
            }

            return value.ToString(CultureInfo.InvariantCulture)[0];
        }
    }
}